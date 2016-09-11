using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;

namespace Html2Amp.UnitTests.TargetAttributeSanitizerTests
{
	[TestClass]
	public class TargetAttributeSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThrowException_WhenHtmlElementArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new TargetAttributeSanitizer().Sanitize(null, null), "htmlElement");
		}

		[TestMethod]
		public void SetTargetAttributeToBlank()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateAnchor();

			// Act
			var actualResult = new TargetAttributeSanitizer().Sanitize(ElementFactory.Document, htmlElement);

			// Assert
			Assert.IsTrue(htmlElement.HasAttribute("target"));
			Assert.AreEqual("_blank", htmlElement.GetAttribute("target"));
		}
	}
}