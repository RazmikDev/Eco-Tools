using Eco.Threading;
using System;
using System.Collections.Generic;

namespace Eco.Collections.Generic.Limited
{
	/// <summary>
	/// Represent a thread-static collection that stores a limited number of items. Supports only 'insert' and 'take' operation.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public sealed class ThreadStaticLimitedCollection<T> : LimitedCollection<T>
	{
		/// <summary>
		/// The delegate that creates new <see cref="Stack{T}"/>.
		/// </summary>
		private static readonly Func<Stack<T>> ThreadLocalItemsFactoryMethod;

		/// <summary>
		/// Creates a type instance of the <see cref="ThreadStaticLimitedCollection{T}"/> class.
		/// </summary>
		static ThreadStaticLimitedCollection()
		{
			ThreadLocalItemsFactoryMethod = () => new Stack<T>();
		}

		#region Overrides of RecycledElementsCollection<T>

		/// <summary>
		/// Gets the actual amount of stored items.
		/// </summary>
		/// <remarks>Returned value depends on the thread from which  is called.</remarks>
		public override Int32 Count
		{
			get
			{
				Stack<T> threadLocalItems;
				return ThreadLocalStorage<Object, Stack<T>>.TryGetItem(this, out threadLocalItems)
					? threadLocalItems.Count
					: 0;
			}
		}

		/// <summary>
		/// Attempts to insert item to limited collection.
		/// </summary>
		/// <param name="item">An item to insert.</param>
		/// <returns>true if item is inserted successfully; otherwise, false.</returns>
		/// <remarks>Returned value depends on the thread from which method is called.</remarks>
		protected override Boolean TryAdd(T item)
		{
			var threadLocalItems = ThreadLocalStorage<Object, Stack<T>>.GetOrAdd(this, ThreadLocalItemsFactoryMethod);
			threadLocalItems.Push(item);
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
			Stack<T> threadLocalItems;
			if (ThreadLocalStorage<Object, Stack<T>>.TryGetItem(this, out threadLocalItems))
			{
				if (threadLocalItems != null && threadLocalItems.Count > 0)
				{
					item = threadLocalItems.Pop();
					return true;
				}
			}

			item = default(T);
			return false;
		}

		#endregion

		/// <summary>
		/// Removes all items stored by the <see cref="ThreadStaticLimitedCollection{T}"/> for the current thread.
		/// </summary>
		public void ClearOnThread()
		{
			ThreadLocalStorage<Object, Stack<T>>.TryRemove(this);
		}
	}
}