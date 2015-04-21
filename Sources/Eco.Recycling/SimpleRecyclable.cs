using System;
using System.Runtime.CompilerServices;

namespace Eco.Recycling
{
	/// <summary>
	/// Represents a not thread-safe object that can be reused multiple times with recycle factory.
	/// </summary>
	public abstract class SimpleRecyclable : IRecyclableExtended
	{
		#region Fields

		/// <summary>
		/// The source recycle factory that produces current <see cref="SimpleRecyclable"/>.
		/// </summary>
		private IRecycleFactory _sourceFactory;

		/// <summary>
		/// The <see cref="Boolean"/> value indicating whether current object is stored in recycle factory.
		/// </summary>
		private Boolean _isInFactory;

		/// <summary>
		/// The <see cref="Int32"/> value indicating amount of recycling suppress requests.
		/// 0 value indicates that no external object  
		/// </summary>
		private Int32 _recyclingSuppressedCount;

		#endregion

		/// <summary>
		/// Gets the <see cref="Boolean"/> value indicating whether the current object is in correct state to be recycled.
		/// </summary>
		Boolean IRecyclableExtended.CanRecycle
		{
			get { return !_isInFactory && _recyclingSuppressedCount == 0 && CanBeRecycled(); }
		}

		#region Implementation of IRecyclable

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
		public Boolean IsInFactory
		{
			get { return _isInFactory; }
		}

		/// <summary>
		/// Executes required operations for <see cref="IRecyclable"/> when it has been resolved from factory.
		/// </summary>
		void IRecyclable.Resolve()
		{
			try
			{
				OnResolve();
			}
			finally
			{
				_isInFactory = false;
			}
		}

		/// <summary>
		/// Cleans the state of the current object to prepare it for recycle.
		/// </summary>
		void IRecyclable.Cleanup()
		{
			VerifyNotInFactory();

			try
			{
				OnCleanup();
			}
			finally
			{
				_isInFactory = true;
			}
		}

		/// <summary>
		/// Sets the source <see cref="IRecycleFactory"/> that produced and recycles current <see cref="IRecyclable"/>.
		/// </summary>
		/// <param name="factory">An <see cref="IRecycleFactory"/> that recycles current object.</param>
		void IRecyclable.SetSourceFactory(IRecycleFactory factory)
		{
			if (_sourceFactory != null)
				throw new InvalidOperationException("Cannot modify source recycle factory.");

			_sourceFactory = factory;
		}

		#endregion

		/// <summary>
		/// Verifies that current object is not already in recycle factory.
		/// </summary>
		/// <exception cref="InvalidOperationException">If current object is in recycle factory.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void VerifyNotInFactory()
		{
			if (_isInFactory)
				throw new InvalidOperationException("Cannot access recyclable object that is still in factory. Try to resolve item from recycle factory.");
		}

		/// <summary>
		/// Marks current object as used to prevent unnecessary recycling.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SuppressRecycling()
		{
			VerifyNotInFactory();
			++_recyclingSuppressedCount;
		}

		/// <summary>
		/// Signalizes current object as not used any more by calling code.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ResumeRecycling()
		{
			VerifyNotInFactory();
			if (_recyclingSuppressedCount == 0)
				throw new InvalidOperationException("Cannot resume recycling for object couse it was not suppressed.");

			--_recyclingSuppressedCount;
		}

		/// <summary>
		/// Cleans the state of the current object to prepare it to be recycled.
		/// </summary>
		protected abstract void OnCleanup();

		/// <summary>
		/// Called when current recyclable element is pushed out from recycle factory.
		/// </summary>
		protected virtual void OnResolve()
		{
		}

		/// <summary>
		/// Determines whether current object is in correct state to be recycled.
		/// </summary>
		/// <returns>true if current object can be recycled; otherwise, false.</returns>
		protected virtual Boolean CanBeRecycled()
		{
			return true;
		}
	}
}