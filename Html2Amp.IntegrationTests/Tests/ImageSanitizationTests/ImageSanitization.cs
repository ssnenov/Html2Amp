using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.IntegrationTests.Infrastructure;

namespace Html2Amp.IntegrationTests.Tests.ImageSanitizerTests
{
	[TestClass]
	public class ImageSanitization
	{
		[TestMethod]
		public void ImageSanitizationWithImageSizes()
		{
			// Arrange
			const string TestName = "ImageSanitizationWithImageSizes";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			Assert.AreEqual(actualResult, TestDataProvider.GetOutFile(TestName));
			AmpAssert.IsValidAmp(TestName);
		}
	}
}