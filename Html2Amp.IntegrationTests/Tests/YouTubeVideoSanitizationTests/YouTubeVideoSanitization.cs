using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.YouTubeVideoSanitizationTests
{
	[TestClass]
	public class YouTubeVideoSanitization
	{
		[TestMethod]
		public void YouTubeVideoSanitizationWithWidthAndHeight()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithWidthAndHeight";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithoutWidthAndHeight()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithoutWidthAndHeight";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithHeightOnly()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithHeightOnly";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithIdAttribute()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithIdAttribute";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithOtherNotAllowedAttributes()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithOtherNotAllowedAttributes";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithDataParamsAttributes()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithDataParamsAttributes";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithStyleDisplayNone()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithStyleDisplayNone";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithStyleVisibilityHidden()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithStyleVisibilityHidden";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithChildren()
		{
			// Arrange
			const string TestName = "YouTubeVideoSanitizationWithChildren";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}