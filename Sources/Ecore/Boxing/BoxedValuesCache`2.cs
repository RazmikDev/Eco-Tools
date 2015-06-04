using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Eco.Boxing
{
	/// <summary>
	/// Provides a global static multi-level cache of boxed structures.
	/// </summary>
	/// <typeparam name="TKey">The type of the key used to cache the value.</typeparam>
	/// <typeparam name="TValue">The type of the structure which boxed value is stored in cache.</typeparam>
	internal static class BoxedValuesCache<TKey, TValue>
	{
		#region Fields

		/// <summary>
		/// The equality comparer used to compared keys wich are used to identify cached values.
		/// </summary>
		private static readonly IEqualityComparer<TKey> Comparer;

		/// <summary>
		/// The global collection of boxed values identified by key.
		/// </summary>
		private static readonly ConcurrentDictionary<TKey, Object> BoxedStructuresGlobal;

		/// <summary>
		/// The thread-local collection of boxed values identified by key.
		/// </summary>
		[ThreadStatic]
		private static Dictionary<TKey, Object> _boxedStructuresThreadLocal;

		#endregion

		/// <summary>
		/// Creates a type instance of the <see cref="BoxedStructuresGlobal"/> structure.
		/// </summary>
		static BoxedValuesCache()
		{
			//if (!typeof(TValue).IsValueType)
			//	throw new NotSupportedException("Only value types can be cached.");

			if (typeof(TKey) == typeof(String))
				Comparer = (IEqualityComparer<TKey>)StringComparer.OrdinalIgnoreCase;
			else
				Comparer = EqualityComparer<TKey>.Default;

			BoxedStructuresGlobal = new ConcurrentDictionary<TKey, Object>(Comparer);
		}

		/// <summary>
		/// Gets the boxed value with specified key.
		/// </summary>
		/// <param name="key">A key that identifies cached value.</param>
		/// <returns>The <see cref="Object"/> representing a boxed structure stored in cache with provided <paramref name="key"/>.</returns>
		internal static Object GetBoxedValue(TKey key)
		{
			Object boxedValue;

			if (_boxedStructuresThreadLocal != null && _boxedStructuresThreadLocal.TryGetValue(key, out boxedValue))
				return boxedValue;

			if (BoxedStructuresGlobal.TryGetValue(key, out boxedValue))
			{
				if (_boxedStructuresThreadLocal == null)
					_boxedStructuresThreadLocal = new Dictionary<TKey, Object>(Comparer);

				_boxedStructuresThreadLocal.Add(key, boxedValue);
				return boxedValue;
			}

			return null;
		}

		/// <summary>
		/// Tries to cache boxed structure value with specified key.
		/// </summary>
		/// <param name="key">A key that identifies cached value.</param>
		/// <param name="value">A value to be boxed and cached.</param>
		/// <returns>The <see cref="Object"/> representing a boxed structure stored in cache with provided <paramref name="key"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Object TryCacheValue(TKey key, TValue value)
		{
			Object boxedValue = value;
			boxedValue = BoxedStructuresGlobal.GetOrAdd(key, boxedValue);

			// First time we adds only to global storage. Only if the same key is provided again the local storage is used populated with cached value.
			// That means that the thread local storage is created only if initially unknown key is provided twice. 
			/*
				if (_boxedStructuresThreadLocal == null)
					_boxedStructuresThreadLocal = new Dictionary<String, Object>(_comparer);

				_boxedStructuresThreadLocal.Add(key, boxedValue);
			*/

			return boxedValue;
		}

		/// <summary>
		/// Tries to get the boxed value with provided key. If value is still not cached - adds it to cache.
		/// </summary>
		/// <param name="key">A key that identifies cached value.</param>
		/// <param name="value">A value to be boxed and cached.</param>
		/// <returns>The <see cref="Object"/> representing a boxed structure stored in cache with provided <paramref name="key"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Object GetOrCache(TKey key, TValue value)
		{
			return GetBoxedValue(key) ?? TryCacheValue(key, value);
		}
	}
}