using System;
using Eco.Boxing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eco.Tests.Boxing
{
	[TestClass]
	public sealed class BoxedValuesCacheTest
	{
		[TestMethod]
		public void StructureBox_BoxSameValueTwiceTest()
		{
			const Int32 x = 5;
			var xBoxed1 = x.Box();
			var xBoxed2 = x.Box();
			Assert.AreEqual(xBoxed1, xBoxed2);
			Assert.AreSame(xBoxed1, xBoxed2);
		}

		[TestMethod]
		public void StructureBox_BoxDifferentValuesTest()
		{
			const Int32 a = 5;
			const Int32 b = 10;
			var aBoxed = a.Box();
			var bBoxed = b.Box();
			Assert.AreNotEqual(aBoxed, bBoxed);
			Assert.AreNotSame(aBoxed, bBoxed);
		}

		[TestMethod]
		public void StructureBoxGeneric_BoxSameValueTwiceTest()
		{
			const Int32 x = 5;
			var xBoxed1 = x.BoxGeneric();
			var xBoxed2 = x.BoxGeneric();
			Assert.AreEqual(xBoxed1, xBoxed2);
			Assert.AreSame(xBoxed1, xBoxed2);
		}

		[TestMethod]
		public void StructureBoxGeneric_BoxDifferentValuesTest()
		{
			const Int32 a = 5;
			const Int32 b = 10;
			var aBoxed = a.BoxGeneric();
			var bBoxed = b.BoxGeneric();
			Assert.AreNotEqual(aBoxed, bBoxed);
			Assert.AreNotSame(aBoxed, bBoxed);
		}
	}
}