using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.IntegrationTests.Infrastructure;

namespace Html2Amp.IntegrationTests.Tests.ImageSanitizerTests
{
	[TestClass]
	public class AudioSanitization
	{
		[TestMethod]
		public void AudioSanitizationWithControls()
		{
			// Arrange
			const string TestName = "AudioSanitizationWithControls";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}