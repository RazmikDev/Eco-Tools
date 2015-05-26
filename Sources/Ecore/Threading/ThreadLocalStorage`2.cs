using System;
using System.Collections.Generic;

namespace Eco.Threading
{
	/// <summary>
	/// Provides thread-local storage for data identified by key.
	/// </summary>
	/// <typeparam name="TKey">The type key used to identify stored item.</typeparam>
	/// <typeparam name="TValue">The type of stored items.</typeparam>
	public static class ThreadLocalStorage<TKey, TValue>
	{
		/// <summary>
		/// The thread-local dictionary that contains stored items for current thread.
		/// </summary>
		[ThreadStatic]
		private static Dictionary<TKey, TValue> _threadLocalItems;

		/// <summary>
		/// Adds a key/item pair to the <see cref="ThreadLocalStorage{TKey,TValue}"/> by using the specified function, if the key does not already exist.
		/// </summary>
		/// <param name="key">A key of the element to add.</param>
		/// <param name="valueFactory">A function used to generate an item for the key.</param>
		/// <returns>The value for the key. This will be either the existing value for the key if the key is already in the storage, or the new value for the key as returned by <paramref name="valueFactory"/> if the key was not in the storage.</returns>
		public static TValue GetOrAdd(TKey key, Func<TValue> valueFactory)
		{
			TValue item;
			if (_threadLocalItems == null)
			{
				_threadLocalItems = new Dictionary<TKey, TValue>();
			}
			else
			{
				var threadLocalItemsCount = _threadLocalItems.Count;
				if (threadLocalItemsCount == 1)
				{
					var enumerator = _threadLocalItems.GetEnumerator();
					if (enumerator.MoveNext())
					{
						var currentPair = enumerator.Current;
						enumerator.Dispose();

						if (EqualityComparer<TKey>.Default.Equals(currentPair.Key, key))
							return currentPair.Value;
					}
					enumerator.Dispose();
				}

				if (threadLocalItemsCount > 1 && _threadLocalItems.TryGetValue(key, out item))
					return item;
			}

			item = valueFactory();
			_threadLocalItems[key] = item;
			return item;
		}

		/// <summary>
		/// Adds the specified key and item to the dictionary.
		/// </summary>
		/// <param name="key">A key of the element to add.</param>
		/// <param name="value">An item of the element to add.</param>
		public static void Add(TKey key, TValue value)
		{
			if (_threadLocalItems == null)
				_threadLocalItems = new Dictionary<TKey, TValue>();

			_threadLocalItems.Add(key, value);
		}

		/// <summary>
		/// Attempts to get the item associated with the specified key from the <see cref="ThreadLocalStorage{TKey,TValue}"/>.
		/// </summary>
		/// <param name="key">A key of the value to get.</param>
		/// <param name="value">When this method returns, contains the object from the <see cref="ThreadLocalStorage{TKey,TValue}"/> that has the specified key, or the default value of the type if the operation failed.</param>
		/// <returns>true if the key was found in the <see cref="ThreadLocalStorage{TKey,TValue}"/>; otherwise, false.</returns>
		public static Boolean TryGetItem(TKey key, out TValue value)
		{
			if (_threadLocalItems == null || _threadLocalItems.Count == 0)
			{
				value = default(TValue);
				return false;
			}

			// ReSharper disable once InvertIf
			if (_threadLocalItems.Count == 1)
			{
				var enumerator = _threadLocalItems.GetEnumerator();
				if (enumerator.MoveNext())
				{
					var currentPair = enumerator.Current;
					enumerator.Dispose();

					if (EqualityComparer<TKey>.Default.Equals(currentPair.Key, key))
					{
						value = currentPair.Value;
						return true;
					}
				}
				enumerator.Dispose();

				return _threadLocalItems.TryGetValue(key, out value);
			}

			return _threadLocalItems.TryGetValue(key, out value);
		}

		/// <summary>
		/// Attempts to remove the item that has the specified key from the <see cref="ThreadLocalStorage{TKey,TValue}"/>.
		/// </summary>
		/// <param name="key">A key of the element to remove.</param>
		/// <returns>true if the object was removed successfully; otherwise, false.</returns>
		public static Boolean TryRemove(TKey key)
		{
			return _threadLocalItems != null && _threadLocalItems.Remove(key);
		}
	}
}