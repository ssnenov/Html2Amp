using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;

namespace Html2Amp.UnitTests.ScriptElementSanitizerTests
{
	[TestClass]
	public class ScriptElementSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNull()
		{
			// Act
			var actualResult = new ScriptElementSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNotScirptElement()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			// Act
			var actualResult = new ScriptElementSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenHtmlElementIsScirptElement()
		{
			// Arrange
			var scriptElement = ElementFactory.CreateScript();

			// Act
			var actualResult = new ScriptElementSanitizer().CanSanitize(scriptElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}