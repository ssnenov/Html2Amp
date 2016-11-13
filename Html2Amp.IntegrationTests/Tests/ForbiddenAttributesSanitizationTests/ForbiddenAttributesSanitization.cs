using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.ForbiddenAttributesSanitizationTests
{
	[TestClass]
	public class ForbiddenAttributesSanitization
	{
		[TestMethod]
		public void ForbiddenAttributesSanitizationWithMultipleAttributes()
		{
			// Arrange
			const string TestName = "ForbiddenAttributesSanitizationWithMultipleAttributes";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(new RunConfiguration { RelativeUrlsHost = "http://mydomain.com" }, TestName);
			
			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}