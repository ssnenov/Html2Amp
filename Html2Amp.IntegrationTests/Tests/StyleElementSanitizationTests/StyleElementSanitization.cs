using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.StyleElementSanitizationTests
{
	[TestClass]
	public class StyleElementSanitization
	{
		[TestMethod]
		public void StyleElementSanitizationWithMultipleStyleTags()
		{
			// Arrange
			const string TestName = "StyleElementSanitizationWithMultipleStyleTags";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}