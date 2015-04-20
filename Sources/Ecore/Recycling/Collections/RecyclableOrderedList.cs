using System;
using Eco.Collections.Generic;
using Eco.Reflection;

namespace Eco.Recycling.Collections
{
	/// <summary>
	/// Represents an array that keeps elements in sorted manner.
	/// </summary>
	/// <typeparam name="TItem">The type of the items.</typeparam>
	internal class RecyclableOrderedList<TItem> : OrderedList<TItem>, IRecyclable
		where TItem : IComparable<TItem>
	{
		#region Fields

		/// <summary>
		/// The recycle factory that creates and recycles the <see cref="RecyclableOrderedList{TItem}"/> objects withing current thread.
		/// </summary>
		public static readonly RecycleFactory<RecyclableOrderedList<TItem>> CurrentThreadFactory;

		/// <summary>
		/// The global recycle factory that creates and recycles the <see cref="RecyclableOrderedList{TItem}"/> objects.
		/// </summary>
		public static readonly RecycleFactory<RecyclableOrderedList<TItem>> Factory;

		/// <summary>
		/// The owner factory of the object.
		/// </summary>
		private IRecycleFactory _sourceFactory;

		#endregion

		/// <summary>
		/// Creates a type instance of the <see cref="RecyclableOrderedList{TItem}"/> class.
		/// </summary>
		static RecyclableOrderedList()
		{
			CurrentThreadFactory = new DefaultRecycleFactory<RecyclableOrderedList<TItem>>(StoragePolicy.ThreadStatic);
			Factory = new DefaultRecycleFactory<RecyclableOrderedList<TItem>>(StoragePolicy.Concurrent);
		}

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
			_sourceFactory = factory;
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

			if (RecycleItems && !Type<TItem>.IsValueType)
			{
				// ReSharper disable once LoopCanBePartlyConvertedToQuery
				foreach (var item in this)
				{
					// ReSharper disable once SuspiciousTypeConversion.Global
					// ReSharper disable once ExpressionIsAlwaysNull
					var recyclableItem = item as IRecyclable;
					// ReSharper disable once ConditionIsAlwaysTrueOrFalse
					if (recyclableItem == null)
						continue;

					if (recyclableItem.SourceFactory == null)
						continue;

					recyclableItem.TryFree();
				}

				RecycleItems = false;
			}

			Clear();
		}

		#endregion
	}
}