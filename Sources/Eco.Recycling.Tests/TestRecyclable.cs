namespace Eco.Recycling.Tests
{
	/// <summary>
	/// 
	/// </summary>
	public class TestRecyclable : SimpleRecyclable
	{
		#region Overrides of SimpleRecyclable

		/// <summary>
		/// Cleans the state of the current object to prepare it to be recycled.
		/// </summary>
		protected override void OnCleanup()
		{
		}

		#endregion
	}
}