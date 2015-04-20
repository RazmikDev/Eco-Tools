using System;

namespace Eco.Recycling
{
	/// <summary>
	/// Represents an object factory that accepts created object back for further reusage.
	/// </summary>
	public interface IRecycleFactory
	{
		/// <summary>
		/// Gets or sets the maximal amount of stored recycled objects which are ready to use.
		/// </summary>
		Int32 Capacity { get; set; }

		/// <summary>
		/// Creates the new one or gets the instance of the <see cref="IRecyclable"/> item from factory.
		/// </summary>
		/// <returns>The recyclable item.</returns>
		IRecyclable Create();

		/// <summary>
		/// Recycles provided <paramref name="recyclable"/> object.
		/// </summary>
		/// <param name="recyclable">A not used object.</param>
		void Recycle(Object recyclable);
	}
}