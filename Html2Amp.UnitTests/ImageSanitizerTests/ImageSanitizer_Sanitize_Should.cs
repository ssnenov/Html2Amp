using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.UnitTests.Helpers;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Spies;

namespace Html2Amp.UnitTests.ImageSanitizerTests
{
	[TestClass]
	public class ImageSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ReturnAmpImageElement()
		{
			// Arrange
			const int ImageSize = 100;
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayWidth = ImageSize;
			imageElement.DisplayHeight = ImageSize;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual("AMP-IMG", ampElement.TagName);
		}

		[TestMethod]
		public void ReturnAmpImageElementWithPredefinedWidth_WhenWidthAndHeightAreSpecified()
		{
			// Arrange
			const int ImageSize = 100;
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayWidth = ImageSize;
			imageElement.DisplayHeight = ImageSize;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			int actualWidth = int.Parse(ampElement.GetAttribute("width"));
			Assert.AreEqual(ImageSize, actualWidth);
		}

		[TestMethod]
		public void ReturnAmpImageElementWithPredefinedHeight_WhenWidthAndHeightAreSpecified()
		{
			// Arrange
			const int ImageSize = 100;
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayWidth = ImageSize;
			imageElement.DisplayHeight = ImageSize;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			int actualHeight = int.Parse(ampElement.GetAttribute("height"));
			Assert.AreEqual(ImageSize, actualHeight);
		}

		[TestMethod]
		public void ReturnAmpAnimElement_WhenSourceExtensionIsGIF()
		{
			// Arrange
			const int ImageSize = 100;
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayWidth = ImageSize;
			imageElement.DisplayHeight = ImageSize;

			imageElement.Source = "http://mysite.com/my-animation.gif";

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual("AMP-ANIM", ampElement.TagName);
		}

		[TestMethod]
		public void ReturnAmpImageElementWithLayoutEqualToResponsive_WhenWidthAndHeightAreSpecified()
		{
			// Arrange
			const int ImageSize = 100;
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayWidth = ImageSize;
			imageElement.DisplayHeight = ImageSize;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual("responsive", ampElement.GetAttribute("layout"));
		}

		[TestMethod]
		public void SetImageSizeMethodIsCalled_WhenWidthIsNotSpecified()
		{
			// Arrange
			var imageSanitizerSpy = new ImageSanitizerSpy();
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayHeight = 100;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizerSpy.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.IsTrue(imageSanitizerSpy.SetImageSizeCalled);
		}

		[TestMethod]
		public void SetImageSizeMethodIsCalled_WhenHeightIsNotSpecified()
		{
			// Arrange
			var imageSanitizerSpy = new ImageSanitizerSpy();
			var imageElement = ElementFactory.CreateImage();

			imageElement.DisplayWidth = 100;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizerSpy.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.IsTrue(imageSanitizerSpy.SetImageSizeCalled);
		}

		[TestMethod]
		public void SetImageSizeMethodIsCalled_WhenHeightAndWeightAreNotSpecified()
		{
			// Arrange
			var imageSanitizerSpy = new ImageSanitizerSpy();
			var imageElement = ElementFactory.CreateImage();

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizerSpy.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.IsTrue(imageSanitizerSpy.SetImageSizeCalled);
		}
	}
}