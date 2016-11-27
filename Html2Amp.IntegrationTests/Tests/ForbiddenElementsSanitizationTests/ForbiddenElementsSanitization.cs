using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.ForbiddenElementsSanitizationTests
{
	[TestClass]
	public class ForbiddenElementsSanitization
	{
		[TestMethod]
		public void ForbiddenElementsSanitizationWithMapTag()
		{
			// Arrange
			const string TestName = "ForbiddenElementsSanitizationWithMapTag";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}