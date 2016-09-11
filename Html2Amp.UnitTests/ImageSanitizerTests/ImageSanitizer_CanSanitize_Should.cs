using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;

namespace Html2Amp.UnitTests.ImageSanitizerTests
{
	[TestClass]
	public class ImageSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenElementArgumentIsNull()
		{
			// Act
			var actualResult = new ImageSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementArgumentIsNotImageElement()
		{
			// Arrange
			var htmlElement = ElementFactory.Create("div");

			// Act
			var actualResult = new ImageSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenElementIsImageElement()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateImage();

			// Act
			var actualResult = new ImageSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}