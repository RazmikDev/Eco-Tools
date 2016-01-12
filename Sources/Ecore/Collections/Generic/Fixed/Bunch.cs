using System;
using System.Collections;
using System.Collections.Generic;

namespace Eco.Collections.Generic.Fixed
{
	/// <summary>
	/// Represents a 4-cell value type array.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct Bunch4<T> : IEnumerable<T>
	{
		#region Fields

		private T _item0;

		private T _item1;

		private T _item2;

		private T _item3;

		#endregion

		/// <summary>
		/// Gets the maximum size of the <see cref="Bunch4{T}"/> collection.
		/// </summary>
		public Int32 Length
		{
			get { return 4;}
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <param name="index"/> is less then zero -or- greater than maximum length of the bunch.
		///	</exception>
		public T this[Int32 index]
		{
			get
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						return _item0;

					case 1:
						return _item1;

					case 2:
						return _item2;

					case 3:
						return _item3;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						_item0 = value;
						break;

					case 1:
						_item1 = value;
						break;

					case 2:
						_item2 = value;
						break;

					case 3:
						_item3 = value;
						break;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
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

			private readonly Bunch4<T> _bunch;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(Bunch4<T> bunch)
			{
				_bunch = bunch;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _bunch.Length;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _bunch[_currentIndex];
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
	/// Represents a 8-cell value type array.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct Bunch8<T> : IEnumerable<T>
	{
		#region Fields

		private T _item0;

		private T _item1;

		private T _item2;

		private T _item3;

		private T _item4;

		private T _item5;

		private T _item6;

		private T _item7;

		#endregion

		/// <summary>
		/// Gets the maximum size of the <see cref="Bunch8{T}"/> collection.
		/// </summary>
		public Int32 Length
		{
			get { return 8;}
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <param name="index"/> is less then zero -or- greater than maximum length of the bunch.
		///	</exception>
		public T this[Int32 index]
		{
			get
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						return _item0;

					case 1:
						return _item1;

					case 2:
						return _item2;

					case 3:
						return _item3;

					case 4:
						return _item4;

					case 5:
						return _item5;

					case 6:
						return _item6;

					case 7:
						return _item7;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						_item0 = value;
						break;

					case 1:
						_item1 = value;
						break;

					case 2:
						_item2 = value;
						break;

					case 3:
						_item3 = value;
						break;

					case 4:
						_item4 = value;
						break;

					case 5:
						_item5 = value;
						break;

					case 6:
						_item6 = value;
						break;

					case 7:
						_item7 = value;
						break;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
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

			private readonly Bunch8<T> _bunch;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(Bunch8<T> bunch)
			{
				_bunch = bunch;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _bunch.Length;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _bunch[_currentIndex];
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
	/// Represents a 16-cell value type array.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct Bunch16<T> : IEnumerable<T>
	{
		#region Fields

		private T _item0;

		private T _item1;

		private T _item2;

		private T _item3;

		private T _item4;

		private T _item5;

		private T _item6;

		private T _item7;

		private T _item8;

		private T _item9;

		private T _item10;

		private T _item11;

		private T _item12;

		private T _item13;

		private T _item14;

		private T _item15;

		#endregion

		/// <summary>
		/// Gets the maximum size of the <see cref="Bunch16{T}"/> collection.
		/// </summary>
		public Int32 Length
		{
			get { return 16;}
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <param name="index"/> is less then zero -or- greater than maximum length of the bunch.
		///	</exception>
		public T this[Int32 index]
		{
			get
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						return _item0;

					case 1:
						return _item1;

					case 2:
						return _item2;

					case 3:
						return _item3;

					case 4:
						return _item4;

					case 5:
						return _item5;

					case 6:
						return _item6;

					case 7:
						return _item7;

					case 8:
						return _item8;

					case 9:
						return _item9;

					case 10:
						return _item10;

					case 11:
						return _item11;

					case 12:
						return _item12;

					case 13:
						return _item13;

					case 14:
						return _item14;

					case 15:
						return _item15;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						_item0 = value;
						break;

					case 1:
						_item1 = value;
						break;

					case 2:
						_item2 = value;
						break;

					case 3:
						_item3 = value;
						break;

					case 4:
						_item4 = value;
						break;

					case 5:
						_item5 = value;
						break;

					case 6:
						_item6 = value;
						break;

					case 7:
						_item7 = value;
						break;

					case 8:
						_item8 = value;
						break;

					case 9:
						_item9 = value;
						break;

					case 10:
						_item10 = value;
						break;

					case 11:
						_item11 = value;
						break;

					case 12:
						_item12 = value;
						break;

					case 13:
						_item13 = value;
						break;

					case 14:
						_item14 = value;
						break;

					case 15:
						_item15 = value;
						break;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
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

			private readonly Bunch16<T> _bunch;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(Bunch16<T> bunch)
			{
				_bunch = bunch;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _bunch.Length;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _bunch[_currentIndex];
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
	/// Represents a 32-cell value type array.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct Bunch32<T> : IEnumerable<T>
	{
		#region Fields

		private T _item0;

		private T _item1;

		private T _item2;

		private T _item3;

		private T _item4;

		private T _item5;

		private T _item6;

		private T _item7;

		private T _item8;

		private T _item9;

		private T _item10;

		private T _item11;

		private T _item12;

		private T _item13;

		private T _item14;

		private T _item15;

		private T _item16;

		private T _item17;

		private T _item18;

		private T _item19;

		private T _item20;

		private T _item21;

		private T _item22;

		private T _item23;

		private T _item24;

		private T _item25;

		private T _item26;

		private T _item27;

		private T _item28;

		private T _item29;

		private T _item30;

		private T _item31;

		#endregion

		/// <summary>
		/// Gets the maximum size of the <see cref="Bunch32{T}"/> collection.
		/// </summary>
		public Int32 Length
		{
			get { return 32;}
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <param name="index"/> is less then zero -or- greater than maximum length of the bunch.
		///	</exception>
		public T this[Int32 index]
		{
			get
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						return _item0;

					case 1:
						return _item1;

					case 2:
						return _item2;

					case 3:
						return _item3;

					case 4:
						return _item4;

					case 5:
						return _item5;

					case 6:
						return _item6;

					case 7:
						return _item7;

					case 8:
						return _item8;

					case 9:
						return _item9;

					case 10:
						return _item10;

					case 11:
						return _item11;

					case 12:
						return _item12;

					case 13:
						return _item13;

					case 14:
						return _item14;

					case 15:
						return _item15;

					case 16:
						return _item16;

					case 17:
						return _item17;

					case 18:
						return _item18;

					case 19:
						return _item19;

					case 20:
						return _item20;

					case 21:
						return _item21;

					case 22:
						return _item22;

					case 23:
						return _item23;

					case 24:
						return _item24;

					case 25:
						return _item25;

					case 26:
						return _item26;

					case 27:
						return _item27;

					case 28:
						return _item28;

					case 29:
						return _item29;

					case 30:
						return _item30;

					case 31:
						return _item31;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						_item0 = value;
						break;

					case 1:
						_item1 = value;
						break;

					case 2:
						_item2 = value;
						break;

					case 3:
						_item3 = value;
						break;

					case 4:
						_item4 = value;
						break;

					case 5:
						_item5 = value;
						break;

					case 6:
						_item6 = value;
						break;

					case 7:
						_item7 = value;
						break;

					case 8:
						_item8 = value;
						break;

					case 9:
						_item9 = value;
						break;

					case 10:
						_item10 = value;
						break;

					case 11:
						_item11 = value;
						break;

					case 12:
						_item12 = value;
						break;

					case 13:
						_item13 = value;
						break;

					case 14:
						_item14 = value;
						break;

					case 15:
						_item15 = value;
						break;

					case 16:
						_item16 = value;
						break;

					case 17:
						_item17 = value;
						break;

					case 18:
						_item18 = value;
						break;

					case 19:
						_item19 = value;
						break;

					case 20:
						_item20 = value;
						break;

					case 21:
						_item21 = value;
						break;

					case 22:
						_item22 = value;
						break;

					case 23:
						_item23 = value;
						break;

					case 24:
						_item24 = value;
						break;

					case 25:
						_item25 = value;
						break;

					case 26:
						_item26 = value;
						break;

					case 27:
						_item27 = value;
						break;

					case 28:
						_item28 = value;
						break;

					case 29:
						_item29 = value;
						break;

					case 30:
						_item30 = value;
						break;

					case 31:
						_item31 = value;
						break;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
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

			private readonly Bunch32<T> _bunch;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(Bunch32<T> bunch)
			{
				_bunch = bunch;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _bunch.Length;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _bunch[_currentIndex];
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
	/// Represents a 64-cell value type array.
	/// </summary>
	/// <typeparam name="T">The type of stored item.</typeparam>
	public struct Bunch64<T> : IEnumerable<T>
	{
		#region Fields

		private T _item0;

		private T _item1;

		private T _item2;

		private T _item3;

		private T _item4;

		private T _item5;

		private T _item6;

		private T _item7;

		private T _item8;

		private T _item9;

		private T _item10;

		private T _item11;

		private T _item12;

		private T _item13;

		private T _item14;

		private T _item15;

		private T _item16;

		private T _item17;

		private T _item18;

		private T _item19;

		private T _item20;

		private T _item21;

		private T _item22;

		private T _item23;

		private T _item24;

		private T _item25;

		private T _item26;

		private T _item27;

		private T _item28;

		private T _item29;

		private T _item30;

		private T _item31;

		private T _item32;

		private T _item33;

		private T _item34;

		private T _item35;

		private T _item36;

		private T _item37;

		private T _item38;

		private T _item39;

		private T _item40;

		private T _item41;

		private T _item42;

		private T _item43;

		private T _item44;

		private T _item45;

		private T _item46;

		private T _item47;

		private T _item48;

		private T _item49;

		private T _item50;

		private T _item51;

		private T _item52;

		private T _item53;

		private T _item54;

		private T _item55;

		private T _item56;

		private T _item57;

		private T _item58;

		private T _item59;

		private T _item60;

		private T _item61;

		private T _item62;

		private T _item63;

		#endregion

		/// <summary>
		/// Gets the maximum size of the <see cref="Bunch64{T}"/> collection.
		/// </summary>
		public Int32 Length
		{
			get { return 64;}
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <param name="index"/> is less then zero -or- greater than maximum length of the bunch.
		///	</exception>
		public T this[Int32 index]
		{
			get
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						return _item0;

					case 1:
						return _item1;

					case 2:
						return _item2;

					case 3:
						return _item3;

					case 4:
						return _item4;

					case 5:
						return _item5;

					case 6:
						return _item6;

					case 7:
						return _item7;

					case 8:
						return _item8;

					case 9:
						return _item9;

					case 10:
						return _item10;

					case 11:
						return _item11;

					case 12:
						return _item12;

					case 13:
						return _item13;

					case 14:
						return _item14;

					case 15:
						return _item15;

					case 16:
						return _item16;

					case 17:
						return _item17;

					case 18:
						return _item18;

					case 19:
						return _item19;

					case 20:
						return _item20;

					case 21:
						return _item21;

					case 22:
						return _item22;

					case 23:
						return _item23;

					case 24:
						return _item24;

					case 25:
						return _item25;

					case 26:
						return _item26;

					case 27:
						return _item27;

					case 28:
						return _item28;

					case 29:
						return _item29;

					case 30:
						return _item30;

					case 31:
						return _item31;

					case 32:
						return _item32;

					case 33:
						return _item33;

					case 34:
						return _item34;

					case 35:
						return _item35;

					case 36:
						return _item36;

					case 37:
						return _item37;

					case 38:
						return _item38;

					case 39:
						return _item39;

					case 40:
						return _item40;

					case 41:
						return _item41;

					case 42:
						return _item42;

					case 43:
						return _item43;

					case 44:
						return _item44;

					case 45:
						return _item45;

					case 46:
						return _item46;

					case 47:
						return _item47;

					case 48:
						return _item48;

					case 49:
						return _item49;

					case 50:
						return _item50;

					case 51:
						return _item51;

					case 52:
						return _item52;

					case 53:
						return _item53;

					case 54:
						return _item54;

					case 55:
						return _item55;

					case 56:
						return _item56;

					case 57:
						return _item57;

					case 58:
						return _item58;

					case 59:
						return _item59;

					case 60:
						return _item60;

					case 61:
						return _item61;

					case 62:
						return _item62;

					case 63:
						return _item63;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException("Provided index is less then zero");

				switch (index)
				{
					case 0:
						_item0 = value;
						break;

					case 1:
						_item1 = value;
						break;

					case 2:
						_item2 = value;
						break;

					case 3:
						_item3 = value;
						break;

					case 4:
						_item4 = value;
						break;

					case 5:
						_item5 = value;
						break;

					case 6:
						_item6 = value;
						break;

					case 7:
						_item7 = value;
						break;

					case 8:
						_item8 = value;
						break;

					case 9:
						_item9 = value;
						break;

					case 10:
						_item10 = value;
						break;

					case 11:
						_item11 = value;
						break;

					case 12:
						_item12 = value;
						break;

					case 13:
						_item13 = value;
						break;

					case 14:
						_item14 = value;
						break;

					case 15:
						_item15 = value;
						break;

					case 16:
						_item16 = value;
						break;

					case 17:
						_item17 = value;
						break;

					case 18:
						_item18 = value;
						break;

					case 19:
						_item19 = value;
						break;

					case 20:
						_item20 = value;
						break;

					case 21:
						_item21 = value;
						break;

					case 22:
						_item22 = value;
						break;

					case 23:
						_item23 = value;
						break;

					case 24:
						_item24 = value;
						break;

					case 25:
						_item25 = value;
						break;

					case 26:
						_item26 = value;
						break;

					case 27:
						_item27 = value;
						break;

					case 28:
						_item28 = value;
						break;

					case 29:
						_item29 = value;
						break;

					case 30:
						_item30 = value;
						break;

					case 31:
						_item31 = value;
						break;

					case 32:
						_item32 = value;
						break;

					case 33:
						_item33 = value;
						break;

					case 34:
						_item34 = value;
						break;

					case 35:
						_item35 = value;
						break;

					case 36:
						_item36 = value;
						break;

					case 37:
						_item37 = value;
						break;

					case 38:
						_item38 = value;
						break;

					case 39:
						_item39 = value;
						break;

					case 40:
						_item40 = value;
						break;

					case 41:
						_item41 = value;
						break;

					case 42:
						_item42 = value;
						break;

					case 43:
						_item43 = value;
						break;

					case 44:
						_item44 = value;
						break;

					case 45:
						_item45 = value;
						break;

					case 46:
						_item46 = value;
						break;

					case 47:
						_item47 = value;
						break;

					case 48:
						_item48 = value;
						break;

					case 49:
						_item49 = value;
						break;

					case 50:
						_item50 = value;
						break;

					case 51:
						_item51 = value;
						break;

					case 52:
						_item52 = value;
						break;

					case 53:
						_item53 = value;
						break;

					case 54:
						_item54 = value;
						break;

					case 55:
						_item55 = value;
						break;

					case 56:
						_item56 = value;
						break;

					case 57:
						_item57 = value;
						break;

					case 58:
						_item58 = value;
						break;

					case 59:
						_item59 = value;
						break;

					case 60:
						_item60 = value;
						break;

					case 61:
						_item61 = value;
						break;

					case 62:
						_item62 = value;
						break;

					case 63:
						_item63 = value;
						break;

					default:
						throw new IndexOutOfRangeException("Provided index is greater then size of the bunch");
				}
			}
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

			private readonly Bunch64<T> _bunch;

			private Int32 _currentIndex;

			#endregion

			public Enumerator(Bunch64<T> bunch)
			{
				_bunch = bunch;
				_currentIndex = -1;
			}

			public bool MoveNext()
			{
				++_currentIndex;

				return _currentIndex < _bunch.Length;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public T Current
			{
				get
				{
					return _bunch[_currentIndex];
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