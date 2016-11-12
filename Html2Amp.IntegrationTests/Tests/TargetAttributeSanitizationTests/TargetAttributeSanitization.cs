using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.TargetAttributeSanitizationTests
{
	[TestClass]
	public class TargetAttributeSanitization
	{
		[TestMethod]
		public void TargetAttributeSanitizationWithBlankValue()
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
		public void TargetAttributeSanitizationWithoutValue()
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
		public void TargetAttributeSanitizationWithFrameNameValue()
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
		public void TargetAttributeSanitizationWithParentValue()
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
		public void TargetAttributeSanitizationWithSelfValue()
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
		public void TargetAttributeSanitizationWithTopValue()
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