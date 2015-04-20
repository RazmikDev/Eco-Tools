using System;

namespace Eco.Recycling
{
	/// <summary>
	/// Provides the static fields with default settings for <see cref="RecycleFactory{T}"/>.
	/// </summary>
	/// <remarks>
	/// The <see cref="RecycleFactorySettings"/> is created to avoid multiple configuration reading.
	/// Each <see cref="RecycleFactory{T}"/> for any type argument has it's own static fields and type constructor.
	/// Implementing configuration reading in <see cref="RecycleFactory{T}"/> class means that configuration file will be read multiple times if there are more than one usages of <see cref="RecycleFactory{T}"/> with different type arguments. 
	/// </remarks>
	internal static class RecycleFactorySettings
	{
		/// <summary>
		/// Creates a type instance of the <see cref="RecycleFactorySettings"/> class.
		/// </summary>
		static RecycleFactorySettings()
		{
			DefaultCapacity = 100;
			//DefaultCapacity = ConfigurationManager.AppSettings.TryGet(GlobalSettingKeys.RecyclingDefaultCapacityKey);
		}

		/// <summary>
		/// The default maximal amount of stored recyclable items.
		/// </summary>
		internal static Int32 DefaultCapacity { get; private set; }
	}
}