using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.ForbiddenAttributesSanitizerTests
{
	[TestClass]
	public class ForbiddenAttributesSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenElementArgumentIsNull()
		{
			// Act
			var actualResult = new ForbiddenAttributesSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenTheElementHasNoForbiddenAttributes()
		{
			// Arange
			var element = ElementFactory.Create("div");

			// Act
			var actualResult = new ForbiddenAttributesSanitizer().CanSanitize(element);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenTheElementHasForbiddenAttributes()
		{
			// Arange
			var element = ElementFactory.Create("div");
			element.SetAttribute("align", "center");

			// Act
			var actualResult = new ForbiddenAttributesSanitizer().CanSanitize(element);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}