using System;
using NUnit.Framework;

namespace Eco.Collections.Generic.Fixed
{
	[TestFixture]
	public class List4Test
	{
		[Test]
		public void List4_Empty_SetWithNegativeIndexTest()
		{
			var list = new List4<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List4_Filled_SetWithNegativeIndexTest()
		{
			var list = new List4<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List4_Empty_GetWithNegativeIndexTest()
		{
			var list = new List4<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List4_Filled_GetWithNegativeIndexTest()
		{
			var list = new List4<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List4_Empty_SetWithOutOfRangeIndexTest()
		{
			var list = new List4<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => list[4] = 1);
		}

		[Test]
		public void List4_Filled_SetWithOutOfRangeIndexTest()
		{
			var list = new List4<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[4] = 1);
		}

		[Test]
		public void List4_Empty_GetWithOutOfRangeIndexTest()
		{
			var list = new List4<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[4]; });
		}

		[Test]
		public void List4_Filled_GetWithOutOfRangeIndexTest()
		{
			var list = new List4<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[4]; });
		}

		[Test]
		public void List4_AddTest()
		{
			var list = new List4<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
		}

		[Test]
		public void List4_ClearTest()
		{
			var list = new List4<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Clear();
			Assert.AreEqual(0, list.Count);
			Assert.AreEqual(4, list.Capacity);

			foreach (var item in list)
				Assert.Fail("Empty list enumeration");
		}

		[Test]
		public void List4_InsertInTheBottomTest()
		{
			var list = new List4<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);

			list.Insert(0, -1073741824);

			Assert.AreEqual(4, list.Count);
			Assert.AreEqual(-1073741824, list[0]);

			Assert.AreEqual(2147483647, list[1]);
			Assert.AreEqual(1073741823, list[2]);
			Assert.AreEqual(715827882, list[3]);
		}

		[Test]
		public void List4_InsertInTheMiddleTest()
		{
			var list = new List4<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);

			list.Insert(1, -1073741824);

			Assert.AreEqual(4, list.Count);
			Assert.AreEqual(-1073741824, list[1]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[2]);
			Assert.AreEqual(715827882, list[3]);
		}

		[Test]
		public void List4_InsertInTheTopTest()
		{
			var list = new List4<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);

			list.Insert(2, -1073741824);

			Assert.AreEqual(4, list.Count);
			Assert.AreEqual(-1073741824, list[2]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[3]);
		}

		[Test]
		public void List4_Empty_EnumerationTest()
		{
			var list = new List4<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);

			foreach (var item in list)
			{
				Assert.Fail("Empty list enumeration");
			}
		}

		[Test]
		public void List4_Full_EnumerationTest()
		{
			var list = new List4<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);

			var index = -1;
			foreach (var item in list)
			{
				++index;
				switch(index)
				{
					case 0:
						Assert.AreEqual(2147483647, item);
						break;

					case 1:
						Assert.AreEqual(1073741823, item);
						break;

					case 2:
						Assert.AreEqual(715827882, item);
						break;

					case 3:
						Assert.AreEqual(536870911, item);
						break;

					default:
						Assert.Fail("Out of range enumeration");
						break;
				}
			}
		}
	}
	[TestFixture]
	public class List8Test
	{
		[Test]
		public void List8_Empty_SetWithNegativeIndexTest()
		{
			var list = new List8<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List8_Filled_SetWithNegativeIndexTest()
		{
			var list = new List8<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List8_Empty_GetWithNegativeIndexTest()
		{
			var list = new List8<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List8_Filled_GetWithNegativeIndexTest()
		{
			var list = new List8<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List8_Empty_SetWithOutOfRangeIndexTest()
		{
			var list = new List8<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => list[8] = 1);
		}

		[Test]
		public void List8_Filled_SetWithOutOfRangeIndexTest()
		{
			var list = new List8<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[8] = 1);
		}

		[Test]
		public void List8_Empty_GetWithOutOfRangeIndexTest()
		{
			var list = new List8<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[8]; });
		}

		[Test]
		public void List8_Filled_GetWithOutOfRangeIndexTest()
		{
			var list = new List8<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[8]; });
		}

		[Test]
		public void List8_AddTest()
		{
			var list = new List8<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
		}

		[Test]
		public void List8_ClearTest()
		{
			var list = new List8<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Clear();
			Assert.AreEqual(0, list.Count);
			Assert.AreEqual(8, list.Capacity);

			foreach (var item in list)
				Assert.Fail("Empty list enumeration");
		}

		[Test]
		public void List8_InsertInTheBottomTest()
		{
			var list = new List8<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);

			list.Insert(0, -1073741824);

			Assert.AreEqual(6, list.Count);
			Assert.AreEqual(-1073741824, list[0]);

			Assert.AreEqual(2147483647, list[1]);
			Assert.AreEqual(1073741823, list[2]);
			Assert.AreEqual(715827882, list[3]);
			Assert.AreEqual(536870911, list[4]);
			Assert.AreEqual(429496729, list[5]);
		}

		[Test]
		public void List8_InsertInTheMiddleTest()
		{
			var list = new List8<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);

			list.Insert(2, -1073741824);

			Assert.AreEqual(6, list.Count);
			Assert.AreEqual(-1073741824, list[2]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[3]);
			Assert.AreEqual(536870911, list[4]);
			Assert.AreEqual(429496729, list[5]);
		}

		[Test]
		public void List8_InsertInTheTopTest()
		{
			var list = new List8<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);

			list.Insert(4, -1073741824);

			Assert.AreEqual(6, list.Count);
			Assert.AreEqual(-1073741824, list[4]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[5]);
		}

		[Test]
		public void List8_Empty_EnumerationTest()
		{
			var list = new List8<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);

			foreach (var item in list)
			{
				Assert.Fail("Empty list enumeration");
			}
		}

		[Test]
		public void List8_Full_EnumerationTest()
		{
			var list = new List8<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);

			var index = -1;
			foreach (var item in list)
			{
				++index;
				switch(index)
				{
					case 0:
						Assert.AreEqual(2147483647, item);
						break;

					case 1:
						Assert.AreEqual(1073741823, item);
						break;

					case 2:
						Assert.AreEqual(715827882, item);
						break;

					case 3:
						Assert.AreEqual(536870911, item);
						break;

					case 4:
						Assert.AreEqual(429496729, item);
						break;

					case 5:
						Assert.AreEqual(357913941, item);
						break;

					case 6:
						Assert.AreEqual(306783378, item);
						break;

					case 7:
						Assert.AreEqual(268435455, item);
						break;

					default:
						Assert.Fail("Out of range enumeration");
						break;
				}
			}
		}
	}
	[TestFixture]
	public class List16Test
	{
		[Test]
		public void List16_Empty_SetWithNegativeIndexTest()
		{
			var list = new List16<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List16_Filled_SetWithNegativeIndexTest()
		{
			var list = new List16<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List16_Empty_GetWithNegativeIndexTest()
		{
			var list = new List16<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List16_Filled_GetWithNegativeIndexTest()
		{
			var list = new List16<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List16_Empty_SetWithOutOfRangeIndexTest()
		{
			var list = new List16<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => list[16] = 1);
		}

		[Test]
		public void List16_Filled_SetWithOutOfRangeIndexTest()
		{
			var list = new List16<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[16] = 1);
		}

		[Test]
		public void List16_Empty_GetWithOutOfRangeIndexTest()
		{
			var list = new List16<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[16]; });
		}

		[Test]
		public void List16_Filled_GetWithOutOfRangeIndexTest()
		{
			var list = new List16<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[16]; });
		}

		[Test]
		public void List16_AddTest()
		{
			var list = new List16<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[8]);
			Assert.AreEqual(214748364, list[9]);
			Assert.AreEqual(195225786, list[10]);
			Assert.AreEqual(178956970, list[11]);
			Assert.AreEqual(165191049, list[12]);
			Assert.AreEqual(153391689, list[13]);
			Assert.AreEqual(143165576, list[14]);
			Assert.AreEqual(134217727, list[15]);
		}

		[Test]
		public void List16_ClearTest()
		{
			var list = new List16<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Clear();
			Assert.AreEqual(0, list.Count);
			Assert.AreEqual(16, list.Capacity);

			foreach (var item in list)
				Assert.Fail("Empty list enumeration");
		}

		[Test]
		public void List16_InsertInTheBottomTest()
		{
			var list = new List16<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);

			list.Insert(0, -1073741824);

			Assert.AreEqual(10, list.Count);
			Assert.AreEqual(-1073741824, list[0]);

			Assert.AreEqual(2147483647, list[1]);
			Assert.AreEqual(1073741823, list[2]);
			Assert.AreEqual(715827882, list[3]);
			Assert.AreEqual(536870911, list[4]);
			Assert.AreEqual(429496729, list[5]);
			Assert.AreEqual(357913941, list[6]);
			Assert.AreEqual(306783378, list[7]);
			Assert.AreEqual(268435455, list[8]);
			Assert.AreEqual(238609294, list[9]);
		}

		[Test]
		public void List16_InsertInTheMiddleTest()
		{
			var list = new List16<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);

			list.Insert(4, -1073741824);

			Assert.AreEqual(10, list.Count);
			Assert.AreEqual(-1073741824, list[4]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[5]);
			Assert.AreEqual(357913941, list[6]);
			Assert.AreEqual(306783378, list[7]);
			Assert.AreEqual(268435455, list[8]);
			Assert.AreEqual(238609294, list[9]);
		}

		[Test]
		public void List16_InsertInTheTopTest()
		{
			var list = new List16<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);

			list.Insert(8, -1073741824);

			Assert.AreEqual(10, list.Count);
			Assert.AreEqual(-1073741824, list[8]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[9]);
		}

		[Test]
		public void List16_Empty_EnumerationTest()
		{
			var list = new List16<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);

			foreach (var item in list)
			{
				Assert.Fail("Empty list enumeration");
			}
		}

		[Test]
		public void List16_Full_EnumerationTest()
		{
			var list = new List16<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);

			var index = -1;
			foreach (var item in list)
			{
				++index;
				switch(index)
				{
					case 0:
						Assert.AreEqual(2147483647, item);
						break;

					case 1:
						Assert.AreEqual(1073741823, item);
						break;

					case 2:
						Assert.AreEqual(715827882, item);
						break;

					case 3:
						Assert.AreEqual(536870911, item);
						break;

					case 4:
						Assert.AreEqual(429496729, item);
						break;

					case 5:
						Assert.AreEqual(357913941, item);
						break;

					case 6:
						Assert.AreEqual(306783378, item);
						break;

					case 7:
						Assert.AreEqual(268435455, item);
						break;

					case 8:
						Assert.AreEqual(238609294, item);
						break;

					case 9:
						Assert.AreEqual(214748364, item);
						break;

					case 10:
						Assert.AreEqual(195225786, item);
						break;

					case 11:
						Assert.AreEqual(178956970, item);
						break;

					case 12:
						Assert.AreEqual(165191049, item);
						break;

					case 13:
						Assert.AreEqual(153391689, item);
						break;

					case 14:
						Assert.AreEqual(143165576, item);
						break;

					case 15:
						Assert.AreEqual(134217727, item);
						break;

					default:
						Assert.Fail("Out of range enumeration");
						break;
				}
			}
		}
	}
	[TestFixture]
	public class List32Test
	{
		[Test]
		public void List32_Empty_SetWithNegativeIndexTest()
		{
			var list = new List32<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List32_Filled_SetWithNegativeIndexTest()
		{
			var list = new List32<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List32_Empty_GetWithNegativeIndexTest()
		{
			var list = new List32<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List32_Filled_GetWithNegativeIndexTest()
		{
			var list = new List32<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List32_Empty_SetWithOutOfRangeIndexTest()
		{
			var list = new List32<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => list[32] = 1);
		}

		[Test]
		public void List32_Filled_SetWithOutOfRangeIndexTest()
		{
			var list = new List32<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[32] = 1);
		}

		[Test]
		public void List32_Empty_GetWithOutOfRangeIndexTest()
		{
			var list = new List32<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[32]; });
		}

		[Test]
		public void List32_Filled_GetWithOutOfRangeIndexTest()
		{
			var list = new List32<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[32]; });
		}

		[Test]
		public void List32_AddTest()
		{
			var list = new List32<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[8]);
			Assert.AreEqual(214748364, list[9]);
			Assert.AreEqual(195225786, list[10]);
			Assert.AreEqual(178956970, list[11]);
			Assert.AreEqual(165191049, list[12]);
			Assert.AreEqual(153391689, list[13]);
			Assert.AreEqual(143165576, list[14]);
			Assert.AreEqual(134217727, list[15]);
			Assert.AreEqual(126322567, list[16]);
			Assert.AreEqual(119304647, list[17]);
			Assert.AreEqual(113025455, list[18]);
			Assert.AreEqual(107374182, list[19]);
			Assert.AreEqual(102261126, list[20]);
			Assert.AreEqual(97612893, list[21]);
			Assert.AreEqual(93368854, list[22]);
			Assert.AreEqual(89478485, list[23]);
			Assert.AreEqual(85899345, list[24]);
			Assert.AreEqual(82595524, list[25]);
			Assert.AreEqual(79536431, list[26]);
			Assert.AreEqual(76695844, list[27]);
			Assert.AreEqual(74051160, list[28]);
			Assert.AreEqual(71582788, list[29]);
			Assert.AreEqual(69273666, list[30]);
			Assert.AreEqual(67108863, list[31]);
		}

		[Test]
		public void List32_ClearTest()
		{
			var list = new List32<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Clear();
			Assert.AreEqual(0, list.Count);
			Assert.AreEqual(32, list.Capacity);

			foreach (var item in list)
				Assert.Fail("Empty list enumeration");
		}

		[Test]
		public void List32_InsertInTheBottomTest()
		{
			var list = new List32<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);

			list.Insert(0, -1073741824);

			Assert.AreEqual(18, list.Count);
			Assert.AreEqual(-1073741824, list[0]);

			Assert.AreEqual(2147483647, list[1]);
			Assert.AreEqual(1073741823, list[2]);
			Assert.AreEqual(715827882, list[3]);
			Assert.AreEqual(536870911, list[4]);
			Assert.AreEqual(429496729, list[5]);
			Assert.AreEqual(357913941, list[6]);
			Assert.AreEqual(306783378, list[7]);
			Assert.AreEqual(268435455, list[8]);
			Assert.AreEqual(238609294, list[9]);
			Assert.AreEqual(214748364, list[10]);
			Assert.AreEqual(195225786, list[11]);
			Assert.AreEqual(178956970, list[12]);
			Assert.AreEqual(165191049, list[13]);
			Assert.AreEqual(153391689, list[14]);
			Assert.AreEqual(143165576, list[15]);
			Assert.AreEqual(134217727, list[16]);
			Assert.AreEqual(126322567, list[17]);
		}

		[Test]
		public void List32_InsertInTheMiddleTest()
		{
			var list = new List32<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);

			list.Insert(8, -1073741824);

			Assert.AreEqual(18, list.Count);
			Assert.AreEqual(-1073741824, list[8]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[9]);
			Assert.AreEqual(214748364, list[10]);
			Assert.AreEqual(195225786, list[11]);
			Assert.AreEqual(178956970, list[12]);
			Assert.AreEqual(165191049, list[13]);
			Assert.AreEqual(153391689, list[14]);
			Assert.AreEqual(143165576, list[15]);
			Assert.AreEqual(134217727, list[16]);
			Assert.AreEqual(126322567, list[17]);
		}

		[Test]
		public void List32_InsertInTheTopTest()
		{
			var list = new List32<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);

			list.Insert(16, -1073741824);

			Assert.AreEqual(18, list.Count);
			Assert.AreEqual(-1073741824, list[16]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[8]);
			Assert.AreEqual(214748364, list[9]);
			Assert.AreEqual(195225786, list[10]);
			Assert.AreEqual(178956970, list[11]);
			Assert.AreEqual(165191049, list[12]);
			Assert.AreEqual(153391689, list[13]);
			Assert.AreEqual(143165576, list[14]);
			Assert.AreEqual(134217727, list[15]);
			Assert.AreEqual(126322567, list[17]);
		}

		[Test]
		public void List32_Empty_EnumerationTest()
		{
			var list = new List32<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);

			foreach (var item in list)
			{
				Assert.Fail("Empty list enumeration");
			}
		}

		[Test]
		public void List32_Full_EnumerationTest()
		{
			var list = new List32<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);

			var index = -1;
			foreach (var item in list)
			{
				++index;
				switch(index)
				{
					case 0:
						Assert.AreEqual(2147483647, item);
						break;

					case 1:
						Assert.AreEqual(1073741823, item);
						break;

					case 2:
						Assert.AreEqual(715827882, item);
						break;

					case 3:
						Assert.AreEqual(536870911, item);
						break;

					case 4:
						Assert.AreEqual(429496729, item);
						break;

					case 5:
						Assert.AreEqual(357913941, item);
						break;

					case 6:
						Assert.AreEqual(306783378, item);
						break;

					case 7:
						Assert.AreEqual(268435455, item);
						break;

					case 8:
						Assert.AreEqual(238609294, item);
						break;

					case 9:
						Assert.AreEqual(214748364, item);
						break;

					case 10:
						Assert.AreEqual(195225786, item);
						break;

					case 11:
						Assert.AreEqual(178956970, item);
						break;

					case 12:
						Assert.AreEqual(165191049, item);
						break;

					case 13:
						Assert.AreEqual(153391689, item);
						break;

					case 14:
						Assert.AreEqual(143165576, item);
						break;

					case 15:
						Assert.AreEqual(134217727, item);
						break;

					case 16:
						Assert.AreEqual(126322567, item);
						break;

					case 17:
						Assert.AreEqual(119304647, item);
						break;

					case 18:
						Assert.AreEqual(113025455, item);
						break;

					case 19:
						Assert.AreEqual(107374182, item);
						break;

					case 20:
						Assert.AreEqual(102261126, item);
						break;

					case 21:
						Assert.AreEqual(97612893, item);
						break;

					case 22:
						Assert.AreEqual(93368854, item);
						break;

					case 23:
						Assert.AreEqual(89478485, item);
						break;

					case 24:
						Assert.AreEqual(85899345, item);
						break;

					case 25:
						Assert.AreEqual(82595524, item);
						break;

					case 26:
						Assert.AreEqual(79536431, item);
						break;

					case 27:
						Assert.AreEqual(76695844, item);
						break;

					case 28:
						Assert.AreEqual(74051160, item);
						break;

					case 29:
						Assert.AreEqual(71582788, item);
						break;

					case 30:
						Assert.AreEqual(69273666, item);
						break;

					case 31:
						Assert.AreEqual(67108863, item);
						break;

					default:
						Assert.Fail("Out of range enumeration");
						break;
				}
			}
		}
	}
	[TestFixture]
	public class List64Test
	{
		[Test]
		public void List64_Empty_SetWithNegativeIndexTest()
		{
			var list = new List64<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List64_Filled_SetWithNegativeIndexTest()
		{
			var list = new List64<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
		}

		[Test]
		public void List64_Empty_GetWithNegativeIndexTest()
		{
			var list = new List64<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List64_Filled_GetWithNegativeIndexTest()
		{
			var list = new List64<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[-1]; });
		}

		[Test]
		public void List64_Empty_SetWithOutOfRangeIndexTest()
		{
			var list = new List64<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => list[64] = 1);
		}

		[Test]
		public void List64_Filled_SetWithOutOfRangeIndexTest()
		{
			var list = new List64<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => list[64] = 1);
		}

		[Test]
		public void List64_Empty_GetWithOutOfRangeIndexTest()
		{
			var list = new List64<Int32>();
			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[64]; });
		}

		[Test]
		public void List64_Filled_GetWithOutOfRangeIndexTest()
		{
			var list = new List64<Int32>();

			list.Add(1);
			list.Add(2);

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = list[64]; });
		}

		[Test]
		public void List64_AddTest()
		{
			var list = new List64<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Add(65075262);
			list.Add(63161283);
			list.Add(61356675);
			list.Add(59652323);
			list.Add(58040098);
			list.Add(56512727);
			list.Add(55063683);
			list.Add(53687091);
			list.Add(52377649);
			list.Add(51130563);
			list.Add(49941480);
			list.Add(48806446);
			list.Add(47721858);
			list.Add(46684427);
			list.Add(45691141);
			list.Add(44739242);
			list.Add(43826196);
			list.Add(42949672);
			list.Add(42107522);
			list.Add(41297762);
			list.Add(40518559);
			list.Add(39768215);
			list.Add(39045157);
			list.Add(38347922);
			list.Add(37675151);
			list.Add(37025580);
			list.Add(36398027);
			list.Add(35791394);
			list.Add(35204649);
			list.Add(34636833);
			list.Add(34087042);
			list.Add(33554431);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[8]);
			Assert.AreEqual(214748364, list[9]);
			Assert.AreEqual(195225786, list[10]);
			Assert.AreEqual(178956970, list[11]);
			Assert.AreEqual(165191049, list[12]);
			Assert.AreEqual(153391689, list[13]);
			Assert.AreEqual(143165576, list[14]);
			Assert.AreEqual(134217727, list[15]);
			Assert.AreEqual(126322567, list[16]);
			Assert.AreEqual(119304647, list[17]);
			Assert.AreEqual(113025455, list[18]);
			Assert.AreEqual(107374182, list[19]);
			Assert.AreEqual(102261126, list[20]);
			Assert.AreEqual(97612893, list[21]);
			Assert.AreEqual(93368854, list[22]);
			Assert.AreEqual(89478485, list[23]);
			Assert.AreEqual(85899345, list[24]);
			Assert.AreEqual(82595524, list[25]);
			Assert.AreEqual(79536431, list[26]);
			Assert.AreEqual(76695844, list[27]);
			Assert.AreEqual(74051160, list[28]);
			Assert.AreEqual(71582788, list[29]);
			Assert.AreEqual(69273666, list[30]);
			Assert.AreEqual(67108863, list[31]);
			Assert.AreEqual(65075262, list[32]);
			Assert.AreEqual(63161283, list[33]);
			Assert.AreEqual(61356675, list[34]);
			Assert.AreEqual(59652323, list[35]);
			Assert.AreEqual(58040098, list[36]);
			Assert.AreEqual(56512727, list[37]);
			Assert.AreEqual(55063683, list[38]);
			Assert.AreEqual(53687091, list[39]);
			Assert.AreEqual(52377649, list[40]);
			Assert.AreEqual(51130563, list[41]);
			Assert.AreEqual(49941480, list[42]);
			Assert.AreEqual(48806446, list[43]);
			Assert.AreEqual(47721858, list[44]);
			Assert.AreEqual(46684427, list[45]);
			Assert.AreEqual(45691141, list[46]);
			Assert.AreEqual(44739242, list[47]);
			Assert.AreEqual(43826196, list[48]);
			Assert.AreEqual(42949672, list[49]);
			Assert.AreEqual(42107522, list[50]);
			Assert.AreEqual(41297762, list[51]);
			Assert.AreEqual(40518559, list[52]);
			Assert.AreEqual(39768215, list[53]);
			Assert.AreEqual(39045157, list[54]);
			Assert.AreEqual(38347922, list[55]);
			Assert.AreEqual(37675151, list[56]);
			Assert.AreEqual(37025580, list[57]);
			Assert.AreEqual(36398027, list[58]);
			Assert.AreEqual(35791394, list[59]);
			Assert.AreEqual(35204649, list[60]);
			Assert.AreEqual(34636833, list[61]);
			Assert.AreEqual(34087042, list[62]);
			Assert.AreEqual(33554431, list[63]);
		}

		[Test]
		public void List64_ClearTest()
		{
			var list = new List64<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Add(65075262);
			list.Add(63161283);
			list.Add(61356675);
			list.Add(59652323);
			list.Add(58040098);
			list.Add(56512727);
			list.Add(55063683);
			list.Add(53687091);
			list.Add(52377649);
			list.Add(51130563);
			list.Add(49941480);
			list.Add(48806446);
			list.Add(47721858);
			list.Add(46684427);
			list.Add(45691141);
			list.Add(44739242);
			list.Add(43826196);
			list.Add(42949672);
			list.Add(42107522);
			list.Add(41297762);
			list.Add(40518559);
			list.Add(39768215);
			list.Add(39045157);
			list.Add(38347922);
			list.Add(37675151);
			list.Add(37025580);
			list.Add(36398027);
			list.Add(35791394);
			list.Add(35204649);
			list.Add(34636833);
			list.Add(34087042);
			list.Add(33554431);
			list.Clear();
			Assert.AreEqual(0, list.Count);
			Assert.AreEqual(64, list.Capacity);

			foreach (var item in list)
				Assert.Fail("Empty list enumeration");
		}

		[Test]
		public void List64_InsertInTheBottomTest()
		{
			var list = new List64<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Add(65075262);

			list.Insert(0, -1073741824);

			Assert.AreEqual(34, list.Count);
			Assert.AreEqual(-1073741824, list[0]);

			Assert.AreEqual(2147483647, list[1]);
			Assert.AreEqual(1073741823, list[2]);
			Assert.AreEqual(715827882, list[3]);
			Assert.AreEqual(536870911, list[4]);
			Assert.AreEqual(429496729, list[5]);
			Assert.AreEqual(357913941, list[6]);
			Assert.AreEqual(306783378, list[7]);
			Assert.AreEqual(268435455, list[8]);
			Assert.AreEqual(238609294, list[9]);
			Assert.AreEqual(214748364, list[10]);
			Assert.AreEqual(195225786, list[11]);
			Assert.AreEqual(178956970, list[12]);
			Assert.AreEqual(165191049, list[13]);
			Assert.AreEqual(153391689, list[14]);
			Assert.AreEqual(143165576, list[15]);
			Assert.AreEqual(134217727, list[16]);
			Assert.AreEqual(126322567, list[17]);
			Assert.AreEqual(119304647, list[18]);
			Assert.AreEqual(113025455, list[19]);
			Assert.AreEqual(107374182, list[20]);
			Assert.AreEqual(102261126, list[21]);
			Assert.AreEqual(97612893, list[22]);
			Assert.AreEqual(93368854, list[23]);
			Assert.AreEqual(89478485, list[24]);
			Assert.AreEqual(85899345, list[25]);
			Assert.AreEqual(82595524, list[26]);
			Assert.AreEqual(79536431, list[27]);
			Assert.AreEqual(76695844, list[28]);
			Assert.AreEqual(74051160, list[29]);
			Assert.AreEqual(71582788, list[30]);
			Assert.AreEqual(69273666, list[31]);
			Assert.AreEqual(67108863, list[32]);
			Assert.AreEqual(65075262, list[33]);
		}

		[Test]
		public void List64_InsertInTheMiddleTest()
		{
			var list = new List64<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Add(65075262);

			list.Insert(16, -1073741824);

			Assert.AreEqual(34, list.Count);
			Assert.AreEqual(-1073741824, list[16]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[8]);
			Assert.AreEqual(214748364, list[9]);
			Assert.AreEqual(195225786, list[10]);
			Assert.AreEqual(178956970, list[11]);
			Assert.AreEqual(165191049, list[12]);
			Assert.AreEqual(153391689, list[13]);
			Assert.AreEqual(143165576, list[14]);
			Assert.AreEqual(134217727, list[15]);
			Assert.AreEqual(126322567, list[17]);
			Assert.AreEqual(119304647, list[18]);
			Assert.AreEqual(113025455, list[19]);
			Assert.AreEqual(107374182, list[20]);
			Assert.AreEqual(102261126, list[21]);
			Assert.AreEqual(97612893, list[22]);
			Assert.AreEqual(93368854, list[23]);
			Assert.AreEqual(89478485, list[24]);
			Assert.AreEqual(85899345, list[25]);
			Assert.AreEqual(82595524, list[26]);
			Assert.AreEqual(79536431, list[27]);
			Assert.AreEqual(76695844, list[28]);
			Assert.AreEqual(74051160, list[29]);
			Assert.AreEqual(71582788, list[30]);
			Assert.AreEqual(69273666, list[31]);
			Assert.AreEqual(67108863, list[32]);
			Assert.AreEqual(65075262, list[33]);
		}

		[Test]
		public void List64_InsertInTheTopTest()
		{
			var list = new List64<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Add(65075262);

			list.Insert(32, -1073741824);

			Assert.AreEqual(34, list.Count);
			Assert.AreEqual(-1073741824, list[32]);

			Assert.AreEqual(2147483647, list[0]);
			Assert.AreEqual(1073741823, list[1]);
			Assert.AreEqual(715827882, list[2]);
			Assert.AreEqual(536870911, list[3]);
			Assert.AreEqual(429496729, list[4]);
			Assert.AreEqual(357913941, list[5]);
			Assert.AreEqual(306783378, list[6]);
			Assert.AreEqual(268435455, list[7]);
			Assert.AreEqual(238609294, list[8]);
			Assert.AreEqual(214748364, list[9]);
			Assert.AreEqual(195225786, list[10]);
			Assert.AreEqual(178956970, list[11]);
			Assert.AreEqual(165191049, list[12]);
			Assert.AreEqual(153391689, list[13]);
			Assert.AreEqual(143165576, list[14]);
			Assert.AreEqual(134217727, list[15]);
			Assert.AreEqual(126322567, list[16]);
			Assert.AreEqual(119304647, list[17]);
			Assert.AreEqual(113025455, list[18]);
			Assert.AreEqual(107374182, list[19]);
			Assert.AreEqual(102261126, list[20]);
			Assert.AreEqual(97612893, list[21]);
			Assert.AreEqual(93368854, list[22]);
			Assert.AreEqual(89478485, list[23]);
			Assert.AreEqual(85899345, list[24]);
			Assert.AreEqual(82595524, list[25]);
			Assert.AreEqual(79536431, list[26]);
			Assert.AreEqual(76695844, list[27]);
			Assert.AreEqual(74051160, list[28]);
			Assert.AreEqual(71582788, list[29]);
			Assert.AreEqual(69273666, list[30]);
			Assert.AreEqual(67108863, list[31]);
			Assert.AreEqual(65075262, list[33]);
		}

		[Test]
		public void List64_Empty_EnumerationTest()
		{
			var list = new List64<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Add(65075262);
			list.Add(63161283);
			list.Add(61356675);
			list.Add(59652323);
			list.Add(58040098);
			list.Add(56512727);
			list.Add(55063683);
			list.Add(53687091);
			list.Add(52377649);
			list.Add(51130563);
			list.Add(49941480);
			list.Add(48806446);
			list.Add(47721858);
			list.Add(46684427);
			list.Add(45691141);
			list.Add(44739242);
			list.Add(43826196);
			list.Add(42949672);
			list.Add(42107522);
			list.Add(41297762);
			list.Add(40518559);
			list.Add(39768215);
			list.Add(39045157);
			list.Add(38347922);
			list.Add(37675151);
			list.Add(37025580);
			list.Add(36398027);
			list.Add(35791394);
			list.Add(35204649);
			list.Add(34636833);
			list.Add(34087042);
			list.Add(33554431);

			foreach (var item in list)
			{
				Assert.Fail("Empty list enumeration");
			}
		}

		[Test]
		public void List64_Full_EnumerationTest()
		{
			var list = new List64<Int32>();

			list.Add(2147483647);
			list.Add(1073741823);
			list.Add(715827882);
			list.Add(536870911);
			list.Add(429496729);
			list.Add(357913941);
			list.Add(306783378);
			list.Add(268435455);
			list.Add(238609294);
			list.Add(214748364);
			list.Add(195225786);
			list.Add(178956970);
			list.Add(165191049);
			list.Add(153391689);
			list.Add(143165576);
			list.Add(134217727);
			list.Add(126322567);
			list.Add(119304647);
			list.Add(113025455);
			list.Add(107374182);
			list.Add(102261126);
			list.Add(97612893);
			list.Add(93368854);
			list.Add(89478485);
			list.Add(85899345);
			list.Add(82595524);
			list.Add(79536431);
			list.Add(76695844);
			list.Add(74051160);
			list.Add(71582788);
			list.Add(69273666);
			list.Add(67108863);
			list.Add(65075262);
			list.Add(63161283);
			list.Add(61356675);
			list.Add(59652323);
			list.Add(58040098);
			list.Add(56512727);
			list.Add(55063683);
			list.Add(53687091);
			list.Add(52377649);
			list.Add(51130563);
			list.Add(49941480);
			list.Add(48806446);
			list.Add(47721858);
			list.Add(46684427);
			list.Add(45691141);
			list.Add(44739242);
			list.Add(43826196);
			list.Add(42949672);
			list.Add(42107522);
			list.Add(41297762);
			list.Add(40518559);
			list.Add(39768215);
			list.Add(39045157);
			list.Add(38347922);
			list.Add(37675151);
			list.Add(37025580);
			list.Add(36398027);
			list.Add(35791394);
			list.Add(35204649);
			list.Add(34636833);
			list.Add(34087042);
			list.Add(33554431);

			var index = -1;
			foreach (var item in list)
			{
				++index;
				switch(index)
				{
					case 0:
						Assert.AreEqual(2147483647, item);
						break;

					case 1:
						Assert.AreEqual(1073741823, item);
						break;

					case 2:
						Assert.AreEqual(715827882, item);
						break;

					case 3:
						Assert.AreEqual(536870911, item);
						break;

					case 4:
						Assert.AreEqual(429496729, item);
						break;

					case 5:
						Assert.AreEqual(357913941, item);
						break;

					case 6:
						Assert.AreEqual(306783378, item);
						break;

					case 7:
						Assert.AreEqual(268435455, item);
						break;

					case 8:
						Assert.AreEqual(238609294, item);
						break;

					case 9:
						Assert.AreEqual(214748364, item);
						break;

					case 10:
						Assert.AreEqual(195225786, item);
						break;

					case 11:
						Assert.AreEqual(178956970, item);
						break;

					case 12:
						Assert.AreEqual(165191049, item);
						break;

					case 13:
						Assert.AreEqual(153391689, item);
						break;

					case 14:
						Assert.AreEqual(143165576, item);
						break;

					case 15:
						Assert.AreEqual(134217727, item);
						break;

					case 16:
						Assert.AreEqual(126322567, item);
						break;

					case 17:
						Assert.AreEqual(119304647, item);
						break;

					case 18:
						Assert.AreEqual(113025455, item);
						break;

					case 19:
						Assert.AreEqual(107374182, item);
						break;

					case 20:
						Assert.AreEqual(102261126, item);
						break;

					case 21:
						Assert.AreEqual(97612893, item);
						break;

					case 22:
						Assert.AreEqual(93368854, item);
						break;

					case 23:
						Assert.AreEqual(89478485, item);
						break;

					case 24:
						Assert.AreEqual(85899345, item);
						break;

					case 25:
						Assert.AreEqual(82595524, item);
						break;

					case 26:
						Assert.AreEqual(79536431, item);
						break;

					case 27:
						Assert.AreEqual(76695844, item);
						break;

					case 28:
						Assert.AreEqual(74051160, item);
						break;

					case 29:
						Assert.AreEqual(71582788, item);
						break;

					case 30:
						Assert.AreEqual(69273666, item);
						break;

					case 31:
						Assert.AreEqual(67108863, item);
						break;

					case 32:
						Assert.AreEqual(65075262, item);
						break;

					case 33:
						Assert.AreEqual(63161283, item);
						break;

					case 34:
						Assert.AreEqual(61356675, item);
						break;

					case 35:
						Assert.AreEqual(59652323, item);
						break;

					case 36:
						Assert.AreEqual(58040098, item);
						break;

					case 37:
						Assert.AreEqual(56512727, item);
						break;

					case 38:
						Assert.AreEqual(55063683, item);
						break;

					case 39:
						Assert.AreEqual(53687091, item);
						break;

					case 40:
						Assert.AreEqual(52377649, item);
						break;

					case 41:
						Assert.AreEqual(51130563, item);
						break;

					case 42:
						Assert.AreEqual(49941480, item);
						break;

					case 43:
						Assert.AreEqual(48806446, item);
						break;

					case 44:
						Assert.AreEqual(47721858, item);
						break;

					case 45:
						Assert.AreEqual(46684427, item);
						break;

					case 46:
						Assert.AreEqual(45691141, item);
						break;

					case 47:
						Assert.AreEqual(44739242, item);
						break;

					case 48:
						Assert.AreEqual(43826196, item);
						break;

					case 49:
						Assert.AreEqual(42949672, item);
						break;

					case 50:
						Assert.AreEqual(42107522, item);
						break;

					case 51:
						Assert.AreEqual(41297762, item);
						break;

					case 52:
						Assert.AreEqual(40518559, item);
						break;

					case 53:
						Assert.AreEqual(39768215, item);
						break;

					case 54:
						Assert.AreEqual(39045157, item);
						break;

					case 55:
						Assert.AreEqual(38347922, item);
						break;

					case 56:
						Assert.AreEqual(37675151, item);
						break;

					case 57:
						Assert.AreEqual(37025580, item);
						break;

					case 58:
						Assert.AreEqual(36398027, item);
						break;

					case 59:
						Assert.AreEqual(35791394, item);
						break;

					case 60:
						Assert.AreEqual(35204649, item);
						break;

					case 61:
						Assert.AreEqual(34636833, item);
						break;

					case 62:
						Assert.AreEqual(34087042, item);
						break;

					case 63:
						Assert.AreEqual(33554431, item);
						break;

					default:
						Assert.Fail("Out of range enumeration");
						break;
				}
			}
		}
	}
}