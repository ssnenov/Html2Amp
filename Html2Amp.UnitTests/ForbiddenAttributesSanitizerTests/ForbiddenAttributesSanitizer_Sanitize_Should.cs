using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.ForbiddenAttributesSanitizerTests
{
	[TestClass]
	public class ForbiddenAttributesSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThorwArgumentNullException_WhenTheElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ForbiddenAttributesSanitizer().Sanitize(null, null), "htmlElement");
		}

		[TestMethod]
		public void RemoveForbiddenAttribute_Always()
		{
			// Arange
			var element = ElementFactory.Create("div");
			element.SetAttribute("align", "left");

			// Act
			var actualResult = new ForbiddenAttributesSanitizer().Sanitize(ElementFactory.Document, element);

			// Assert
			Assert.IsFalse(actualResult.HasAttribute("align"));
		}
	}
}