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
			const string TestName = "TargetAttributeSanitizationWithBlankValue";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void TargetAttributeSanitizationWithFrameNameValue()
		{
			// Arrange
			const string TestName = "TargetAttributeSanitizationWithFrameNameValue";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void TargetAttributeSanitizationWithParentValue()
		{
			// Arrange
			const string TestName = "TargetAttributeSanitizationWithParentValue";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void TargetAttributeSanitizationWithSelfValue()
		{
			// Arrange
			const string TestName = "TargetAttributeSanitizationWithSelfValue";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}


		[TestMethod]
		public void TargetAttributeSanitizationWithTopValue()
		{
			// Arrange
			const string TestName = "TargetAttributeSanitizationWithTopValue";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}