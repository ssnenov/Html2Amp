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
			string testName = TestNameResolver.GetCurrentTestName();

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}

		[TestMethod]
		public void YouTubeVideoSanitizationWithoutWidthAndHeight()
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
		public void YouTubeVideoSanitizationWithHeightOnly()
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
		public void YouTubeVideoSanitizationWithIdAttribute()
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
		public void YouTubeVideoSanitizationWithOtherNotAllowedAttributes()
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
		public void YouTubeVideoSanitizationWithDataParamsAttributes()
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
		public void YouTubeVideoSanitizationWithStyleDisplayNone()
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
		public void YouTubeVideoSanitizationWithStyleVisibilityHidden()
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
		public void YouTubeVideoSanitizationWithChildren()
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
		public void YouTubeVideoSanitizationWithNoCookieHost()
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