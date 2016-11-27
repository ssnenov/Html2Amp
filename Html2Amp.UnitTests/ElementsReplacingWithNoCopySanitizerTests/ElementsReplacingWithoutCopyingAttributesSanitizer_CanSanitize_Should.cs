using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.ElementsReplacingWithNoCopySanitizerTests
{
	[TestClass]
	public class ElementsReplacingWithoutCopyingAttributesSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNull()
		{
			// Act
			var actualResult = new ElementsReplacingWithoutCopyingAttributesSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNotInTheListForReplacements()
		{
			// Arrange
			var htmElement = ElementFactory.CreateFromHtmlString("<span>Some text</span>");

			// Act
			var actualResult = new ElementsReplacingWithoutCopyingAttributesSanitizer().CanSanitize(htmElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenHtmlElementIsNotInTheListForReplacements()
		{
			// Arrange
			var htmElement = ElementFactory.CreateFromHtmlString("<font size=\"3\" color=\"red\">This is some text!</font>");

			// Act
			var actualResult = new ElementsReplacingWithoutCopyingAttributesSanitizer().CanSanitize(htmElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}