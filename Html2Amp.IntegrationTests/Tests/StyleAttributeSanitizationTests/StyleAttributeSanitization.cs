using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.StyleAttributeSanitizationTests
{
	[TestClass]
	public class StyleAttributeSanitization
	{
		[TestMethod]
		public void StyleAttributeSanitizationInOneHtmlElement()
		{
			// Arrange
			const string TestName = "StyleAttributeSanitizationInOneHtmlElement";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void StyleAttributeSanitizationInMultipleHtmlElements()
		{
			// Arrange
			const string TestName = "StyleAttributeSanitizationInMultipleHtmlElements";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}