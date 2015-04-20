using System;

namespace Eco.Recycling
{
	/// <summary>
	/// Represents a factory that produces <see cref="IRecyclable"/> objects with specified creation method.
	/// </summary>
	/// <typeparam name="TRecyclable">The type of the <see cref="IRecyclable"/> object which is produced by current factory.</typeparam>
	public class GenericRecycleFactory<TRecyclable> : RecycleFactory<TRecyclable> where TRecyclable : class, IRecyclable
	{
		/// <summary>
		/// The delegate that can create instances of <typeparamref name="TRecyclable"/> class.
		/// </summary>
		/// <remarks>To call constructor with parameters.</remarks>
		private readonly Func<TRecyclable> _createRecyclableFunction;

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericRecycleFactory{TRecyclable}"/> class.
		/// </summary>
		/// <param name="createRecyclableFunction">The delegate that can create the items.</param>
		/// <param name="storagePolicy">A storing policy for recycled items.</param>
		public GenericRecycleFactory(Func<TRecyclable> createRecyclableFunction, StoragePolicy storagePolicy)
			: base(storagePolicy)
		{
			_createRecyclableFunction = createRecyclableFunction;
		}

		/// <summary>
		/// Creates a new instance of <typeparamref name="TRecyclable"/> class. When overridden in descendant class provides custom initialization.
		/// </summary>
		/// <returns>The instance of <typeparamref name="TRecyclable"/> class.</returns>
		protected override TRecyclable InitializeRecyclable()
		{
			return _createRecyclableFunction();
		}
	}
}