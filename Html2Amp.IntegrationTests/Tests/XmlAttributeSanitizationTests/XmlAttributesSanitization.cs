using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.IntegrationTests.Infrastructure;

namespace Html2Amp.IntegrationTests.Tests.JavaScriptRelatedAttributeSanitizerTests
{
	[TestClass]
	public class XmlAttributesSanitization
	{
		[TestMethod]
		public void XmlAttributes()
		{
			// Arrange
			const string TestName = "XmlAttributesSanitization";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}