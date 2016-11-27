using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.UnitTests.Helpers;
using Html2Amp.Sanitization.Implementation;

namespace Html2Amp.UnitTests.BorderAttributeSanitizerTests
{
	[TestClass]
	public class BorderAttributeSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThorwArgumentException_WhenHtmlElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new BorderAttributeSanitizer().Sanitize(null, null), "htmlElement");
		}

		[TestMethod]
		public void RemoveBorderAttribute()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateImage();
			htmlElement.SetAttribute("border", "1");

			// Act
			var actualResult = new BorderAttributeSanitizer().Sanitize(ElementFactory.Document, htmlElement);

			// Assert
			Assert.IsFalse(htmlElement.HasAttribute("border"));
		}
	}
}