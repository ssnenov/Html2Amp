using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.ElementsReplacingWithoutCopyingAttributesSanitizationTests
{
	[TestClass]
	public class ElementsReplacingWithoutCopyingAttributesSanitization
	{
		[TestMethod]
		public void ElementsReplacingWithoutCopyingAttributesSanitizationWithFonts()
		{
			// Arrange
			const string TestName = "ElementsReplacingWithoutCopyingAttributesSanitizationWithFonts";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(new RunConfiguration { RelativeUrlsHost = "http://mydomain.com" }, TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}