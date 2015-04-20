using System;
using System.Collections.Generic;
using Eco.Objects;

namespace Eco.Recycling.Collections
{
	/// <summary>
	/// Represents <see cref="Stack{T}"/> that can be reused.
	/// </summary>
	/// <typeparam name="TItem">The type of items to store.</typeparam>
	public class RecyclableStack<TItem> : Stack<TItem>, IRecyclable
	{
		#region Fields

		/// <summary>
		/// The  recycle factory that creates and recycles the <see cref="RecyclableStack{TItem}"/> objects withing current thread.
		/// </summary>
		public static readonly RecycleFactory<RecyclableStack<TItem>> CurrentThreadFactory;

		/// <summary>
		/// The global recycle factory that creates and recycles the <see cref="RecyclableStack{TItem}"/> objects.
		/// </summary>
		public static readonly RecycleFactory<RecyclableStack<TItem>> Factory;

		/// <summary>
		/// The backing field for the <see cref="IRecyclable.SourceFactory"/> property.
		/// </summary>
		private IRecycleFactory _sourceFactory;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a type instance of the <see cref="RecyclableStack{TItem}"/> class.
		/// </summary>
		static RecyclableStack()
		{
			CurrentThreadFactory = new DefaultRecycleFactory<RecyclableStack<TItem>>(StoragePolicy.ThreadStatic);  // Performance critical. Carefully change the storage policy.
			Factory = new DefaultRecycleFactory<RecyclableStack<TItem>>(StoragePolicy.Concurrent);  // Performance critical. Carefully change the storage policy.
		}

		/// <summary>
		/// Initializes new instance of the <see cref="RecyclableStack{T}"/> class.
		/// </summary>
		public RecyclableStack()
		{
			RecycleItems = true;
		}

		#endregion

		/// <summary>
		/// Gets or sets the <see cref="Boolean"/> value indicating whether stored items needs to be recycled (if they supports recycling) when whole collection is recycled.
		/// </summary>
		public Boolean RecycleItems { get; set; }

		#region IRecyclable interface implementation

		/// <summary>
		/// Gets the source <see cref="IRecycleFactory"/> that produces and recycles current <see cref="IRecyclable"/>.
		/// </summary>
		IRecycleFactory IRecyclable.SourceFactory
		{
			get { return _sourceFactory; }
		}

		/// <summary>
		/// Gets the <see cref="Boolean"/> value indicating whether the object is currently inside factory.
		/// </summary>
		public Boolean IsInFactory { get; private set; }

		/// <summary>
		/// Sets the source <see cref="IRecycleFactory"/> that produced and recycles current <see cref="IRecyclable"/>.
		/// </summary>
		/// <param name="factory">An <see cref="IRecycleFactory"/> that recycles current object.</param>
		void IRecyclable.SetSourceFactory(IRecycleFactory factory)
		{
			_sourceFactory = factory.ThrowIfNull();
		}

		/// <summary>
		/// Executes required operations for <see cref="IRecyclable"/> when it has been resolved from factory.
		/// </summary>
		void IRecyclable.Resolve()
		{
			IsInFactory = false;
		}

		/// <summary>
		/// Cleans the state of the current object to prepare it for recycle.
		/// </summary>
		void IRecyclable.Cleanup()
		{
			IsInFactory = true;

			if (RecycleItems && !typeof(TItem).IsValueType)
			{
				foreach (var item in this)
				{
					var recyclableItem = item as IRecyclable;
					if (recyclableItem == null)
						continue;

					if (recyclableItem.SourceFactory == null)
						continue;

					recyclableItem.TryFree();
				}
			}
			else
			{
				RecycleItems = true;
			}

			Clear();
		}

		#endregion
	}
}