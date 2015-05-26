using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Eco.Collections.Generic.Limited;
using Eco.Objects;

#if PERFORMANCE_DEBUG
using System.Threading;
#endif

namespace Eco.Recycling
{
	/// <summary>
	/// Represents a factory that produces  objects and reuse them if possible to decrease memory consumption.
	/// </summary>
	/// <typeparam name="TRecyclable">The type of recyclable object that can be recycled by current factory.</typeparam>
	/// <remarks>This factory is thread-safe.</remarks>
	public abstract class RecycleFactory<TRecyclable> : IRecycleFactory where TRecyclable : class, IRecyclable
	{
		#region Fields

		/// <summary>
		/// The stack of objects which are ready for reuse.
		/// Note: Stack provides most "fresh" objects and reduces working memory size.
		/// </summary>
		private readonly LimitedCollection<TRecyclable> _recyclables;

#if PERFORMANCE_DEBUG

		/// <summary>
		/// The number of created elements.
		/// </summary>
		private Int32 _createdCount;

		/// <summary>
		/// The number of recycled elements (elements returned from <see cref="_recyclables"/>).
		/// </summary>
		private Int32 _recycledCount;

		/// <summary>
		/// The number of elements that did not be recycled cause recycle factory is full.
		/// </summary>
		private Int32 _missedItems;

#endif

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance of the <see cref="RecycleFactory{T}"/> class with specific collection that stores recycled items.
		/// </summary>
		/// <param name="collection">A limited collection that stores recyclable elements.</param>
		protected RecycleFactory(LimitedCollection<TRecyclable> collection)
		{
			_recyclables = collection;

			Capacity = RecycleFactorySettings.DefaultCapacity;
			
			Debug.Assert(Capacity > 0, "Undefined capacity for recycle factory");
		}

		/// <summary>
		/// Creates a new instance of the <see cref="RecycleFactory{T}"/> class with specific storing policy.
		/// </summary>
		/// <param name="storagePolicy">A storing policy for recycled items.</param>
		protected RecycleFactory(StoragePolicy storagePolicy)
		{
			var capacity = RecycleFactorySettings.DefaultCapacity;
			switch (storagePolicy)
			{
				case StoragePolicy.NonConcurrent:
					_recyclables = new UnsafeLimitedCollection<TRecyclable>();
					break;

				case StoragePolicy.Concurrent:
					_recyclables = new ConcurrentLimitedCollection<TRecyclable>();
					break;

				case StoragePolicy.ThreadStatic:
					_recyclables = new ThreadStaticLimitedCollection<TRecyclable>();
					break;

				case StoragePolicy.ThreadStaticBalanced:
					_recyclables = new ThreadStaticBalancedLimitedCollection<TRecyclable>(0.25f);
					break;

				case StoragePolicy.ThreadStaticGroupBalanced:
					const Int32 capacityLimit = ThreadStaticGroupBalancedLimitedCollection<TRecyclable>.BagSize * 2;
					capacity = capacity <= capacityLimit
						? capacity + capacityLimit
						: capacity;

					_recyclables = new ThreadStaticGroupBalancedLimitedCollection<TRecyclable>(capacity, 0.25f);
					break;

				default:
					throw new InvalidOperationException("Cannot create recycle factory. Unknown storing policy is provided to recycle factory constructor.");
			}

			Capacity = capacity;

			Debug.Assert(Capacity > 0, "Undefined capacity for recycle factory");
		}

		#endregion

		/// <summary>
		/// Gets or sets the maximal amount of stored recycled objects which are ready to use.
		/// </summary>
		public Int32 Capacity
		{
			get { return _recyclables.Capacity; }
			set { _recyclables.Capacity = value; }
		}

		#region Metrics

#if PERFORMANCE_DEBUG

		/// <summary>
		/// Gets the <see cref="Double"/> value indicating the ratio between the <see cref="RecycledCount"/> and amount of all items returned by current <see cref="RecycleFactory{T}"/>.
		/// </summary>
		/// <remarks>Supposed to be used for debug and profiling</remarks>
		public Double Efficiency
		{
			get
			{
				var producedCount = RecycledCount + CreatedCount;
				return producedCount == 0
					? 0
					: Math.Round(100 * (Double)RecycledCount / producedCount);
			}
		}

