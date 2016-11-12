using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.IntegrationTests.Infrastructure;

namespace Html2Amp.IntegrationTests.Tests.JavaScriptRelatedAttributeSanitizerTests
{
	[TestClass]
	public class JavaScriptRelatedAttributeSanitizer
	{
		[TestMethod]
		public void JavaScriptRelatedAttribute()
		{
			// Arrange
			const string TestName = "JavaScriptRelatedAttributeSanitization";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.ConvertToString(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}