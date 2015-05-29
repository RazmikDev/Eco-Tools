using System;
using System.Runtime.CompilerServices;

namespace Eco.Time
{
	/// <summary>
	/// Provides methods that helps manipulating with <see cref="DateTime"/> structures.
	/// </summary>
	public static class Time
	{
		/// <summary>
		/// Rounds the <paramref name="dateTime"/> value to a nearest <see cref="DateTime"/> with a integral amount of passed <paramref name="milliseconds"/>.
		/// </summary>
		/// <param name="dateTime">A source date and time.</param>
		/// <param name="milliseconds">A number of milliseconds which integral times includes in returned <see cref="DateTime"/>.</param>
		/// <returns>The rounded <see cref="DateTime"/> number divisible by <paramref name="milliseconds"/> evenly.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime Round(this DateTime dateTime, Int32 milliseconds)
		{
			var tail = dateTime.Subtract(DateTime.MinValue).TotalMilliseconds % milliseconds;
			return dateTime.AddMilliseconds(tail / milliseconds >= 0.5 ? milliseconds - tail : -tail);
		}

		/// <summary>
		/// Compares the two <see cref="DateTime"/> objects with specified accuracy.
		/// </summary>
		/// <param name="currentDateTime">The current <see cref="DateTime"/>.</param>
		/// <param name="otherDateTime">The other <see cref="DateTime"/>.</param>
		/// <param name="millisecondsAccuracy">A comparison accuracy in milliseconds.</param>
		/// <returns>true if <paramref name="currentDateTime"/> equals to <paramref name="otherDateTime"/> with <paramref name="millisecondsAccuracy"/> accuracy.</returns>
		/// <exception cref="ArgumentOutOfRangeException">If <paramref name="millisecondsAccuracy"/> is less than 0.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 CompareTo(this DateTime currentDateTime, DateTime otherDateTime, Int32 millisecondsAccuracy)
		{
			if (millisecondsAccuracy < 0)
				throw new ArgumentOutOfRangeException("millisecondsAccuracy");

			var difference = currentDateTime - otherDateTime;
			return Math.Abs(difference.TotalMilliseconds) <= millisecondsAccuracy
				? 0
				: Math.Sign(difference.TotalMilliseconds);
		}

		/// <summary>
		/// Returns a value indicating whether two moments in time ere close with specified accuracy.
		/// </summary>
		/// <param name="currentDateTime">A current <see cref="DateTime"/>.</param>
		/// <param name="otherDateTime">An other <see cref="DateTime"/> to compare.</param>
		/// <param name="millisecondsAccuracy">A maximal interval in milliseconds that defines time equality.</param>
		/// <returns>true if interval between <paramref name="currentDateTime"/> and <paramref name="otherDateTime"/> is less than <paramref name="millisecondsAccuracy"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Equals(this DateTime currentDateTime, DateTime otherDateTime, Int32 millisecondsAccuracy)
		{
			return currentDateTime.CompareTo(otherDateTime, millisecondsAccuracy) == 0;
		}
	}
}