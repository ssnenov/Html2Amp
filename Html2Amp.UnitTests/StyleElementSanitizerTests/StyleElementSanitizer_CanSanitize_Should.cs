using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.StyleElementSanitizerTests
{
	[TestClass]
	public class StyleElementSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNull()
		{
			// Act
			var actualResult = new StyleElementSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNotStyleElement()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			// Act
			var actualResult = new StyleElementSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenHtmlElementIsStyleElement()
		{
			// Arrange
			var styleElement = ElementFactory.CreateStyle();

			// Act
			var actualResult = new StyleElementSanitizer().CanSanitize(styleElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}