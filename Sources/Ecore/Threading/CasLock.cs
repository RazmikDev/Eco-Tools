using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Eco.Threading
{
	/// <summary>
	/// Provides methods to take locks on <see cref="Int32"/> values using CAS operation.
	/// </summary>
	public static class CasLock
	{
		/// <summary>
		/// Attempts to set a user-mode lock on provided integer value <paramref name="lockValue"/> using CAS operation.
		/// </summary>
		/// <param name="lockValue">An <see cref="Int32"/> value that indicates the lock state (<c>1</c> - lock is set, <c>0</c> - lock is not set).</param> 
		/// <returns><c>true</c> if <paramref name="lockValue"/> is locked successfully and <paramref name="lockValue"/> is set to <c>1</c>; otherwise, <c>false</c>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean TryLock(ref Int32 lockValue)
		{
			if (lockValue == 1) // fast read
				return false;

			return Interlocked.CompareExchange(ref lockValue, 1, 0) == 0;
		}

		/// <summary>
		/// Tries to set a user-mode lock on provided integer value <paramref name="lockValue"/> in specified <paramref name="millisecondsTimeout"/> using CAS operation.
		/// </summary>
		/// <param name="lockValue">An <see cref="Int32"/> value that indicates the lock state (<c>1</c> - lock is set, <c>0</c> - lock is not set).</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="Timeout.Infinite"/> (-1) to wait indefinitely.</param>
		/// <returns><c>true</c> if <paramref name="lockValue"/> is locked successfully and <paramref name="lockValue"/> is set to <c>1</c>; otherwise, <c>false</c>.</returns>
		public static Boolean Lock(ref Int32 lockValue, Int32 millisecondsTimeout = Timeout.Infinite)
		{
			var timeoutIsInfinite = millisecondsTimeout == Timeout.Infinite;

			if (millisecondsTimeout < 0 && !timeoutIsInfinite)
				throw new ArgumentOutOfRangeException("millisecondsTimeout");

			// If lock is taken at first attempt returns true without spinning.
			if (TryLock(ref lockValue))
				return true;

			// If lock is not taken at first attempt and timeout is 0 - returns false.
			if (millisecondsTimeout == 0)
				return false;

			// Capture current ticks count if timeout is not 0 and not infinite.
			Int64 startTicks = 0;
			if (millisecondsTimeout != 0 && !timeoutIsInfinite)
				startTicks = DateTime.UtcNow.Ticks;

			// Starts spinning
			var spinner = new SpinWait();
			while (!TryLock(ref lockValue))
			{
				spinner.SpinOnce();

				// Skips elapsed time check if timeout is infinite or next spin will trigger a forced context switch.
				if (timeoutIsInfinite || !spinner.NextSpinWillYield)
					continue;

				// If timeout exceeded returns false.
				if (millisecondsTimeout <= (DateTime.UtcNow.Ticks - startTicks) / TimeSpan.TicksPerMillisecond)
					return false;
			}

			return true;
		}

		/// <summary>
		/// Releases the user-mode lock on provided integer value <paramref name="lockValue"/> using CAS operation.
		/// </summary>
		/// <param name="lockValue">An object to unlock.</param>
		/// <exception cref="ArgumentException">If <paramref name="lockValue"/> not equals to <c>1</c>.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Release(ref Int32 lockValue)
		{
			if (Interlocked.CompareExchange(ref lockValue, 0, 1) != 1)
				throw new ArgumentException("Cannot release not locked or unacceptable integer lock value");
		}
	}
}
