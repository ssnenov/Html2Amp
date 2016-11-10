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
	public class GifImageSanitizer_Sanitizer_Should
	{
		[TestMethod]
		public void ReturnAmpAnimElement_WhenSourceExtensionIsGIF()
		{
			// Arrange
			const string ExpectedResult = "AMP-ANIM";
			const int ImageSize = 100;
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayWidth = ImageSize;
			imageElement.DisplayHeight = ImageSize;

			imageElement.Source = "http://mysite.com/my-animation.gif";

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = new GifImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.TagName);
		}
	}
}