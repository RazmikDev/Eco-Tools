using System;
using System.Collections.Generic;

namespace Eco.Collections.Generic.Limited
{
	/// <summary>
	/// Represent a thread-unsafe collection that stores a limited number of items. Supports only 'insert' and 'take' operation.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public class UnsafeLimitedCollection<T> : LimitedCollection<T>
	{
		/// <summary>
		/// The <see cref="Stack{T}"/> that stores collection items.
		/// </summary>
		private readonly Stack<T> _stack;

		/// <summary>
		/// Creates a new instance of the <see cref="UnsafeLimitedCollection{T}"/> class.
		/// </summary>
		public UnsafeLimitedCollection()
		{
			_stack = new Stack<T>();
		}

		#region Overrides of RecycledElementsCollection<T>

		/// <summary>
		/// Gets the actual amount of stored items.
		/// </summary>
		public override Int32 Count
		{
			get { return _stack.Count; }
		}

		/// <summary>
		/// Attempts to return item from limited collection.
		/// </summary>
		/// <param name="item">When this method returns, if the operation was successful, result contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from  successfully; otherwise, false.</returns>
		protected override Boolean TryRemove(out T item)
		{
			if (_stack.Count > 0)
			{
				item = _stack.Pop();
				return true;
			}

			item = default(T);
			return false;
		}

		/// <summary>
		/// Attempts to insert item to limited collection.
		/// </summary>
		/// <param name="item">An item to insert.</param>
		/// <returns>true if item is inserted successfully; otherwise, false.</returns>
		protected override Boolean TryAdd(T item)
		{
			_stack.Push(item);
			return true;
		}

		#endregion
	}
}