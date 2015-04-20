using System;

namespace Eco.Collections.Generic.Limited
{
	/// <summary>
	/// Represent a collection that stores a limited number of items. Supports only 'insert' and 'take' operation.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public abstract class LimitedCollection<T>
	{
		/// <summary>
		/// The maximum capacity of limited collection.
		/// </summary>
		private Int32 _capacity;

		/// <summary>
		/// Gets the actual amount of stored items.
		/// </summary>
		public abstract Int32 Count { get; }

		/// <summary>
		/// Gets or sets the maximum capacity of limited collection.
		/// </summary>
		public Int32 Capacity
		{
			get { return _capacity; }
			set
			{
				_capacity = value;
				OnCapacityChanged(_capacity);
			}
		}

		/// <summary>
		/// Provided new value of <see cref="Capacity"/> property when it is changed.
		/// </summary>
		/// <param name="capacity">A maximum capacity of limited collection.</param>
		protected virtual void OnCapacityChanged(Int32 capacity)
		{
		}

		/// <summary>
		/// Attempts to insert item to limited collection.
		/// </summary>
		/// <param name="item">An item to insert.</param>
		/// <returns>true if limited collection capacity is not exceeded and item is inserted successfully; otherwise, false.</returns>
		public Boolean TryPut(T item)
		{
			return Count < Capacity && TryAdd(item);
		}

		/// <summary>
		/// Attempts to return item from limited collection.
		/// </summary>
		/// <param name="item">When this method returns, if the operation was successful, result contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from  successfully; otherwise, false.</returns>
		public Boolean TryTake(out T item)
		{
			return TryRemove(out item);
		}

		/// <summary>
		/// Attempts to insert item to limited collection.
		/// </summary>
		/// <param name="item">An item to insert.</param>
		/// <returns>true if item is inserted successfully; otherwise, false.</returns>
		protected abstract Boolean TryAdd(T item);

		/// <summary>
		/// Attempts to return item from limited collection.
		/// </summary>
		/// <param name="item">When this method returns, if the operation was successful, result contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from  successfully; otherwise, false.</returns>
		protected abstract Boolean TryRemove(out T item);
	}
}