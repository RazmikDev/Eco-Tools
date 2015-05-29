namespace Eco.Recycling.Tests.Testers
{
	public sealed class GenericRecycleFactoryTester : RecycleFactoryTester<GenericRecycleFactory<TestRecyclable>, TestRecyclable>
	{
		public GenericRecycleFactoryTester(StoragePolicy storagePolicy)
			: base(storagePolicy)
		{
		}

		#region Overrides of RecycleFactoryTester<DefaultRecycleFactory<RecyclableMock>,RecyclableMock>

		protected override GenericRecycleFactory<TestRecyclable> GetFactory(StoragePolicy policy)
		{
			return new GenericRecycleFactory<TestRecyclable>(() => new TestRecyclable(), policy);
		}

		#endregion
	}
}