using System;
using System.Runtime.CompilerServices;
using Eco.Reflection;

namespace Eco.Boxing
{
	/// <summary>
	/// Provides set of extension methods to make manipulating with structure types much easier.
	/// </summary>
	public static class Structure
	{
		/// <summary>
		/// Boxes provided structure trying to avoid duplicates of boxed value.
		/// </summary>
		/// <typeparam name="T">The type of the structure to be boxed.</typeparam>
		/// <returns>The boxed structure.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Object Box<T>(this T value) where T : struct, IEquatable<T>
		{
			return BoxedValuesCache.GetOrCache(value, value);
		}

		/// <summary>
		/// Boxes provided value trying to avoid duplicates of boxed value.
		/// </summary>
		/// <typeparam name="T">The type of the value to be boxed.</typeparam>
		/// <returns>The boxed structure if <typeparamref name="T"/> sis value type; otherwise <paramref name="value"/> itself.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Object BoxGeneric<T>(this T value)
		{
			return Type<T>.IsValueType
				? BoxedValuesCache<T, T>.GetOrCache(value, value)
				: value;
		}
	}
}