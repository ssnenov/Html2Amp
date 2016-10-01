using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.UnitTests.Helpers;
using Html2Amp.Sanitization.Implementation;

namespace Html2Amp.UnitTests.HrefJavaScriptSanitizerTests
{
	[TestClass]
	public class HrefJavaScriptSanitizer_Sanitizer_Should
	{
		[TestMethod]
		public void ThrowException_WhenHtmlElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new HrefJavaScriptSanitizer().Sanitize(null, null), "htmlElement");
		}

		[TestMethod]
		public void ReplaceHrefAttributeWithHash()
		{
			// Arrange
			var anchorElement = ElementFactory.CreateAnchor();
			anchorElement.Href = "javascript:void(0);";

			// Act
			var actualResult = new HrefJavaScriptSanitizer().Sanitize(null, anchorElement);

			// Assert
			// Using .GetAttribute("href") because AngleSharp tries to resolve absolute url and that leads to
			// about:blank/# . Explantion: https://github.com/AngleSharp/AngleSharp/issues/53
			Assert.AreEqual("#", anchorElement.GetAttribute("href"));
		}
	}
}