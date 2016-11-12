using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.IntegrationTests.Infrastructure;

namespace Html2Amp.IntegrationTests.Tests.ImageSanitizerTests
{
	[TestClass]
	public class IframeSanitization
	{
		[TestMethod]
		public void IFrameSanitizationWithSourceHostEqualToContainerHost()
		{
			// Arrange
			const string TestName = "IFrameSanitizationWithSourceHostEqualToContainerHost";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(new RunConfiguration { RelativeUrlsHost = "http://mydomain.com" }, TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void IFrameSanitizationWithSourceHostNotEqualToContainerHost()
		{
			// Arrange
			const string TestName = "IFrameSanitizationWithSourceHostNotEqualToContainerHost";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(new RunConfiguration { RelativeUrlsHost = "http://different-domain.com" }, TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}