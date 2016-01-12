using System;
using System.Collections;
using System.Collections.Generic;

namespace Eco.Collections.Generic.Fixed
{
	/// <summary>
	/// Represents a value type collection with fixed capacity equal to 4.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct List4<T> : IEnumerable<T>
	{
		private const Int32 MaxIndex = 4 - 1;

		#region Fields

		private Bunch4<T> _innerArray;

		private Int32 _count;

		#endregion

		private Int32 LastItemIndex
		{
			get { return _count - 1; }
		}

		public T this[Int32 index]
		{
			get
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				return _innerArray[index];
			}
			set
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				_innerArray[index] = value;
			}
		}

		public Int32 Count
		{
			get { return _count; }
		}

		public Int32 Capacity
		{
			get { return 4; }
		}

		public void Add(T item)
		{
			Insert(LastItemIndex + 1, item);
		}

		public void Insert(Int32 index, T item)
		{
			if (_count == _innerArray.Length)
				throw new OutOfCapacityException();

			if (index < 0 || index > MaxIndex)
				throw new ArgumentOutOfRangeException("index");

			for (var i = LastItemIndex; i >= index; --i)
				_innerArray[i + 1] = _innerArray[i];

			_innerArray[index] = item;
			++_count;
		}

		public void RemoveAt(Int32 index)
		{
			if (index >= _innerArray.Length)
				throw new ArgumentOutOfRangeException("index");

			for (var i = index; i <= LastItemIndex; ++i)
				_innerArray[i] = _innerArray[+1];
		}

		public void Clear()
		{
			for (var i = 0; i <= LastItemIndex; i++)
				_innerArray[i] = default(T);

			_count = 0;
		}

		#region Enumeration

		/// <summary>
		/// Returns an enumerator that iterates through the bunch.
		/// </summary>
		/// <returns>An <see cref="Enumerator"/> that can be used to iterate through the bunch.</returns>
		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region Enumerator

		public struct Enumerator : IEnumerator<T>
		{
			#region Fields

			private readonly List4<T> _list;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(List4<T> list)
			{
				_list = list;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _list.Count;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _list[_currentIndex];
				}
			}

			object IEnumerator.Current
			{
				get { return Current; }
			}

			public void Dispose()
			{
			}
		}

		#endregion

		#endregion
	}
	/// <summary>
	/// Represents a value type collection with fixed capacity equal to 8.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct List8<T> : IEnumerable<T>
	{
		private const Int32 MaxIndex = 8 - 1;

		#region Fields

		private Bunch8<T> _innerArray;

		private Int32 _count;

		#endregion

		private Int32 LastItemIndex
		{
			get { return _count - 1; }
		}

		public T this[Int32 index]
		{
			get
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				return _innerArray[index];
			}
			set
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				_innerArray[index] = value;
			}
		}

		public Int32 Count
		{
			get { return _count; }
		}

		public Int32 Capacity
		{
			get { return 8; }
		}

		public void Add(T item)
		{
			Insert(LastItemIndex + 1, item);
		}

		public void Insert(Int32 index, T item)
		{
			if (_count == _innerArray.Length)
				throw new OutOfCapacityException();

			if (index < 0 || index > MaxIndex)
				throw new ArgumentOutOfRangeException("index");

			for (var i = LastItemIndex; i >= index; --i)
				_innerArray[i + 1] = _innerArray[i];

			_innerArray[index] = item;
			++_count;
		}

		public void RemoveAt(Int32 index)
		{
			if (index >= _innerArray.Length)
				throw new ArgumentOutOfRangeException("index");

			for (var i = index; i <= LastItemIndex; ++i)
				_innerArray[i] = _innerArray[+1];
		}

		public void Clear()
		{
			for (var i = 0; i <= LastItemIndex; i++)
				_innerArray[i] = default(T);

			_count = 0;
		}

		#region Enumeration

		/// <summary>
		/// Returns an enumerator that iterates through the bunch.
		/// </summary>
		/// <returns>An <see cref="Enumerator"/> that can be used to iterate through the bunch.</returns>
		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region Enumerator

		public struct Enumerator : IEnumerator<T>
		{
			#region Fields

			private readonly List8<T> _list;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(List8<T> list)
			{
				_list = list;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _list.Count;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _list[_currentIndex];
				}
			}

			object IEnumerator.Current
			{
				get { return Current; }
			}

			public void Dispose()
			{
			}
		}

		#endregion

		#endregion
	}
	/// <summary>
	/// Represents a value type collection with fixed capacity equal to 16.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct List16<T> : IEnumerable<T>
	{
		private const Int32 MaxIndex = 16 - 1;

		#region Fields

		private Bunch16<T> _innerArray;

		private Int32 _count;

		#endregion

		private Int32 LastItemIndex
		{
			get { return _count - 1; }
		}

		public T this[Int32 index]
		{
			get
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				return _innerArray[index];
			}
			set
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				_innerArray[index] = value;
			}
		}

		public Int32 Count
		{
			get { return _count; }
		}

		public Int32 Capacity
		{
			get { return 16; }
		}

		public void Add(T item)
		{
			Insert(LastItemIndex + 1, item);
		}

		public void Insert(Int32 index, T item)
		{
			if (_count == _innerArray.Length)
				throw new OutOfCapacityException();

			if (index < 0 || index > MaxIndex)
				throw new ArgumentOutOfRangeException("index");

			for (var i = LastItemIndex; i >= index; --i)
				_innerArray[i + 1] = _innerArray[i];

			_innerArray[index] = item;
			++_count;
		}

		public void RemoveAt(Int32 index)
		{
			if (index >= _innerArray.Length)
				throw new ArgumentOutOfRangeException("index");

			for (var i = index; i <= LastItemIndex; ++i)
				_innerArray[i] = _innerArray[+1];
		}

		public void Clear()
		{
			for (var i = 0; i <= LastItemIndex; i++)
				_innerArray[i] = default(T);

			_count = 0;
		}

		#region Enumeration

		/// <summary>
		/// Returns an enumerator that iterates through the bunch.
		/// </summary>
		/// <returns>An <see cref="Enumerator"/> that can be used to iterate through the bunch.</returns>
		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region Enumerator

		public struct Enumerator : IEnumerator<T>
		{
			#region Fields

			private readonly List16<T> _list;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(List16<T> list)
			{
				_list = list;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _list.Count;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _list[_currentIndex];
				}
			}

			object IEnumerator.Current
			{
				get { return Current; }
			}

			public void Dispose()
			{
			}
		}

		#endregion

		#endregion
	}
	/// <summary>
	/// Represents a value type collection with fixed capacity equal to 32.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct List32<T> : IEnumerable<T>
	{
		private const Int32 MaxIndex = 32 - 1;

		#region Fields

		private Bunch32<T> _innerArray;

		private Int32 _count;

		#endregion

		private Int32 LastItemIndex
		{
			get { return _count - 1; }
		}

		public T this[Int32 index]
		{
			get
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				return _innerArray[index];
			}
			set
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				_innerArray[index] = value;
			}
		}

		public Int32 Count
		{
			get { return _count; }
		}

		public Int32 Capacity
		{
			get { return 32; }
		}

		public void Add(T item)
		{
			Insert(LastItemIndex + 1, item);
		}

		public void Insert(Int32 index, T item)
		{
			if (_count == _innerArray.Length)
				throw new OutOfCapacityException();

			if (index < 0 || index > MaxIndex)
				throw new ArgumentOutOfRangeException("index");

			for (var i = LastItemIndex; i >= index; --i)
				_innerArray[i + 1] = _innerArray[i];

			_innerArray[index] = item;
			++_count;
		}

		public void RemoveAt(Int32 index)
		{
			if (index >= _innerArray.Length)
				throw new ArgumentOutOfRangeException("index");

			for (var i = index; i <= LastItemIndex; ++i)
				_innerArray[i] = _innerArray[+1];
		}

		public void Clear()
		{
			for (var i = 0; i <= LastItemIndex; i++)
				_innerArray[i] = default(T);

			_count = 0;
		}

		#region Enumeration

		/// <summary>
		/// Returns an enumerator that iterates through the bunch.
		/// </summary>
		/// <returns>An <see cref="Enumerator"/> that can be used to iterate through the bunch.</returns>
		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region Enumerator

		public struct Enumerator : IEnumerator<T>
		{
			#region Fields

			private readonly List32<T> _list;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(List32<T> list)
			{
				_list = list;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _list.Count;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _list[_currentIndex];
				}
			}

			object IEnumerator.Current
			{
				get { return Current; }
			}

			public void Dispose()
			{
			}
		}

		#endregion

		#endregion
	}
	/// <summary>
	/// Represents a value type collection with fixed capacity equal to 64.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct List64<T> : IEnumerable<T>
	{
		private const Int32 MaxIndex = 64 - 1;

		#region Fields

		private Bunch64<T> _innerArray;

		private Int32 _count;

		#endregion

		private Int32 LastItemIndex
		{
			get { return _count - 1; }
		}

		public T this[Int32 index]
		{
			get
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				return _innerArray[index];
			}
			set
			{
				if (index < 0 || index > LastItemIndex)
					throw new IndexOutOfRangeException("index");

				_innerArray[index] = value;
			}
		}

		public Int32 Count
		{
			get { return _count; }
		}

		public Int32 Capacity
		{
			get { return 64; }
		}

		public void Add(T item)
		{
			Insert(LastItemIndex + 1, item);
		}

		public void Insert(Int32 index, T item)
		{
			if (_count == _innerArray.Length)
				throw new OutOfCapacityException();

			if (index < 0 || index > MaxIndex)
				throw new ArgumentOutOfRangeException("index");

			for (var i = LastItemIndex; i >= index; --i)
				_innerArray[i + 1] = _innerArray[i];

			_innerArray[index] = item;
			++_count;
		}

		public void RemoveAt(Int32 index)
		{
			if (index >= _innerArray.Length)
				throw new ArgumentOutOfRangeException("index");

			for (var i = index; i <= LastItemIndex; ++i)
				_innerArray[i] = _innerArray[+1];
		}

		public void Clear()
		{
			for (var i = 0; i <= LastItemIndex; i++)
				_innerArray[i] = default(T);

			_count = 0;
		}

		#region Enumeration

		/// <summary>
		/// Returns an enumerator that iterates through the bunch.
		/// </summary>
		/// <returns>An <see cref="Enumerator"/> that can be used to iterate through the bunch.</returns>
		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region Enumerator

		public struct Enumerator : IEnumerator<T>
		{
			#region Fields

			private readonly List64<T> _list;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(List64<T> list)
			{
				_list = list;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _list.Count;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _list[_currentIndex];
				}
			}

			object IEnumerator.Current
			{
				get { return Current; }
			}

			public void Dispose()
			{
			}
		}

		#endregion

		#endregion
	}
}