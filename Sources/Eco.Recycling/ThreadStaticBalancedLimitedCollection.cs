using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Eco.Collections.Generic.Limited;

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
		/// The thread-static <see cref="Stack{T}"/> that stores collection items.
		/// </summary>
		[ThreadStatic]
		private static List<T> _threadStaticList;

		/// <summary>
		/// The <see cref="ConcurrentBag{T}"/> used to share items between thread static stacks.
		/// </summary>
		private static readonly ConcurrentBag<T> CommonBuffer;

		/// <summary>
		/// The <see cref="Single"/> value between 0 and 1 that specifies a capacity investment from each thread to a common buffer.
		/// </summary>
		private readonly Single _commonBufferShare;

		/// <summary>
		/// The final capacity for each thread static stack after excluding capacity share to common buffer.
		/// </summary>
		private Int32 _perThreadCapacity;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a type instance of the <see cref="ThreadStaticBalancedLimitedCollection{T}"/> collection.
		/// </summary>
		static ThreadStaticBalancedLimitedCollection()
		{
			CommonBuffer = new ConcurrentBag<T>();
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
				return _threadStaticList == null ? 0 : _threadStaticList.Count;
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
			var threadStaticList = GetList();
			if (threadStaticList.Count <= _perThreadCapacity)
			{
				threadStaticList.Add(item);
				return true;
			}

			// Save item in buffer if thread capacity is exceeded.
			CommonBuffer.Add(item);
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
			if (_threadStaticList == null || _threadStaticList.Count == 0)
				return CommonBuffer.TryTake(out item);

			var lastItemIndex = _threadStaticList.Count - 1;
			item = _threadStaticList[lastItemIndex];
			_threadStaticList.RemoveAt(lastItemIndex);

			return true;
		}

		#endregion

		/// <summary>
		/// Gets the <see cref="Stack{T}"/> that store collection items for the current calling thread.
		/// </summary>
		/// <returns>The <see cref="Stack{T}"/> that store collection items for the current calling thread.</returns>
		/// <remarks>Returned value depends on the thread from which method is called.</remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private List<T> GetList()
		{
			return _threadStaticList ?? (_threadStaticList = new List<T>(_perThreadCapacity));
		}
	}
}