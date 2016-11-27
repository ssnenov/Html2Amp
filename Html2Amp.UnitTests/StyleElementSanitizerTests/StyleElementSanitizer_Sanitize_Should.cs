using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.StyleElementSanitizerTests
{
	[TestClass]
	public class StyleElementSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThrowException_WhenHtmlElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new StyleElementSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
		}

		[TestMethod]
		public void ReturnNull_WhenStyleElementIsRemoved()
		{
			// Arrange
			var parentElement = ElementFactory.CreateAnchor();
			var styleElement = ElementFactory.CreateStyle();

			parentElement.AppendChild(styleElement);

			// Act
			var actualResult = new StyleElementSanitizer().Sanitize(null, styleElement);

			// Assert
			Assert.IsNull(actualResult);
		}

		[TestMethod]
		public void RemoveStyleElement()
		{
			// Arrange
			var parentElement = ElementFactory.CreateAnchor();
			var styleElement = ElementFactory.CreateStyle();

			parentElement.AppendChild(styleElement);

			// Act
			new StyleElementSanitizer().Sanitize(null, styleElement);

			// Assert
			Assert.AreEqual(0, parentElement.Children.Length);
		}
	}
}