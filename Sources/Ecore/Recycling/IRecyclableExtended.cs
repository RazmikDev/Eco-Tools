using System;

namespace Eco.Recycling
{
	/// <summary>
	/// Represents a recyclable object that can be reused many times and can indicate whether it is claimed by other object to prevent unintended recycling.
	/// </summary>
	public interface IRecyclableExtended : IRecyclable
	{
		/// <summary>
		/// Gets the <see cref="Boolean"/> value indicating whether the current object is in correct state to be recycled.
		/// </summary>
		Boolean CanRecycle { get; }

		/// <summary>
		/// Marks current object as used to prevent unnecessary recycling.
		/// </summary>
		void SuppressRecycling();

		/// <summary>
		/// Signalizes current object as not used any more by calling code.
		/// </summary>
		void ResumeRecycling();
	}
}