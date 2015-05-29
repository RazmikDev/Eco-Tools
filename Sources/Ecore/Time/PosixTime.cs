using System;
using System.Runtime.CompilerServices;

namespace Eco.Time
{
	/// <summary>
	/// Provides methods that helps converting <see cref="DateTime"/> structure to POSIX-based format. 
	/// </summary>
	public static class PosixTime
	{
		/// <summary>
		/// Start time for calculating Epoch time (1970-01-01 00:00:00).
		/// </summary>
		private static readonly DateTime EpochStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

		/// <summary>
		/// Returns a <see cref="Double"/> value that represents the date and time in POSIX format.
		/// </summary>
		/// <param name="dateTime">A date and time.</param>
		/// <returns>The POSIX-based time (total amount of seconds passed since 0:00 1.1.1970).</returns>

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double ToPosixSeconds(this DateTime dateTime)
		{
			return (dateTime - EpochStartTime).TotalSeconds;
		}

		/// <summary>
		/// Returns a <see cref="Double"/> value that represents the date and time in POSIX format.
		/// </summary>
		/// <param name="dateTime">A source date and time.</param>
		/// <returns>The POSIX-based time (total amount of seconds passed since 0:00 1.1.1970).</returns>	
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double ToPosixMilliseconds(this DateTime dateTime)
		{
			return (dateTime - EpochStartTime).TotalMilliseconds;
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> value that represents the date and time in POSIX format.
		/// </summary>
		/// <param name="dateTime">A source date and time.</param>
		/// <returns>The POSIX-based time span (total amount of seconds passed since 0:00 1.1.1970).</returns>	
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TimeSpan ToPosixTimeSpan(this DateTime dateTime)
		{
			return dateTime - EpochStartTime;
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> value that represents the date and time in POSIX format or null.
		/// </summary>
		/// <param name="dateTime">A source date and time.</param>
		/// <returns>The POSIX-based time span (total amount of seconds passed since 0:00 1.1.1970) if passed date has value; otherwise null.</returns>	
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TimeSpan? ToPosixTimeSpan(this DateTime? dateTime)
		{
			if (!dateTime.HasValue)
				return null;

			return dateTime.Value - EpochStartTime;
		}

		/// <summary>
		/// Returns a <see cref="DateTime"/> value that represents the date and time.
		/// </summary>
		/// <param name="timestamp">A POSIX-based time (total amount of seconds passed since 0:00 1.1.1970).</param>
		/// <returns>The <see cref="DateTime"/> converted from timestamp.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime ToDateTime(this Double timestamp)
		{
			return EpochStartTime.AddSeconds(timestamp);
		}
	}
}