using Eco.Recycling.Tests.Testers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eco.Recycling.Tests
{
	[TestClass]
	public class DefaultRecycleFactoryTests
	{
		[TestMethod]
		public void DefaultRecycleFactory_NonConcurrent_CreateItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.NonConcurrent);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_Concurrent_CreateItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.Concurrent);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_ThreadStatic_CreateItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.ThreadStatic);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_ThreadStaticBalanced_CreateItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.ThreadStaticBalanced);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_ThreadStaticGroupBalanced_CreateItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.ThreadStaticGroupBalanced);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_NonConcurrent_RecycleItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.NonConcurrent);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_Concurrent_RecycleItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.Concurrent);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_ThreadStatic_RecycleItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.ThreadStatic);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_ThreadStaticBalanced_RecycleItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.ThreadStaticBalanced);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void DefaultRecycleFactory_ThreadStaticGroupBalanced_RecycleItemTest()
		{
			var tests = new DefaultRecycleFactoryTester(StoragePolicy.ThreadStaticGroupBalanced);
			tests.RecycleItemTest();
		}
	}
}