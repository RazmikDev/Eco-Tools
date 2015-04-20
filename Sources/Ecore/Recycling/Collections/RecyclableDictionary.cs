using System;
using System.Collections.Generic;
using Eco.Objects;
using Eco.Reflection;

namespace Eco.Recycling.Collections
{
	/// <summary>
	/// Represents <see cref="Dictionary{TKey,TValue}"/> that supports cascade recycling of itself and all children.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	public class RecyclableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IRecyclable
	{
		#region Fields

		/// <summary>
		/// The  recycle factory that creates and recycles the <see cref="RecyclableDictionary{TKey,TValue}"/> objects withing current thread.
		/// </summary>
		public static readonly RecycleFactory<RecyclableDictionary<TKey, TValue>> CurrentThreadFactory;

		/// <summary>
		/// The global recycle factory that creates and recycles the <see cref="RecyclableDictionary{TKey,TValue}"/> objects.
		/// </summary>
		public static readonly RecycleFactory<RecyclableDictionary<TKey, TValue>> Factory;

		/// <summary>
		/// The backing field for the <see cref="IRecyclable.SourceFactory"/> property.
		/// </summary>
		private IRecycleFactory _sourceFactory;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a type instance of the <see cref="RecyclableDictionary{TKey,TValue}"/> class.
		/// </summary>
		static RecyclableDictionary()
		{
			CurrentThreadFactory = new DefaultRecycleFactory<RecyclableDictionary<TKey, TValue>>(StoragePolicy.ThreadStatic);
			Factory = new DefaultRecycleFactory<RecyclableDictionary<TKey, TValue>>(StoragePolicy.Concurrent);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RecyclableDictionary{TKey, TValue}"/> class.
		/// </summary>
		public RecyclableDictionary()
		{
			RecycleItems = true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RecyclableDictionary{TKey, TValue}"/> class with <paramref name="comparer"/>.
		/// </summary>
		/// <param name="comparer">An instance of the <see cref="IEqualityComparer{TKey}"/> class that provides rules to compare <typeparamref name="TKey"/>.</param>
		public RecyclableDictionary(IEqualityComparer<TKey> comparer)
			: base(comparer)
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
			if (IsInFactory)
				throw new InvalidOperationException("Cannot use object that is currently inside recycle factory.");

			IsInFactory = true;

			if (RecycleItems && !Type<TValue>.IsValueType)
			{
				// ReSharper disable once LoopCanBePartlyConvertedToQuery
				foreach (var keyValuePair in this)
				{
					var recyclableKey = keyValuePair.Key as IRecyclable;
					if (recyclableKey != null && recyclableKey.SourceFactory != null)
						recyclableKey.TryFree();

					var recyclableValue = keyValuePair.Value as IRecyclable;
					if (recyclableValue != null && recyclableValue.SourceFactory != null)
						recyclableValue.TryFree();
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