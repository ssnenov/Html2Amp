using Html2Amp.IntegrationTests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Html2Amp.IntegrationTests.Tests
{
	[TestClass]
	public class AppSettingsConfiguration
	{
		[TestMethod]
		public void ReadingCustomConfigurationSettings()
		{
			// Arrange
			const string key = "MyCustomFlag";

			var configuration = new RunConfigurationTestDouble();
			configuration.GetConfigurationValueCoreMethod = (k, v) => "true";

			// Act
			bool actualValue = configuration.GetConfigurationValue<bool>(key);

			// Assert
			Assert.IsTrue(actualValue);
		}

		[TestMethod]
		public void OverridingDefaultConfigurationSettings()
		{
			// Arrange
			var configuration = new RunConfigurationTestDouble();
			configuration.GetConfigurationValueCoreMethod = (k, v) => "false";

			// Act
			bool actualValue = configuration.ShouldDownloadImages;

			// Assert
			Assert.IsFalse(actualValue);
		}
	}
}