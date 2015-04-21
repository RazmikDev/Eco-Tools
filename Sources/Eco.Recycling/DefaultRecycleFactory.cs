using Eco.Collections.Generic.Limited;

namespace Eco.Recycling
{
	/// <summary>
	/// Represents a factory that produces <see cref="IRecyclable"/> objects and reuse them if possible to decrease memory consumption.
	/// </summary>
	/// <typeparam name="TRecyclable">The type of the <see cref="IRecyclable"/> object which is produced by current factory.</typeparam>
	public class DefaultRecycleFactory<TRecyclable> : RecycleFactory<TRecyclable> where TRecyclable : class, IRecyclable, new()
	{
		#region Constructors

		/// <summary>
		/// Creates a new instance of the <see cref="DefaultRecycleFactory{T}"/> class with specific collection that stores recycled items.
		/// </summary>
		/// <param name="collection">A limited collection that stores recyclable elements.</param>
		public DefaultRecycleFactory(LimitedCollection<TRecyclable> collection)
			: base(collection)
		{
		}

		/// <summary>
		/// Creates a new instance of the <see cref="DefaultRecycleFactory{T}"/> class with specific storing policy.
		/// </summary>
		/// <param name="storagePolicy">A storing policy for recycled items.</param>
		public DefaultRecycleFactory(StoragePolicy storagePolicy)
			: base(storagePolicy)
		{
		}

		#endregion

		/// <summary>
		/// Creates a new instance of <typeparamref name="TRecyclable"/> class. When overridden in descendant class provides custom initialization.
		/// </summary>
		/// <returns>The instance of <typeparamref name="TRecyclable"/> class.</returns>
		protected override TRecyclable InitializeRecyclable()
		{
			return new TRecyclable();
		}
	}
}