using System;
using System.Runtime.CompilerServices;

namespace Eco.Time
{
	/// <summary>
	/// Provides methods that helps converting <see cref="DateTime"/> structure to File time format. 
	/// </summary>
	public static class FileTime
	{
		#region Fields

		/// <summary>
		/// The number of 100-nanoseconds intervals in second.
		/// </summary>
		private const Int32 FileTimeToSeconds = 10000000;

		#endregion

		/// <summary>
		/// Returns a <see cref="Int64"/> value that represents the number of seconds since 12:00 midnight, January 1, 1601 A.D. (C.E.) Coordinated Universal Time (UTC).
		/// </summary>
		/// <param name="dateTime">A source date and time.</param>
		/// <returns>The calculated number of seconds since 12:00 midnight, January 1, 1601 A.D. (C.E.) Coordinated Universal Time (UTC).</returns>	
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int64 ToFileTimeSeconds(this DateTime dateTime)
		{
			return dateTime.ToFileTimeUtc() / FileTimeToSeconds;
		}

		/// <summary>
		/// Returns a <see cref="DateTime"/> value that represents the time restored from the number of seconds since 12:00 midnight, January 1, 1601 A.D. (C.E.) Coordinated Universal Time (UTC).
		/// </summary>
		/// <param name="seconds">The number of seconds since 12:00 midnight, January 1, 1601 A.D. (C.E.) Coordinated Universal Time (UTC).</param>
		/// <returns>The <see cref="DateTime"/> value restored from file time.</returns>	
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime FromFileTimeSeconds(this Int64 seconds)
		{
			return DateTime.FromFileTimeUtc(seconds * FileTimeToSeconds);
		}
	}
}