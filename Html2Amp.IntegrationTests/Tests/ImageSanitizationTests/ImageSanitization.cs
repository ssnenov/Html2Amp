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
			string testName = TestNameResolver.GetCurrentTestName();

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}

		[TestMethod]
		public void ImageSanitizationWithoutImageSizesAndShouldNotDownloadImages()
		{
			// Arrange
			string testName = TestNameResolver.GetCurrentTestName();
			var configuration = new RunConfiguration { ShouldDownloadImages = false };

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(configuration, testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}

		[TestMethod]
		public void ImageSanitizationWithoutImageSizesAndWithAbsoluteUrl()
		{
			// Arrange
			string testName = TestNameResolver.GetCurrentTestName();

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}

		[TestMethod]
		public void ImageSanitizationWithStyleDisplayNone()
		{
			// Arrange
			string testName = TestNameResolver.GetCurrentTestName();

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}

		[TestMethod]
		public void ImageSanitizationWithStyleVisibilityHidden()
		{
			// Arrange
			string testName = TestNameResolver.GetCurrentTestName();

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}
	}
}