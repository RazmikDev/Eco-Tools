using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Eco.Collections.Generic.Limited
{
	/// <summary>
	/// Represent a concurrent collection that stores a limited number of items. Supports only 'insert' and 'take' operation.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	internal class ConcurrentLimitedCollection<T> : LimitedCollection<T>
	{
		/// <summary>
		/// The <see cref="ConcurrentStack{T}"/> that stores collection items.
		/// </summary>
		private readonly ConcurrentStack<T> _stack;

		/// <summary>
		/// The <see cref="Int32"/> value representing an amount of available recyclable object in collection.
		/// </summary>
		/// <returns>This is optimization ot avoid using <see cref="ConcurrentStack{T}.Count"/>.</returns>
		private Int32 _availableItemsCount;

		/// <summary>
		/// Creates a new instance of the <see cref="ConcurrentLimitedCollection{T}"/> class.
		/// </summary>
		internal ConcurrentLimitedCollection()
		{
			_stack = new ConcurrentStack<T>();
		}

		#region Overrides of RecycledElementsCollection<T>

		/// <summary>
		/// Gets the actual amount of stored items.
		/// </summary>
		public override Int32 Count
		{
			get { return _availableItemsCount; }
		}

		/// <summary>
		/// Attempts to return item from limited collection.
		/// </summary>
		/// <param name="item">When this method returns, if the operation was successful, result contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from  successfully; otherwise, false.</returns>
		protected override Boolean TryRemove(out T item)
		{
			var isTaken = _stack.TryPop(out item);
			if (isTaken)
				Interlocked.Decrement(ref _availableItemsCount);

			return isTaken;
		}

		/// <summary>
		/// Attempts to insert item to limited collection.
		/// </summary>
		/// <param name="item">An item to insert.</param>
		/// <returns>true if item is inserted successfully; otherwise, false.</returns>
		protected override Boolean TryAdd(T item)
		{
			_stack.Push(item);
			Interlocked.Increment(ref _availableItemsCount);
			return true;
		}

		#endregion
	}
}