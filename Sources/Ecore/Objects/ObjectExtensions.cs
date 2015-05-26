using System;
using System.Runtime.CompilerServices;

namespace Eco.Objects
{
	/// <summary>
	/// Provides static extension methods for <see cref="object"/> type.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Determines whether the specified instances are the same instance.
		/// </summary>
		/// <typeparam name="TCurrent">The type of the firsts compared object.</typeparam>
		/// <typeparam name="TOther">The type of the second compared object.</typeparam>
		/// <param name="current">A current instance to compare.</param>
		/// <param name="other">An other instance to compare.</param>
		/// <returns><c>true</c> if <paramref name="current"/> are same with <paramref name="other"/>; otherwise, <c>false</c>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ReferenceEquals<TCurrent, TOther>(this TCurrent current, TOther other)
			where TCurrent : class // restricts comparing only reference types (if Object - value types passes with boxing)
			where TOther : class // restricts comparing only (!) with reference types (if Object - value types passes with boxing)
		{
			return (Object)current == other;
		}

		/// <summary>
		/// Compares two <see cref="Object"/>s with considering possible null or boxed value.
		/// </summary>
		/// <typeparam name="TCurrent">The type of the firsts compared object.</typeparam>
		/// <typeparam name="TOther">The type of the second compared object.</typeparam>
		/// <param name="current">A current <see cref="Object"/> to compare.</param>
		/// <param name="other">An other <see cref="Object"/> to compare.</param>
		/// <returns><c>true</c> if <paramref name="current"/> equals to <paramref name="other"/>; otherwise, <c>false</c>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean SafeEquals<TCurrent, TOther>(this TCurrent current, TOther other)
			where TCurrent : class // restricts comparing only reference types (if Object - value types passes with boxing)
			where TOther : class // restricts comparing only (!) with reference types (if Object - value types passes with boxing)
		{
			// ReSharper disable RedundantCast
			var currentIsNull = (Object)current == null;
			var otherIsNull = (Object)other == null;
			// ReSharper restore RedundantCast

			return currentIsNull
				? otherIsNull
				: !otherIsNull && current.Equals(other);
		}

		/// <summary>
		/// Compares the <paramref name="argument"/> reference type instance with null and throws exception if comparison result is positive.
		/// </summary>
		/// <typeparam name="T">The type of the argument object.</typeparam>
		/// <param name="argument">A source <typeparamref name="T"/> element that is compared with null.</param>
		/// <param name="argumentName">A name of the source argument that is compared with null.</param>
		/// <param name="message">A message that describes the error.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="argument"/> is null.</exception>
		/// <returns>The <paramref name="argument"/> object if it is not null.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T ThrowIfNull<T>(this T argument, String argumentName = null, String message = null)
			where T : class
		{
			if (argument != null)
				return argument;

			if (message != null)
				throw new ArgumentNullException(argumentName ?? "argument", message);

			throw new ArgumentNullException(argumentName ?? "argument");
		}
	}
}