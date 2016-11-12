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
			string testName = TestNameResolver.GetCurrentTestName();

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(new RunConfiguration { RelativeUrlsHost = "http://mydomain.com" }, testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}

		[TestMethod]
		public void IFrameSanitizationWithSourceHostNotEqualToContainerHost()
		{
			// Arrange
			string testName = TestNameResolver.GetCurrentTestName();

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(new RunConfiguration { RelativeUrlsHost = "http://different-domain.com" }, testName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(testName), actualResult);
			AmpAssert.IsValidAmp(testName);
		}
	}
}