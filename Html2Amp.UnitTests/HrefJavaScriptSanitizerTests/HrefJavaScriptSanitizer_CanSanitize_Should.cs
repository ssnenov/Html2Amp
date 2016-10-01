using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;

namespace Html2Amp.UnitTests.HrefJavaScriptSanitizerTests
{
	[TestClass]
	public class HrefJavaScriptSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNull()
		{
			// Act
			var actualResult = new HrefJavaScriptSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNotIHtmlAnchor()
		{
			// Act
			var actualResult = new HrefJavaScriptSanitizer().CanSanitize(ElementFactory.CreateImage());

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHtmlElementHasNotHrefAttribute()
		{
			// Act
			var actualResult = new HrefJavaScriptSanitizer().CanSanitize(ElementFactory.CreateAnchor());

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHrefAttributeIsNotStartingWithJavaScript()
		{
			// Arrange
			var anchorElement = ElementFactory.CreateAnchor();
			anchorElement.Href = "/random-url";

			// Act
			var actualResult = new HrefJavaScriptSanitizer().CanSanitize(anchorElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenHrefAttributeIsStartingWithJavaScript()
		{
			// Arrange
			var anchorElement = ElementFactory.CreateAnchor();
			anchorElement.Href = "javascript:void(0);";

			// Act
			var actualResult = new HrefJavaScriptSanitizer().CanSanitize(anchorElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}