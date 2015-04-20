using System;
using System.Runtime.CompilerServices;

namespace Eco.Boxing
{
	/// <summary>
	/// Provides a global static multi-level cache of boxed structures.
	/// </summary>
	public static class BoxedValuesCache
	{
		/// <summary>
		/// Gets the boxed value with specified key.
		/// </summary>
		/// <typeparam name="TKey">The type of the key used to cache the value.</typeparam>
		/// <typeparam name="TValue">The type of the structure which boxed value is stored in cache.</typeparam>
		/// <param name="key">A key that identifies cached value.</param>
		/// <returns>The <see cref="Object"/> representing a boxed structure stored in cache with provided <paramref name="key"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Object GetBoxedValue<TKey, TValue>(TKey key) where TValue : struct, IEquatable<TValue>
		{
			return BoxedValuesCache<TKey, TValue>.GetBoxedValue(key);
		}

		/// <summary>
		/// Tries to cache boxed structure value with specified key.
		/// </summary>
		/// <typeparam name="TKey">The type of the key used to cache the value.</typeparam>
		/// <typeparam name="TValue">The type of the structure which boxed value is stored in cache.</typeparam>
		/// <param name="key">A key that identifies cached value.</param>
		/// <param name="value">A value to be boxed and cached.</param>
		/// <returns>The <see cref="Object"/> representing a boxed structure stored in cache with provided <paramref name="key"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Object TryCacheValue<TKey, TValue>(TKey key, TValue value) where TValue : struct, IEquatable<TValue>
		{
			return BoxedValuesCache<TKey, TValue>.TryCacheValue(key, value);
		}

		/// <summary>
		/// Tries to get the boxed value with provided key. If value is still not cached - adds it to cache.
		/// </summary>
		/// <typeparam name="TKey">The type of the key used to cache the value.</typeparam>
		/// <typeparam name="TValue">The type of the structure which boxed value is stored in cache.</typeparam>
		/// <param name="key">A key that identifies cached value.</param>
		/// <param name="value">A value to be boxed and cached.</param>
		/// <returns>The <see cref="Object"/> representing a boxed structure stored in cache with provided <paramref name="key"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Object GetOrCache<TKey, TValue>(TKey key, TValue value) where TValue : struct, IEquatable<TValue>
		{
			return BoxedValuesCache<TKey, TValue>.GetOrCache(key, value);
		}
	}
}