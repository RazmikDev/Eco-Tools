namespace Eco.Recycling.Tests.Testers
{
	public sealed class DefaultRecycleFactoryTester : RecycleFactoryTester<DefaultRecycleFactory<TestRecyclable>, TestRecyclable>
	{
		public DefaultRecycleFactoryTester(StoragePolicy storagePolicy)
			: base(storagePolicy)
		{
		}

		#region Overrides of RecycleFactoryTester<DefaultRecycleFactory<RecyclableMock>,RecyclableMock>

		protected override DefaultRecycleFactory<TestRecyclable> GetFactory(StoragePolicy policy)
		{
			return new DefaultRecycleFactory<TestRecyclable>(policy);
		}

		#endregion
	}
}