using System;
using System.Runtime.CompilerServices;

namespace Eco.Recycling
{
	/// <summary>
	/// Provides an extension methods for <see cref="IRecyclable"/> objects.
	/// </summary>
	public static class Recyclable
	{
		/// <summary>
		/// Signalizes that provided recyclable object is not used and can be recycled.
		/// </summary>
		/// <typeparam name="TRecyclable">The type of recyclable object.</typeparam>
		/// <param name="recyclable">A <see cref="IRecyclable"/> object that is not used and ready for recycling.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="recyclable"/> is null.</exception>
		/// <exception cref="InvalidOperationException">
		/// <p>If <paramref name="recyclable"/> is already in recycle factory.</p>
		/// <p>If <paramref name="recyclable"/> has undefined source recycle factory.</p>
		/// </exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Free<TRecyclable>(this TRecyclable recyclable)
			where TRecyclable : class, IRecyclable
		{
			var sourceFactory = recyclable.VerifyAndGetFactory();
			sourceFactory.Recycle(recyclable);
		}

		/// <summary>
		/// Signalizes that provided recyclable object is not used and can be recycled.
		/// </summary>
		/// <typeparam name="TRecyclable">The type of recyclable object.</typeparam>
		/// <param name="recyclable">A <see cref="IRecyclable"/> object that is not used and ready for recycling.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean TryFree<TRecyclable>(this TRecyclable recyclable)
			where TRecyclable : class, IRecyclable
		{
			var sourceFactory = recyclable.VerifyAndGetFactory(true);
			if (sourceFactory == null)
				return false;

			sourceFactory.Recycle(recyclable);
			return true;
		}

		/// <summary>
		/// Signalizes that provided object is not used and can be recycled (if it could be recycled).
		/// </summary>
		/// <param name="recyclableObject">A <see cref="IRecyclable"/> object that is not used and ready for recycling.</param>
		/// <returns>true if provided object is successfully recycled; otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean TryFreeIfRecyclable(Object recyclableObject)
		{
			var recyclableExtended = recyclableObject as IRecyclableExtended;
			if (recyclableExtended != null)
				return recyclableExtended.CheckAndFree();

			var recyclable = recyclableObject as IRecyclable;
			return recyclable != null && recyclable.TryFree();
		}

		/// <summary>
		/// Signalizes that provided <see cref="IRecyclableExtended"/> is not used and can be recycled.
		/// </summary>
		/// <param name="recyclableObject">A <see cref="IRecyclable"/> object that is not used and ready for recycling.</param>
		/// <returns>true if provided object is successfully recycled; otherwise, false.</returns>
		/// <exception cref="InvalidOperationException">
		/// <p>If <paramref name="recyclableObject"/> is already in recycle factory.</p>
		/// <p>If <paramref name="recyclableObject"/> has undefined source recycle factory.</p>
		/// </exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean CheckAndFree(this IRecyclableExtended recyclableObject)
		{
			if (!recyclableObject.CanRecycle)
				return false;

			recyclableObject.Free();

			return true;
		}

		/// <summary>
		/// Checks that <paramref name="recyclable"/> is ready for recycling.
		/// </summary>
		/// <param name="recyclable">A <see cref="IRecyclable"/> object that is not used and ready for recycling.</param>
		/// <param name="suppressExceptions">A <see cref="Boolean"/> value indicating whether to return null instead of throwing an exception. Default value is false.</param>
		/// <returns>The provided <paramref name="recyclable"/> if it passes validation; otherwise, null.</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="recyclable"/> is null.</exception>
		/// <exception cref="InvalidOperationException">
		/// <p>If <paramref name="recyclable"/> is already in recycle factory.</p>
		/// <p>If <paramref name="recyclable"/> has undefined source recycle factory.</p>
		/// </exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static IRecycleFactory VerifyAndGetFactory(this IRecyclable recyclable, Boolean suppressExceptions = false)
		{
			if (recyclable == null)
			{
				if (suppressExceptions)
					return null;

				throw new ArgumentNullException("recyclable");
			}

			if (recyclable.IsInFactory)
			{
				if (suppressExceptions)
					return null;

				throw new InvalidOperationException("Cannot use object that is currently inside recycle factory.");
			}

			var sourceFactory = recyclable.SourceFactory;
			if (sourceFactory == null)
			{
				if (suppressExceptions)
					return null;

				throw new InvalidOperationException("Cannot recycle object that does not have associated factory.");
			}

			return sourceFactory;
		}
	}
}