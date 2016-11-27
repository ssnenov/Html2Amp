using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Html2Amp.UnitTests.ElementsReplacingWithNoCopySanitizerTests
{
	[TestClass]
	public class ElementsReplacingWithoutCopyingAttributesSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThrowException_WhenHtmlElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ElementsReplacingWithoutCopyingAttributesSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
		}

		[TestMethod]
		public void ReplaceTheElementWithItsCorrespondingElement_WhenItIsInTheReplacementList()
		{
			// Arrange
			const string ExpectedResult = "SPAN";

			var replacements = new Dictionary<string, string> { { "font", "span" } };
			var sanitizer = new ElementsReplacingWithoutCopyingAttributesSanitizer(replacements);
			var htmlString = "<font size=\"3\" color=\"red\">This is some text!</font>";
			var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

			// Act
			var actualResult = sanitizer.Sanitize(ElementFactory.Document, htmlElement);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.TagName);
		}

		[TestMethod]
		public void ShouldNotCopyTheAttributes_Always()
		{
			var htmlString = "<font size=\"3\" color=\"red\">This is some text!<span>This is another text.</span></font>";
			var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

			// Act
			var actualResult = new ElementsReplacingWithoutCopyingAttributesSanitizer().Sanitize(ElementFactory.Document, htmlElement);

			// Assert
			Assert.AreEqual(0, actualResult.Attributes.Length);
		}
	}
}