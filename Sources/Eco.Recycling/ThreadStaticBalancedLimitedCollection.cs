using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Eco.Collections.Generic.Limited;
using Eco.Threading;

namespace Eco.Recycling
{
	/// <summary>
	/// Represent a thread-static collection that stores a limited number of items within each thread and equalizes utilization between threads. Supports only 'insert' and 'take' operation.
	/// Contrary the name the total amount of stored items is unlimited because of the common buffer between threads which is unlimited.
	/// The amount of items stored for each thread is limited by <see cref="LimitedCollection{T}.Capacity"/> excluding investments of capacity to common buffer.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	internal sealed class ThreadStaticBalancedLimitedCollection<T> : LimitedCollection<T>
	{
		#region Fields

		/// <summary>
		/// The delegate that creates new <see cref="List{T}"/>.
		/// </summary>
		private static readonly Func<List<T>> ThreadLocalItemsFactoryMethod;

		/// <summary>
		/// The <see cref="ConcurrentBag{T}"/> used to share items between thread static stacks.
		/// </summary>
		private readonly ConcurrentBag<T> _commonBuffer;

		/// <summary>
		/// The <see cref="float"/> value between 0 and 1 that specifies a capacity investment from each thread to a common buffer.
		/// </summary>
		private readonly Single _commonBufferShare;

		/// <summary>
		/// The final capacity for each thread static stack after excluding capacity share to common buffer.
		/// </summary>
		private Int32 _perThreadCapacity;

		#endregion

		#region

		/// <summary>
		/// Creates a type instance of the <see cref="ThreadStaticBalancedLimitedCollection{T}"/> class.
		/// </summary>
		static ThreadStaticBalancedLimitedCollection()
		{
			ThreadLocalItemsFactoryMethod = () => new List<T>();
		}

		/// <summary>
		/// Creates a new instance of the <see cref="ThreadStaticBalancedLimitedCollection{T}"/> class with a capacity share of a common buffer used to balance utilization between threads.
		/// </summary>
		/// <param name="commonBufferShare">A <see cref="Single"/> value between 0 and 1 that specifies a capacity investment from each thread to a common buffer.</param>
		/// <exception cref="ArgumentOutOfRangeException">If <paramref name="commonBufferShare"/> is less or equal to 0 or greater than or equal to 1.</exception>
		internal ThreadStaticBalancedLimitedCollection(Single commonBufferShare)
		{
			if (commonBufferShare >= 1 || commonBufferShare <= 0)
				throw new ArgumentOutOfRangeException("commonBufferShare", @"Common buffer share value should be between 0 and 1.");

			_commonBuffer = new ConcurrentBag<T>();
			_commonBufferShare = commonBufferShare;
		}

		#endregion

		#region Overrides of RecycledElementsCollection<T>

		/// <summary>
		/// Gets the actual amount of stored items.
		/// </summary>
		/// <remarks>Returned value depends on the thread from which  is called.</remarks>
		public override Int32 Count
		{
			// Thread static list count never reaches total capacity in this collection.
			get
			{
				List<T> threadLocalItems;
				return ThreadLocalStorage<Object, List<T>>.TryGetItem(this, out threadLocalItems)
					? threadLocalItems.Count
					: 0;
			}
		}

		/// <summary>
		/// Provided new value of <see cref="LimitedCollection{T}.Capacity"/> property when it is changed.
		/// </summary>
		/// <param name="capacity">A maximum capacity of limited collection.</param>
		protected override void OnCapacityChanged(Int32 capacity)
		{
			var perThreadCapacity = (1 - _commonBufferShare) * capacity;
			_perThreadCapacity = (Int32)Math.Round(perThreadCapacity, 0);
		}

		/// <summary>
		/// Attempts to insert item to limited collection.
		/// </summary>
		/// <param name="item">An item to insert.</param>
		/// <returns>true if item is inserted successfully; otherwise, false.</returns>
		/// <remarks>Returned value depends on the thread from which method is called.</remarks>
		protected override Boolean TryAdd(T item)
		{
			// First trying to save in thread related storage.
			var threadLocalItems = ThreadLocalStorage<Object, List<T>>.GetOrAdd(this, ThreadLocalItemsFactoryMethod);
			if (threadLocalItems.Count <= _perThreadCapacity)
			{
				threadLocalItems.Add(item);
				return true;
			}

			// Save item in buffer if thread capacity is exceeded.
			_commonBuffer.Add(item);
			return true;
		}

		/// <summary>
		/// Attempts to return item from limited collection.
		/// </summary>
		/// <param name="item">When this method returns, if the operation was successful, result contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from  successfully; otherwise, false.</returns>
		/// <remarks>Returned value depends on the thread from which method is called.</remarks>
		protected override Boolean TryRemove(out T item)
		{
			List<T> threadLocalItems;
			if (!ThreadLocalStorage<Object, List<T>>.TryGetItem(this, out threadLocalItems))
			{
				item = default(T);
				return false;
			}

			if (threadLocalItems.Count == 0)
				return _commonBuffer.TryTake(out item);

			var lastItemIndex = threadLocalItems.Count - 1;
			item = threadLocalItems[lastItemIndex];
			threadLocalItems.RemoveAt(lastItemIndex);

			return true;
		}

		#endregion

		/// <summary>
		/// Removes all items stored by the <see cref="ThreadStaticBalancedLimitedCollection{T}"/> for the current thread.
		/// </summary>
		internal void ClearOnThread()
		{
			ThreadLocalStorage<Object, List<T>>.TryRemove(this);
		}
	}
}