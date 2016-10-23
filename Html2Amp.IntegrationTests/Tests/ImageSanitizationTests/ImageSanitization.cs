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
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void ImageSanitizationWithoutImageSizesAndShouldNotDownloadImages()
		{
			// Arrange
			const string TestName = "ImageSanitizationWithoutImageSizesAndShouldNotDownloadImages";
			var configuration = new RunConfiguration { ShouldDownloadImages = false };

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(configuration, TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void ImageSanitizationWithoutImageSizesAndWithAbsoluteUrl()
		{
			// Arrange
			const string TestName = "ImageSanitizationWithoutImageSizesAndWithAbsoluteUrl";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void ImageSanitizationWithStyleDisplayNone()
		{
			// Arrange
			const string TestName = "ImageSanitizationWithStyleDisplayNone";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void ImageSanitizationWithStyleVisibilityHidden()
		{
			// Arrange
			const string TestName = "ImageSanitizationWithStyleVisibilityHidden";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}