using Eco.Collections.Generic.Limited;

namespace Eco.Recycling
{
	/// <summary>
	/// The policy that indicate how <see cref="RecycleFactory{TRecyclable}"/> .
	/// </summary>
	public enum StoragePolicy
	{
		/// <summary>
		/// The thread-unsafe storage mode. Most lightweight and fasted mode to store recycled elements.
		/// Error can occur if multiple thread try to access recycle factory at the same time.
		/// </summary>
		NonConcurrent,

		/// <summary>
		/// The concurrent storage mode. Recycle factory can be accessed from multiple threads safely.
		/// </summary>
		Concurrent,

		/// <summary>
		/// The thread static storage mode.
		/// In this mode recycle factory stores recycled items independently for each thread and can be accessed from multiple threads safely without contentions.
		/// Ensure that only fixed number of threads can access recycle factory to avoid potential memory leaks.
		/// </summary>
		ThreadStatic,

		/// <summary>
		/// The thread-static collection that stores a limited number of items within each thread and equalizes utilization between threads.
		/// In this mode recycle factory stores recycled items independently for each thread. If capacity of thread-specific storage is exceeded 
		/// recycle factory uses special common global storage to store recycled item. The common global storage is also used to return recycled item
		/// when thread-specific storage is empty.
		/// Ensure that only fixed number of threads can access recycle factory to avoid potential memory leaks.
		/// </summary>
		ThreadStaticBalanced,

		/// <summary>
		/// The thread-static collection that stores a limited number of items within each thread and equalizes utilization between threads using groups of items.
		/// Supports only 'insert' and 'take' operation.
		/// Contrary the name the total amount of stored items is unlimited because of the common buffer between threads which is unlimited.
		/// The amount of items stored for each thread is limited by <see cref="LimitedCollection{T}.Capacity"/> excluding investments of capacity to common buffer.
		/// Ensure that only fixed number of threads can access recycle factory to avoid potential memory leaks.
		/// </summary>
		ThreadStaticGroupBalanced
	}
}