using Eco.Recycling.Tests.Testers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eco.Recycling.Tests
{
	[TestClass]
	public class GenericRecycleFactoryTests
	{
		[TestMethod]
		public void GenericRecycleFactory_NonConcurrent_CreateItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.NonConcurrent);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_Concurrent_CreateItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.Concurrent);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_ThreadStatic_CreateItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.ThreadStatic);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_ThreadStaticBalanced_CreateItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.ThreadStaticBalanced);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_ThreadStaticGroupBalanced_CreateItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.ThreadStaticGroupBalanced);
			tests.CreateItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_NonConcurrent_RecycleItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.NonConcurrent);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_Concurrent_RecycleItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.Concurrent);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_ThreadStatic_RecycleItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.ThreadStatic);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_ThreadStaticBalanced_RecycleItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.ThreadStaticBalanced);
			tests.RecycleItemTest();
		}

		[TestMethod]
		public void GenericRecycleFactory_ThreadStaticGroupBalanced_RecycleItemTest()
		{
			var tests = new GenericRecycleFactoryTester(StoragePolicy.ThreadStaticGroupBalanced);
			tests.RecycleItemTest();
		}
	}
}