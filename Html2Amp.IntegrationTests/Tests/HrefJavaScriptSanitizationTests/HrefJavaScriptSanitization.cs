using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.HrefJavaScriptSanitizationTests
{
	[TestClass]
	public class HrefJavaScriptSanitization
	{
		[TestMethod]
		public void HrefJavaScriptSanitizationWithJavaScriptValue()
		{
			// Arrange
			const string TestName = "HrefJavaScriptSanitizationWithJavaScriptValue";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void HrefJavaScriptSanitizationWithNonJavaScriptValue()
		{
			// Arrange
			const string TestName = "HrefJavaScriptSanitizationWithNonJavaScriptValue";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}