using System;

namespace Eco.Reflection
{
	/// <summary>
	/// Provides properties and methods describing the generic type.
	/// </summary>
	/// <typeparam name="T">The type which type instance is presented by current class.</typeparam>
	public static class Type<T>
	{
		/// <summary>
		/// The <see cref="Boolean"/> value indicating whether the <typeparamref name="T"/> is value type.
		/// </summary>
		// ReSharper disable once StaticMemberInGenericType
		public static readonly Boolean IsValueType;

		/// <summary>
		/// Creates a type instance of the <see cref="Type{T}"/> class.
		/// </summary>
		static Type()
		{
			IsValueType = typeof(T).IsValueType;
		}
	}
}