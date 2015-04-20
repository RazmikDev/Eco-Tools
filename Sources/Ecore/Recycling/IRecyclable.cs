using System;

namespace Eco.Recycling
{
	/// <summary>
	/// Represents a recyclable object that can be reused many times.
	/// </summary>
	public interface IRecyclable
	{
		/// <summary>
		/// Gets the source <see cref="IRecycleFactory"/> that produces and recycles current <see cref="IRecyclable"/>.
		/// </summary>
		IRecycleFactory SourceFactory { get; }

		/// <summary>
		/// Gets the <see cref="Boolean"/> value indicating whether the object is currently inside factory.
		/// </summary>
		Boolean IsInFactory { get; }

		/// <summary>
		/// Executes required operations for <see cref="IRecyclable"/> when it has been resolved from factory.
		/// </summary>
		void Resolve();

		/// <summary>
		/// Cleans the state of the current object to prepare it for recycle.
		/// </summary>
		void Cleanup();

		/// <summary>
		/// Sets the source <see cref="IRecycleFactory"/> that produced and recycles current <see cref="IRecyclable"/>.
		/// </summary>
		/// <param name="factory">An <see cref="IRecycleFactory"/> that recycles current object.</param>
		void SetSourceFactory(IRecycleFactory factory);
	}
}