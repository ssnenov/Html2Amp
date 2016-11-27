using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.ForbiddenElementsSanitizerTests
{
	[TestClass]
	public class ForbiddenElementsSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNull()
		{
			// Act
			var actualResult = new ForbiddenElementsSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNotForbidden()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			// Act
			var actualResult = new ForbiddenElementsSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenHtmlElementIsForbidden()
		{
			// Arrange
			var htmlString = @"<map name='planetmap'>
								  <area shape='rect' coords='0,0,82,126' href='sun.htm' alt='Sun'>
								  <area shape='circle' coords='90,58,3' href='mercur.htm' alt='Mercury'>
								  <area shape='circle' coords='124,58,8' href='venus.htm' alt='Venus'>
								</map>";

			var styleElement = ElementFactory.CreateFromHtmlString(htmlString);

			// Act
			var actualResult = new ForbiddenElementsSanitizer().CanSanitize(styleElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}