		/// <summary>
		/// Gets the number of elements created by <see cref="RecycleFactory{T}"/>.
		/// </summary>
		public Int32 CreatedCount
		{
			get { return _createdCount; }
		}

		/// <summary>
		/// Gets the number of elements recycled (reused) by <see cref="RecycleFactory{T}"/>.
		/// </summary>
		public Int32 RecycledCount
		{
			get { return _recycledCount; }
		}

		/// <summary>
		/// Gets the number of elements that did not be recycled cause recycle factory is full.
		/// </summary>
		public Int32 MissedCount
		{
			get { return _missedItems; }
		}

#endif

		/// <summary>
		/// Gets the number of elements stored in the <see cref="RecycleFactory{T}"/> and ready for usage.
		/// The result value can be different for different calling threads.
		/// </summary>
		public Int32 Count
		{
			get { return _recyclables.Count; }
		}

		#endregion

		#region Items creation

		/// <summary>
		/// Creates a new reusable item.
		/// </summary>
		/// <returns>The <typeparamref name="TRecyclable"/> item initialized by the factory.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public TRecyclable Create()
		{
			return CreateInternal();
		}

		/// <summary>
		/// Creates a new reusable item.
		/// </summary>
		/// <returns>The item initialized by the factory.</returns>
		protected TRecyclable CreateInternal()
		{
			TRecyclable result;

			if (_recyclables.TryTake(out result))
			{
#if PERFORMANCE_DEBUG
				Interlocked.Increment(ref _recycledCount);
#endif
				result.Resolve();
			}
			else
			{
#if PERFORMANCE_DEBUG
				Interlocked.Increment(ref _createdCount);
#endif
				result = InitializeRecyclable();
				result.SetSourceFactory(this);
			}

			return result;
		}

		/// <summary>
		/// Creates the new one or gets the instance of the <see cref="IRecyclable"/> item from factory.
		/// </summary>
		/// <returns>The recyclable item.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		IRecyclable IRecycleFactory.Create()
		{
			return Create();
		}

		/// <summary>
		/// Creates a new instance of class. When overridden in descendant class provides custom initialization.
		/// </summary>
		/// <remarks>Not intended to be called from derived type code.</remarks>
		/// <returns>The instance of recyclable.</returns>
		protected abstract TRecyclable InitializeRecyclable();

		#endregion

		#region Recycling

		/// <summary>
		/// Recycles provided <paramref name="recyclable"/> object.
		/// </summary>
		/// <param name="recyclable">A not used object.</param>
		/// <exception cref="ArgumentNullException">If the <paramref name="recyclable"/> is null.</exception>
		/// <exception cref="ArgumentException">If the <see cref="IRecyclable.SourceFactory"/> of <paramref name="recyclable"/> not equals to current factory.</exception>
		private void Recycle(TRecyclable recyclable)
		{
			recyclable.ThrowIfNull();

			if (!ReferenceEquals(recyclable.SourceFactory, this))
				throw new ArgumentException(@"Source factory of recycling object not equals to current factory", "recyclable");

			recyclable.Cleanup();
#if PERFORMANCE_DEBUG
			if (!_recyclables.TryPut(recyclable))
				Interlocked.Increment(ref _missedItems);
#else
			_recyclables.TryPut(recyclable);
#endif
		}

		/// <summary>
		/// Recycles provided <paramref name="recyclable"/> object.
		/// </summary>
		/// <param name="recyclable">A not used object.</param>
		/// <exception cref="InvalidCastException">If provided <paramref name="recyclable"/> cannot be converted to <see cref="IRecyclable"/>.</exception>
		/// <exception cref="ArgumentNullException">If the <paramref name="recyclable"/> is null.</exception>
		/// <exception cref="ArgumentException">If the <see cref="IRecyclable.SourceFactory"/> of <paramref name="recyclable"/> not equals to current factory.</exception>	
		void IRecycleFactory.Recycle(Object recyclable)
		{
			Recycle((TRecyclable)recyclable);
		}

		#endregion
	}
}