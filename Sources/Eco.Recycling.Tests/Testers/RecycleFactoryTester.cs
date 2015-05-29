using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eco.Recycling.Tests.Testers
{
	public abstract class RecycleFactoryTester<TRecycleFactory, TRecyclable>
		where TRecyclable : class, IRecyclable
		where TRecycleFactory : RecycleFactory<TRecyclable>
	{
		private readonly StoragePolicy _storagePolicy;

		protected RecycleFactoryTester(StoragePolicy storagePolicy)
		{
			_storagePolicy = storagePolicy;
		}

		protected abstract TRecycleFactory GetFactory(StoragePolicy policy);

		public void AssertCount(Int32 expectedCount)
		{

		}

		public void AssertCapacity()
		{

		}

		public void CreateItemTest()
		{
			var testedFactory = GetFactory(_storagePolicy);
			testedFactory.CollectMetrics = true;

			var item1 = testedFactory.Create();
			var item2 = testedFactory.Create();
			var item3 = testedFactory.Create();

			Assert.AreNotSame(item1, item2);
			Assert.AreNotSame(item1, item3);

			Assert.AreEqual(0, testedFactory.Count);
			AssertMetrics(testedFactory, 3, 0, 0);
		}

		public void RecycleItemTest()
		{
			var testedFactory = GetFactory(_storagePolicy);
			testedFactory.CollectMetrics = true;

			var item1 = testedFactory.Create();
			var item2 = testedFactory.Create();
			var item3 = testedFactory.Create();

			item2.Free();

			Assert.AreEqual(1, testedFactory.Count);
			AssertMetrics(testedFactory, 3, 0, 0);

			var item4 = testedFactory.Create();

			Assert.AreSame(item2, item4);

			Assert.AreEqual(0, testedFactory.Count);
			AssertMetrics(testedFactory, 3, 1, 0);
		}

		private static void AssertMetrics(TRecycleFactory testedFactory, Int32 expectedCreatedCount = 0, Int32 expectedRecycledCount = 0, Int32 expectedMissedCount = 0)
		{
			Assert.AreEqual(expectedCreatedCount, testedFactory.CreatedCount, "Created count for recycle factory does not match to expected value.");
			Assert.AreEqual(expectedRecycledCount, testedFactory.RecycledCount, "Recycled count for recycle factory does not match to expected value.");
			Assert.AreEqual(expectedMissedCount, testedFactory.MissedCount, "Missed count for recycle factory does not match to expected value.");
		}
	}
}