using System;
using NUnit.Framework;

namespace Eco.Collections.Generic.Fixed
{
	[TestFixture]
	public class Bunch4Test
	{
		[Test]
		public void Bunch4_SetWithNegativeIndexTest()
		{
			var bunch = new Bunch4<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[-1] = 1);
		}

		[Test]
		public void Bunch4_GetWithNegativeIndexTest()
		{
			var bunch = new Bunch4<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[-1]; });
		}

		[Test]
		public void Bunch4_SetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch4<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[4] = 1);
		}

		[Test]
		public void Bunch4_GetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch4<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[4]; });
		}

		[Test]
		public void Bunch4_IndexerTest()
		{
			var bunch = new Bunch4<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;

			Assert.AreEqual(2147483647, bunch[0]);
			Assert.AreEqual(1073741823, bunch[1]);
			Assert.AreEqual(715827882, bunch[2]);
			Assert.AreEqual(536870911, bunch[3]);
		}

		[Test]
		public void Bunch4_EnumerationTest()
		{
			var bunch = new Bunch4<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;

			var index = -1;
			foreach (var item in bunch)
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
	public class Bunch8Test
	{
		[Test]
		public void Bunch8_SetWithNegativeIndexTest()
		{
			var bunch = new Bunch8<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[-1] = 1);
		}

		[Test]
		public void Bunch8_GetWithNegativeIndexTest()
		{
			var bunch = new Bunch8<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[-1]; });
		}

		[Test]
		public void Bunch8_SetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch8<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[8] = 1);
		}

		[Test]
		public void Bunch8_GetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch8<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[8]; });
		}

		[Test]
		public void Bunch8_IndexerTest()
		{
			var bunch = new Bunch8<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;

			Assert.AreEqual(2147483647, bunch[0]);
			Assert.AreEqual(1073741823, bunch[1]);
			Assert.AreEqual(715827882, bunch[2]);
			Assert.AreEqual(536870911, bunch[3]);
			Assert.AreEqual(429496729, bunch[4]);
			Assert.AreEqual(357913941, bunch[5]);
			Assert.AreEqual(306783378, bunch[6]);
			Assert.AreEqual(268435455, bunch[7]);
		}

		[Test]
		public void Bunch8_EnumerationTest()
		{
			var bunch = new Bunch8<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;

			var index = -1;
			foreach (var item in bunch)
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
	public class Bunch16Test
	{
		[Test]
		public void Bunch16_SetWithNegativeIndexTest()
		{
			var bunch = new Bunch16<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[-1] = 1);
		}

		[Test]
		public void Bunch16_GetWithNegativeIndexTest()
		{
			var bunch = new Bunch16<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[-1]; });
		}

		[Test]
		public void Bunch16_SetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch16<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[16] = 1);
		}

		[Test]
		public void Bunch16_GetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch16<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[16]; });
		}

		[Test]
		public void Bunch16_IndexerTest()
		{
			var bunch = new Bunch16<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;
			bunch[8] = 238609294;
			bunch[9] = 214748364;
			bunch[10] = 195225786;
			bunch[11] = 178956970;
			bunch[12] = 165191049;
			bunch[13] = 153391689;
			bunch[14] = 143165576;
			bunch[15] = 134217727;

			Assert.AreEqual(2147483647, bunch[0]);
			Assert.AreEqual(1073741823, bunch[1]);
			Assert.AreEqual(715827882, bunch[2]);
			Assert.AreEqual(536870911, bunch[3]);
			Assert.AreEqual(429496729, bunch[4]);
			Assert.AreEqual(357913941, bunch[5]);
			Assert.AreEqual(306783378, bunch[6]);
			Assert.AreEqual(268435455, bunch[7]);
			Assert.AreEqual(238609294, bunch[8]);
			Assert.AreEqual(214748364, bunch[9]);
			Assert.AreEqual(195225786, bunch[10]);
			Assert.AreEqual(178956970, bunch[11]);
			Assert.AreEqual(165191049, bunch[12]);
			Assert.AreEqual(153391689, bunch[13]);
			Assert.AreEqual(143165576, bunch[14]);
			Assert.AreEqual(134217727, bunch[15]);
		}

		[Test]
		public void Bunch16_EnumerationTest()
		{
			var bunch = new Bunch16<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;
			bunch[8] = 238609294;
			bunch[9] = 214748364;
			bunch[10] = 195225786;
			bunch[11] = 178956970;
			bunch[12] = 165191049;
			bunch[13] = 153391689;
			bunch[14] = 143165576;
			bunch[15] = 134217727;

			var index = -1;
			foreach (var item in bunch)
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
	public class Bunch32Test
	{
		[Test]
		public void Bunch32_SetWithNegativeIndexTest()
		{
			var bunch = new Bunch32<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[-1] = 1);
		}

		[Test]
		public void Bunch32_GetWithNegativeIndexTest()
		{
			var bunch = new Bunch32<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[-1]; });
		}

		[Test]
		public void Bunch32_SetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch32<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[32] = 1);
		}

		[Test]
		public void Bunch32_GetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch32<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[32]; });
		}

		[Test]
		public void Bunch32_IndexerTest()
		{
			var bunch = new Bunch32<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;
			bunch[8] = 238609294;
			bunch[9] = 214748364;
			bunch[10] = 195225786;
			bunch[11] = 178956970;
			bunch[12] = 165191049;
			bunch[13] = 153391689;
			bunch[14] = 143165576;
			bunch[15] = 134217727;
			bunch[16] = 126322567;
			bunch[17] = 119304647;
			bunch[18] = 113025455;
			bunch[19] = 107374182;
			bunch[20] = 102261126;
			bunch[21] = 97612893;
			bunch[22] = 93368854;
			bunch[23] = 89478485;
			bunch[24] = 85899345;
			bunch[25] = 82595524;
			bunch[26] = 79536431;
			bunch[27] = 76695844;
			bunch[28] = 74051160;
			bunch[29] = 71582788;
			bunch[30] = 69273666;
			bunch[31] = 67108863;

			Assert.AreEqual(2147483647, bunch[0]);
			Assert.AreEqual(1073741823, bunch[1]);
			Assert.AreEqual(715827882, bunch[2]);
			Assert.AreEqual(536870911, bunch[3]);
			Assert.AreEqual(429496729, bunch[4]);
			Assert.AreEqual(357913941, bunch[5]);
			Assert.AreEqual(306783378, bunch[6]);
			Assert.AreEqual(268435455, bunch[7]);
			Assert.AreEqual(238609294, bunch[8]);
			Assert.AreEqual(214748364, bunch[9]);
			Assert.AreEqual(195225786, bunch[10]);
			Assert.AreEqual(178956970, bunch[11]);
			Assert.AreEqual(165191049, bunch[12]);
			Assert.AreEqual(153391689, bunch[13]);
			Assert.AreEqual(143165576, bunch[14]);
			Assert.AreEqual(134217727, bunch[15]);
			Assert.AreEqual(126322567, bunch[16]);
			Assert.AreEqual(119304647, bunch[17]);
			Assert.AreEqual(113025455, bunch[18]);
			Assert.AreEqual(107374182, bunch[19]);
			Assert.AreEqual(102261126, bunch[20]);
			Assert.AreEqual(97612893, bunch[21]);
			Assert.AreEqual(93368854, bunch[22]);
			Assert.AreEqual(89478485, bunch[23]);
			Assert.AreEqual(85899345, bunch[24]);
			Assert.AreEqual(82595524, bunch[25]);
			Assert.AreEqual(79536431, bunch[26]);
			Assert.AreEqual(76695844, bunch[27]);
			Assert.AreEqual(74051160, bunch[28]);
			Assert.AreEqual(71582788, bunch[29]);
			Assert.AreEqual(69273666, bunch[30]);
			Assert.AreEqual(67108863, bunch[31]);
		}

		[Test]
		public void Bunch32_EnumerationTest()
		{
			var bunch = new Bunch32<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;
			bunch[8] = 238609294;
			bunch[9] = 214748364;
			bunch[10] = 195225786;
			bunch[11] = 178956970;
			bunch[12] = 165191049;
			bunch[13] = 153391689;
			bunch[14] = 143165576;
			bunch[15] = 134217727;
			bunch[16] = 126322567;
			bunch[17] = 119304647;
			bunch[18] = 113025455;
			bunch[19] = 107374182;
			bunch[20] = 102261126;
			bunch[21] = 97612893;
			bunch[22] = 93368854;
			bunch[23] = 89478485;
			bunch[24] = 85899345;
			bunch[25] = 82595524;
			bunch[26] = 79536431;
			bunch[27] = 76695844;
			bunch[28] = 74051160;
			bunch[29] = 71582788;
			bunch[30] = 69273666;
			bunch[31] = 67108863;

			var index = -1;
			foreach (var item in bunch)
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
	public class Bunch64Test
	{
		[Test]
		public void Bunch64_SetWithNegativeIndexTest()
		{
			var bunch = new Bunch64<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[-1] = 1);
		}

		[Test]
		public void Bunch64_GetWithNegativeIndexTest()
		{
			var bunch = new Bunch64<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[-1]; });
		}

		[Test]
		public void Bunch64_SetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch64<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => bunch[64] = 1);
		}

		[Test]
		public void Bunch64_GetWithOutOfRangeIndexTest()
		{
			var bunch = new Bunch64<Int32>();

			Assert.Throws<IndexOutOfRangeException>(() => { var temp = bunch[64]; });
		}

		[Test]
		public void Bunch64_IndexerTest()
		{
			var bunch = new Bunch64<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;
			bunch[8] = 238609294;
			bunch[9] = 214748364;
			bunch[10] = 195225786;
			bunch[11] = 178956970;
			bunch[12] = 165191049;
			bunch[13] = 153391689;
			bunch[14] = 143165576;
			bunch[15] = 134217727;
			bunch[16] = 126322567;
			bunch[17] = 119304647;
			bunch[18] = 113025455;
			bunch[19] = 107374182;
			bunch[20] = 102261126;
			bunch[21] = 97612893;
			bunch[22] = 93368854;
			bunch[23] = 89478485;
			bunch[24] = 85899345;
			bunch[25] = 82595524;
			bunch[26] = 79536431;
			bunch[27] = 76695844;
			bunch[28] = 74051160;
			bunch[29] = 71582788;
			bunch[30] = 69273666;
			bunch[31] = 67108863;
			bunch[32] = 65075262;
			bunch[33] = 63161283;
			bunch[34] = 61356675;
			bunch[35] = 59652323;
			bunch[36] = 58040098;
			bunch[37] = 56512727;
			bunch[38] = 55063683;
			bunch[39] = 53687091;
			bunch[40] = 52377649;
			bunch[41] = 51130563;
			bunch[42] = 49941480;
			bunch[43] = 48806446;
			bunch[44] = 47721858;
			bunch[45] = 46684427;
			bunch[46] = 45691141;
			bunch[47] = 44739242;
			bunch[48] = 43826196;
			bunch[49] = 42949672;
			bunch[50] = 42107522;
			bunch[51] = 41297762;
			bunch[52] = 40518559;
			bunch[53] = 39768215;
			bunch[54] = 39045157;
			bunch[55] = 38347922;
			bunch[56] = 37675151;
			bunch[57] = 37025580;
			bunch[58] = 36398027;
			bunch[59] = 35791394;
			bunch[60] = 35204649;
			bunch[61] = 34636833;
			bunch[62] = 34087042;
			bunch[63] = 33554431;

			Assert.AreEqual(2147483647, bunch[0]);
			Assert.AreEqual(1073741823, bunch[1]);
			Assert.AreEqual(715827882, bunch[2]);
			Assert.AreEqual(536870911, bunch[3]);
			Assert.AreEqual(429496729, bunch[4]);
			Assert.AreEqual(357913941, bunch[5]);
			Assert.AreEqual(306783378, bunch[6]);
			Assert.AreEqual(268435455, bunch[7]);
			Assert.AreEqual(238609294, bunch[8]);
			Assert.AreEqual(214748364, bunch[9]);
			Assert.AreEqual(195225786, bunch[10]);
			Assert.AreEqual(178956970, bunch[11]);
			Assert.AreEqual(165191049, bunch[12]);
			Assert.AreEqual(153391689, bunch[13]);
			Assert.AreEqual(143165576, bunch[14]);
			Assert.AreEqual(134217727, bunch[15]);
			Assert.AreEqual(126322567, bunch[16]);
			Assert.AreEqual(119304647, bunch[17]);
			Assert.AreEqual(113025455, bunch[18]);
			Assert.AreEqual(107374182, bunch[19]);
			Assert.AreEqual(102261126, bunch[20]);
			Assert.AreEqual(97612893, bunch[21]);
			Assert.AreEqual(93368854, bunch[22]);
			Assert.AreEqual(89478485, bunch[23]);
			Assert.AreEqual(85899345, bunch[24]);
			Assert.AreEqual(82595524, bunch[25]);
			Assert.AreEqual(79536431, bunch[26]);
			Assert.AreEqual(76695844, bunch[27]);
			Assert.AreEqual(74051160, bunch[28]);
			Assert.AreEqual(71582788, bunch[29]);
			Assert.AreEqual(69273666, bunch[30]);
			Assert.AreEqual(67108863, bunch[31]);
			Assert.AreEqual(65075262, bunch[32]);
			Assert.AreEqual(63161283, bunch[33]);
			Assert.AreEqual(61356675, bunch[34]);
			Assert.AreEqual(59652323, bunch[35]);
			Assert.AreEqual(58040098, bunch[36]);
			Assert.AreEqual(56512727, bunch[37]);
			Assert.AreEqual(55063683, bunch[38]);
			Assert.AreEqual(53687091, bunch[39]);
			Assert.AreEqual(52377649, bunch[40]);
			Assert.AreEqual(51130563, bunch[41]);
			Assert.AreEqual(49941480, bunch[42]);
			Assert.AreEqual(48806446, bunch[43]);
			Assert.AreEqual(47721858, bunch[44]);
			Assert.AreEqual(46684427, bunch[45]);
			Assert.AreEqual(45691141, bunch[46]);
			Assert.AreEqual(44739242, bunch[47]);
			Assert.AreEqual(43826196, bunch[48]);
			Assert.AreEqual(42949672, bunch[49]);
			Assert.AreEqual(42107522, bunch[50]);
			Assert.AreEqual(41297762, bunch[51]);
			Assert.AreEqual(40518559, bunch[52]);
			Assert.AreEqual(39768215, bunch[53]);
			Assert.AreEqual(39045157, bunch[54]);
			Assert.AreEqual(38347922, bunch[55]);
			Assert.AreEqual(37675151, bunch[56]);
			Assert.AreEqual(37025580, bunch[57]);
			Assert.AreEqual(36398027, bunch[58]);
			Assert.AreEqual(35791394, bunch[59]);
			Assert.AreEqual(35204649, bunch[60]);
			Assert.AreEqual(34636833, bunch[61]);
			Assert.AreEqual(34087042, bunch[62]);
			Assert.AreEqual(33554431, bunch[63]);
		}

		[Test]
		public void Bunch64_EnumerationTest()
		{
			var bunch = new Bunch64<Int32>();

			bunch[0] = 2147483647;
			bunch[1] = 1073741823;
			bunch[2] = 715827882;
			bunch[3] = 536870911;
			bunch[4] = 429496729;
			bunch[5] = 357913941;
			bunch[6] = 306783378;
			bunch[7] = 268435455;
			bunch[8] = 238609294;
			bunch[9] = 214748364;
			bunch[10] = 195225786;
			bunch[11] = 178956970;
			bunch[12] = 165191049;
			bunch[13] = 153391689;
			bunch[14] = 143165576;
			bunch[15] = 134217727;
			bunch[16] = 126322567;
			bunch[17] = 119304647;
			bunch[18] = 113025455;
			bunch[19] = 107374182;
			bunch[20] = 102261126;
			bunch[21] = 97612893;
			bunch[22] = 93368854;
			bunch[23] = 89478485;
			bunch[24] = 85899345;
			bunch[25] = 82595524;
			bunch[26] = 79536431;
			bunch[27] = 76695844;
			bunch[28] = 74051160;
			bunch[29] = 71582788;
			bunch[30] = 69273666;
			bunch[31] = 67108863;
			bunch[32] = 65075262;
			bunch[33] = 63161283;
			bunch[34] = 61356675;
			bunch[35] = 59652323;
			bunch[36] = 58040098;
			bunch[37] = 56512727;
			bunch[38] = 55063683;
			bunch[39] = 53687091;
			bunch[40] = 52377649;
			bunch[41] = 51130563;
			bunch[42] = 49941480;
			bunch[43] = 48806446;
			bunch[44] = 47721858;
			bunch[45] = 46684427;
			bunch[46] = 45691141;
			bunch[47] = 44739242;
			bunch[48] = 43826196;
			bunch[49] = 42949672;
			bunch[50] = 42107522;
			bunch[51] = 41297762;
			bunch[52] = 40518559;
			bunch[53] = 39768215;
			bunch[54] = 39045157;
			bunch[55] = 38347922;
			bunch[56] = 37675151;
			bunch[57] = 37025580;
			bunch[58] = 36398027;
			bunch[59] = 35791394;
			bunch[60] = 35204649;
			bunch[61] = 34636833;
			bunch[62] = 34087042;
			bunch[63] = 33554431;

			var index = -1;
			foreach (var item in bunch)
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