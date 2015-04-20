using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Eco.Collections.Generic.Limited
{
	/// <summary>
	/// Represent a thread-static collection that stores a limited number of items. Supports only 'insert' and 'take' operation.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public sealed class ThreadStaticLimitedCollection<T> : LimitedCollection<T>
	{
		/// <summary>
		/// The thread-static <see cref="Stack{T}"/> that stores collection items.
		/// </summary>
		[ThreadStatic]
		private static Stack<T> _threadStaticStack;

		#region Overrides of RecycledElementsCollection<T>

		/// <summary>
		/// Gets the actual amount of stored items.
		/// </summary>
		/// <remarks>Returned value depends on the thread from which  is called.</remarks>
		public override Int32 Count
		{
			get { return GetStack().Count; }
		}

		/// <summary>
		/// Attempts to return item from limited collection.
		/// </summary>
		/// <param name="item">When this method returns, if the operation was successful, result contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from  successfully; otherwise, false.</returns>
		/// <remarks>Returned value depends on the thread from which method is called.</remarks>
		protected override Boolean TryRemove(out T item)
		{
			if (_threadStaticStack != null && _threadStaticStack.Count > 0)
			{
				item = _threadStaticStack.Pop();
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
		/// <remarks>Returned value depends on the thread from which method is called.</remarks>
		protected override Boolean TryAdd(T item)
		{
			GetStack().Push(item);
			return true;
		}

		#endregion

		/// <summary>
		/// Gets the <see cref="Stack{T}"/> that store collection items for the current calling thread.
		/// </summary>
		/// <returns>The <see cref="Stack{T}"/> that store collection items for the current calling thread.</returns>
		/// <remarks>Returned value depends on the thread from which method is called.</remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Stack<T> GetStack()
		{
			return _threadStaticStack ?? (_threadStaticStack = new Stack<T>());
		}
	}
}