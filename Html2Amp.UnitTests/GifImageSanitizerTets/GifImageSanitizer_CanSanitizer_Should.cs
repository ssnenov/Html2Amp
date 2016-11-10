using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.GifImageSanitizerTets
{
	[TestClass]
	public class GifImageSanitizer_CanSanitizer_Should
	{
		[TestMethod]
		public void ReturnTrue_WhenSourceExtensionIsGIF()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			imageElement.Source = "http://mysite.com/my-animation.gif";

			// Act
			var actualResult = new GifImageSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsTrue(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenSourceExtensionIsNotGIF()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			imageElement.Source = "http://mysite.com/my-animation.png";

			// Act
			var actualResult = new GifImageSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenSourceExtensionIsGIFWithQueryString()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			imageElement.Source = "http://mysite.com/my-animation.gif?q1=1&q2=2";

			// Act
			var actualResult = new GifImageSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsTrue(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenSourceExtensionIsRelative()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			imageElement.Source = "/my-animation.gif?a=b";

			// Act
			var actualResult = new GifImageSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsTrue(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenSourceExtensionIsNotWellFormated()
		{
			// Arrange
			var imageElement = ElementFactory.CreateImage();

			imageElement.Source = "not \\ well formated& URL";

			// Act
			var actualResult = new GifImageSanitizer().CanSanitize(imageElement);

			// Assert
			Assert.IsFalse(actualResult);
		}
	}
}