using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.ForbiddenElementsSanitizerTests
{
	[TestClass]
	public class ForbiddenElementsSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThrowException_WhenHtmlElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ForbiddenElementsSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
		}

		[TestMethod]
		public void ReturnNull_WhenTheForbiddenElementIsRemoved()
		{
			// Arrange
			var parentElement = ElementFactory.CreateAnchor();
			var forrbiddenElement = ElementFactory.CreateFromHtmlString("<map></map>");

			parentElement.AppendChild(forrbiddenElement);

			// Act
			var actualResult = new ForbiddenElementsSanitizer().Sanitize(null, forrbiddenElement);

			// Assert
			Assert.IsNull(actualResult);
		}

		[TestMethod]
		public void RemoveTheForbiddenElement()
		{
			// Arrange
			var parentElement = ElementFactory.CreateAnchor();
			var forbiddenElement = ElementFactory.CreateFromHtmlString("<map></map>");

			parentElement.AppendChild(forbiddenElement);

			// Act
			new ForbiddenElementsSanitizer().Sanitize(null, forbiddenElement);

			// Assert
			Assert.AreEqual(0, parentElement.Children.Length);
		}
	}
}