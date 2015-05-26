using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Eco.Collections.Generic.Limited;
using Eco.Threading;

namespace Eco.Recycling
{
	/// <summary>
	/// Represent a thread-static collection that stores a limited number of items within each thread and equalizes utilization between threads using groups of items limited by <see cref="BagSize"/>. 
	/// Supports only 'insert' and 'take' operation.
	/// Contrary the name the total amount of stored items is unlimited because of the common buffer between threads which is unlimited.
	/// The amount of items stored for each thread is limited by <see cref="LimitedCollection{T}.Capacity"/> excluding investments of capacity to common buffer.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	internal sealed class ThreadStaticGroupBalancedLimitedCollection<T> : LimitedCollection<T>
	{
		#region Fields

		/// <summary>
		/// The <see cref="Int32"/> value representing a minimum number of items which can be transfered or received from common thread-shared buffer within single operation. 
		/// </summary>
		internal const Int32 BagSize = 128;

		/// <summary>
		/// The collection of empty <see cref="LimitedBag"/> items.
		/// </summary>
		private readonly ConcurrentStack<LimitedBag> _emptyBags;

		/// <summary>
		/// The collection of fully filled <see cref="LimitedBag"/> items.
		/// </summary>
		private readonly ConcurrentStack<LimitedBag> _filledBags;

		/// <summary>
		/// The <see cref="Int32"/> value representing a number of <see cref="LimitedBag"/> collections that are stored in each <see cref="Warehouse"/>.
		/// </summary>
		private Int32 _warehouseBagCapacity;

		/// <summary>
		/// The <see cref="Single"/> value between 0 and 1 that specifies a capacity investment from each thread to a common buffer.
		/// </summary>
		private readonly Single _commonBufferShare;

		#endregion

		/// <summary>
		/// Creates a new instance of the <see cref="ThreadStaticGroupBalancedLimitedCollection{T}"/> class.
		/// </summary>
		/// <param name="initialCapacity">A capacity of limited collection.</param>
		/// <param name="commonBufferShare">A <see cref="Single"/> value between 0 and 1 that specifies a capacity investment from each thread to a common buffer.</param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <p>If <paramref name="commonBufferShare"/> is less or equal to 0 or greater than or equal to 1.</p>
		/// -- or --
		/// <p>If <paramref name="initialCapacity"/> is less than <see cref="BagSize"/> more than twice.</p>
		/// </exception>
		internal ThreadStaticGroupBalancedLimitedCollection(Int32 initialCapacity, Single commonBufferShare)
		{
			if (commonBufferShare >= 1 || commonBufferShare <= 0)
				throw new ArgumentOutOfRangeException("commonBufferShare", @"Common buffer share value should be between 0 and 1.");

			_commonBufferShare = commonBufferShare;

			_emptyBags = new ConcurrentStack<LimitedBag>();
			_filledBags = new ConcurrentStack<LimitedBag>();

			Capacity = initialCapacity;
		}

		#region Overrides of LimitedCollection<T>

		/// <summary>
		/// Provided new value of <see cref="LimitedCollection{T}.Capacity"/> property when it is changed.
		/// </summary>
		/// <param name="capacity">A maximum capacity of limited collection.</param>
		protected override void OnCapacityChanged(Int32 capacity)
		{
			var realCapacityForThread = (1 - _commonBufferShare) * capacity;
			if (realCapacityForThread <= 2 * BagSize)
				throw new ArgumentOutOfRangeException("capacity", String.Format("Capacity of the group balanced limited collection should be greater than {0}.", 2 * BagSize / (1 - _commonBufferShare)));

			_warehouseBagCapacity = (Int32)(realCapacityForThread / BagSize);
		}

		/// <summary>
		/// Gets the actual amount of stored items.
		/// </summary>
		public override Int32 Count
		{
			get
			{
				Warehouse threadLocalWarehouse;
				return ThreadLocalStorage<ThreadStaticGroupBalancedLimitedCollection<T>, Warehouse>.TryGetItem(this, out threadLocalWarehouse)
					? threadLocalWarehouse.Count
					: 0;
			}
		}

		/// <summary>
		/// Attempts to insert item to limited collection.
		/// </summary>
		/// <param name="item">An item to insert.</param>
		/// <returns>true if item is inserted successfully; otherwise, false.</returns>
		protected override Boolean TryAdd(T item)
		{
			var threadStaticBags = GetThreadLocalWarehouse();

			// Try to put item.
			if (threadStaticBags.TryPut(item))
				return true;

			// If warehouse is full try to add a new empty bag to it.
			LimitedBag emptyLimitedBag;
			if (!_emptyBags.TryPop(out emptyLimitedBag))
				emptyLimitedBag = new LimitedBag(BagSize);

			var filledBag = threadStaticBags.InsertToTop(emptyLimitedBag);
			_filledBags.Push(filledBag);

			// Try to put item again. Now all should be ok couse warehouse contains an empty bag.
			if (threadStaticBags.TryPut(item))
				return true;

			throw new InvalidOperationException("Cannot add new item.");
		}

		/// <summary>
		/// Attempts to return item from limited collection.
		/// </summary>
		/// <param name="item">When this method returns, if the operation was successful, result contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from  successfully; otherwise, false.</returns>
		protected override Boolean TryRemove(out T item)
		{
			var threadStaticBags = GetThreadLocalWarehouse();

			if (threadStaticBags.TryPop(out item))
				return true;

			LimitedBag filledLimitedBag;
			if (!_filledBags.TryPop(out filledLimitedBag))
				return false;

			var emptyBag = threadStaticBags.InsertToBottom(filledLimitedBag);
			if (emptyBag != null)
				_emptyBags.Push(emptyBag);

			if (threadStaticBags.TryPop(out item))
				return true;

			throw new InvalidOperationException("Cannot add get and remove item.");
		}

		#endregion

		/// <summary>
		/// Gets the <see cref="Warehouse"/> related with current thread.
		/// </summary>
		/// <returns>The <see cref="Warehouse"/> related with current thread.</returns>
		private Warehouse GetThreadLocalWarehouse()
		{
			Warehouse threadLocalWarehouse;
			if (ThreadLocalStorage<ThreadStaticGroupBalancedLimitedCollection<T>, Warehouse>.TryGetItem(this, out threadLocalWarehouse))
			{
				if (threadLocalWarehouse.BagsCount != _warehouseBagCapacity)
					threadLocalWarehouse.Increase(_warehouseBagCapacity);

				return threadLocalWarehouse;
			}

			threadLocalWarehouse = new Warehouse(_warehouseBagCapacity);
			ThreadLocalStorage<ThreadStaticGroupBalancedLimitedCollection<T>, Warehouse>.Add(this, threadLocalWarehouse);
			return threadLocalWarehouse;
		}

		/// <summary>
		/// Represents a limited collection that stores items in <see cref="LimitedBag"/>.
		/// </summary>
		internal sealed class Warehouse
		{
			#region Fields

			/// <summary>
			/// The array of <see cref="LimitedBag"/> items that stores collection items.
			/// </summary>
			private LimitedBag[] _limitedBags;

			/// <summary>
			/// The <see cref="Int32"/> value that indicates index of the current working bag.
			/// </summary>
			private Int32 _currentBagIndex;

			/// <summary>
			/// The <see cref="Int32"/> value indicating the actual number for stored items.
			/// </summary>
			private Int32 _count;

			#endregion

			/// <summary>
			/// Creates a new instance of the <see cref="Warehouse"/> class.
			/// </summary>
			/// <param name="bagsCapacity">An <see cref="Int32"/> value representing number of bags that ara used to store items.</param>
			public Warehouse(Int32 bagsCapacity)
			{
				_limitedBags = new LimitedBag[bagsCapacity];
				_currentBagIndex = 0;
				_count = 0;
			}

			/// <summary>
			/// Gets the maximum number if bags that can be used to store items.
			/// </summary>
			public Int32 BagsCount
			{
				get { return _limitedBags.Length; }
			}

			/// <summary>
			/// Get the actual amount of stored items.
			/// </summary>
			public Int32 Count
			{
				get { return _count; }
			}

			/// <summary>
			/// Increases the <see cref="BagsCount"/> to store more items.
			/// </summary>
			/// <param name="bagCapacity">An <see cref="Int32"/> value representing number of bags that ara used to store items.</param>
			/// <exception cref="ArgumentOutOfRangeException">If <paramref name="bagCapacity"/> is less or equal to <see cref="BagsCount"/>.</exception>
			public void Increase(Int32 bagCapacity)
			{
				if (bagCapacity <= _limitedBags.Length)
					throw new ArgumentOutOfRangeException("bagCapacity", "New capacity can be greater than current size of bucket");

				Array.Resize(ref _limitedBags, bagCapacity);
			}

			/// <summary>
			/// Gets the <see cref="LimitedBag"/> by provided index. 
			/// </summary>
			/// <param name="index">An index of the requested <see cref="LimitedBag"/>.</param>
			/// <param name="createIfNull">A <see cref="Boolean"/> value indicating whether to create a new bag if theres in bag with provided index.</param>
			/// <param name="suppresCheck">A <see cref="Boolean"/> value indicating whether to suppress consistency check that verifies that only first zero-indexed bag can be null .</param>
			/// <returns>The <see cref="LimitedBag"/> with provided index.</returns>
			// ReSharper disable once UnusedParameter.Local // Resharper is Dumb
			private LimitedBag GetBag(Int32 index, Boolean createIfNull = false, Boolean suppresCheck = false)
			{
				var bag = _limitedBags[index];
				if (bag != null)
					return bag;

				// only first zero-indexed bag can be null
				if (!suppresCheck && index != 0)
					throw new InvalidOperationException("Non-zero bag index refers to empty cell");

				if (!createIfNull)
					return null;

				bag = new LimitedBag(BagSize);
				_limitedBags[index] = bag;

				return bag;
			}

			#region Item Pop/Put

			/// <summary>
			/// Tries to get item from collection.
			/// </summary>
			/// <param name="item">An item parameter where value is set if collection is not empty.</param>
			/// <returns>true if collection is not empty and <paramref name="item"/> is set successfully; otherwise, false.</returns>
			internal Boolean TryPop(out T item)
			{
				// get current bag
				var currentBag = GetBag(_currentBagIndex);
				if (currentBag == null) // only first current zero-indexed bag can be null
				{
					item = default(T);
					return false;
				}

				// try to get item
				if (currentBag.TryPop(out item))
				{
					--_count;
					return true;
				}

				// if current bag is empty move to previous bag
				if (_currentBagIndex > 0)
					--_currentBagIndex;
				else
					return false;

				// get previous bag
				currentBag = GetBag(_currentBagIndex);

				// try to get item from previous bag
				if (currentBag.TryPop(out item))
				{
					--_count;
					return true;
				}

				// if previous bag is empty - something goes wrong!
				throw new InvalidOperationException("A sequence of empty bags is detected.");
			}

			/// <summary>
			/// Tries to put item to collection.
			/// </summary>
			/// <param name="item">An item to be added to collection.</param>
			/// <returns>true if capacity of the collection is not exceeded and items is added successfully; otherwise, false.</returns>
			internal Boolean TryPut(T item)
			{
				var currentBag = GetBag(_currentBagIndex, createIfNull: true);

				if (currentBag.TryPut(item))
				{
					++_count;
					return true;
				}

				if (_currentBagIndex == _limitedBags.Length - 1)
					return false;

				++_currentBagIndex;

				currentBag = GetBag(_currentBagIndex, createIfNull: true, suppresCheck: true);

				if (currentBag.TryPut(item))
				{
					++_count;
					return true;
				}

				throw new InvalidOperationException("A sequence of filled bags is detected.");
			}

			#endregion

			#region Bag Exchange

			/// <summary>
			/// Inserts empty <see cref="LimitedBag"/> to the top of current <see cref="Warehouse"/>.
			/// </summary>
			/// <param name="emptyBag">An empty <see cref="LimitedBag"/> to be added.</param>
			/// <returns>The filled <see cref="LimitedBag"/> from the bottom of the <see cref="Warehouse"/>.</returns>
			/// <exception cref="ArgumentException">If <paramref name="emptyBag"/> is not empty.</exception>
			internal LimitedBag InsertToTop(LimitedBag emptyBag)
			{
				if (!emptyBag.IsEmpty)
					throw new ArgumentException("Only empty limited bag can be added to the top of warehouse", "emptyBag");

				var bottomFilledBag = _limitedBags[0];
				Array.Copy(_limitedBags, 1, _limitedBags, 0, _limitedBags.Length - 1);
				_limitedBags[_limitedBags.Length - 1] = emptyBag;
				_count -= BagSize;

				Debug.Assert(bottomFilledBag.IsFilled, "Bottom bag is not filled");
				return bottomFilledBag;
			}

			/// <summary>
			/// Inserts filled <see cref="LimitedBag"/> to the bottom of current <see cref="Warehouse"/>.
			/// </summary>
			/// <param name="filledBag">A filled <see cref="LimitedBag"/> to be added.</param>
			/// <returns>The empty <see cref="LimitedBag"/> from the top of the <see cref="Warehouse"/>.</returns>
			/// <exception cref="ArgumentException">If <paramref name="filledBag"/> is not filled.</exception>
			internal LimitedBag InsertToBottom(LimitedBag filledBag)
			{
				if (!filledBag.IsFilled)
					throw new ArgumentException("Only filled limited bag can be added to the bottom of warehouse", "filledBag");

				var topEmptyBag = _limitedBags[_limitedBags.Length - 1];
				Array.Copy(_limitedBags, 0, _limitedBags, 1, _limitedBags.Length - 1);
				_limitedBags[0] = filledBag;
				_count += BagSize;

				Debug.Assert(topEmptyBag.IsEmpty, "Top bag is not empty");
				return topEmptyBag;
			}

			#endregion
		}

		/// <summary>
		/// Represent a lightweight collection with fixed capacity.
		/// </summary>
		internal sealed class LimitedBag
		{
			#region Fields

			/// <summary>
			/// The inner array that stores collection items.s
			/// </summary>
			private readonly T[] _innerArray;

			/// <summary>
			/// The <see cref="Int32"/> value representing a maximum index that fits in bounds <see cref="_innerArray"/>.
			/// </summary>
			private readonly Int32 _innerArrayMaximumIndex;

			/// <summary>
			/// The <see cref="Int32"/> value representing an last index of used cell in <see cref="_innerArray"/>.
			/// </summary>
			private Int32 _lastUsedCellIndex;

			#endregion

			/// <summary>
			/// Creates a new instance of the <see cref="LimitedBag"/> class.
			/// </summary>
			/// <param name="capacity">A capacity of the collection.</param>
			internal LimitedBag(Int32 capacity)
			{
				if (capacity <= 0)
					throw new ArgumentOutOfRangeException("capacity", "Capacity can be only positive and not zero value");

				_innerArray = new T[capacity];
				_innerArrayMaximumIndex = capacity - 1;
				_lastUsedCellIndex = -1;
			}

			/// <summary>
			/// Gets the <see cref="Boolean"/> valued indicating whethe the current <see cref="LimitedBag"/> is empty.
			/// </summary>
			internal Boolean IsEmpty
			{
				get { return _lastUsedCellIndex == -1; }
			}

			/// <summary>
			/// Gets the <see cref="Boolean"/> valued indicating whethe the current <see cref="LimitedBag"/> is filled.
			/// </summary>
			internal Boolean IsFilled
			{
				get { return _lastUsedCellIndex == _innerArrayMaximumIndex; }
			}

			/// <summary>
			/// Tries to get item from collection.
			/// </summary>
			/// <param name="item">An item parameter where value is set if collection is not empty.</param>
			/// <returns>true if collection is not empty and <paramref name="item"/> is set successfully; otherwise, false.</returns>
			internal Boolean TryPop(out T item)
			{
				if (IsEmpty)
				{
					item = default(T);
					return false;
				}

				item = _innerArray[_lastUsedCellIndex];
				_innerArray[_lastUsedCellIndex] = default(T);
				--_lastUsedCellIndex;

				return true;
			}

			/// <summary>
			/// Tries to put item to collection.
			/// </summary>
			/// <param name="item">An item to be added to collection.</param>
			/// <returns>true if capacity of the collection is not exceeded and items is added successfully; otherwise, false.</returns>
			internal Boolean TryPut(T item)
			{
				if (IsFilled)
					return false;

				_innerArray[++_lastUsedCellIndex] = item;
				return true;
			}
		}
	}
}