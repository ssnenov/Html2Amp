using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Html2Amp.UnitTests.Spies;
using Html2Amp.UnitTests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Html2Amp.UnitTests.ImageSanitizerTests
{
	[TestClass]
	public class ImageSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThowArgumentNullException_WhenDocumentArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ImageSanitizer().Sanitize(null, ElementFactory.CreateImage()), "document");
		}

		[TestMethod]
		public void ThowArgumentNullException_WhenHtmlElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ImageSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
		}

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
		public void SetImageSizeMethodIsCalled_WhenWidthIsNotSpecifiedAndShouldDownloadImagesEqualsTrue()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration { ShouldDownloadImages = true });

			var imageSanitizerSpy = new ImageSanitizerSpy();
			imageSanitizerSpy.Configure(runContext);

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
		public void SetImageSizeMethodIsCalled_WhenHeightIsNotSpecifiedAndShouldDownloadImagesEqualsTrue()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration { ShouldDownloadImages = true });

			var imageSanitizerSpy = new ImageSanitizerSpy();
			imageSanitizerSpy.Configure(runContext);
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
		public void SetImageSizeMethodIsCalled_WhenHeightAndWeightAreNotSpecifiedAndShouldDownloadImagesEqualsTrue()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration { ShouldDownloadImages = true });

			var imageSanitizerSpy = new ImageSanitizerSpy();
			imageSanitizerSpy.Configure(runContext);
			var imageElement = ElementFactory.CreateImage();

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizerSpy.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.IsTrue(imageSanitizerSpy.SetImageSizeCalled);
		}

		[TestMethod]
		[Ignore]
		// TODO: Remove "Ignore" attribute when we set the absolute url of images always.
		public void ResolveImageUrl_WhenSourceAttributeIsRelative()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com" });

			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "/images/logo.png";

			var imageSanitizer = new ImageSanitizerTestDouble();
			imageSanitizer.Configure(runContext);
			imageSanitizer.DownloadImageResult = (imageUrl) => null;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual("http://mywebsite.com/images/logo.png", ampElement.GetAttribute("src"));
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ThrowInvalidOperationException_WhenTheImageHasNoWidthAndHeightAndTheImageUrlIsInvalid()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration { ShouldDownloadImages = true });

			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "/images/logo.png";

			var imageSanitizer = new ImageSanitizerTestDouble();
			imageSanitizer.Configure(runContext);
			imageSanitizer.DownloadImageResult = (imageUrl) => null;

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);
		}

		[TestMethod]

		public void SetImageWidth_WhenItIsNotSpecifiedAndTheImageUrlIsValidAndShouldDownloadImagesEqualsTrue()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com", ShouldDownloadImages = true });

			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "/images/logo.png";

			var imageSanitizer = new ImageSanitizerTestDouble();
			imageSanitizer.Configure(runContext);
			imageSanitizer.DownloadImageResult = (imageUrl) => new Bitmap(100, 200);

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(100, int.Parse(ampElement.GetAttribute("width")));
		}

		public void SetImageHeight_WhenItIsNotSpecifiedAndTheImageUrlIsValid()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com" });

			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "/images/logo.png";

			var imageSanitizer = new ImageSanitizerTestDouble();
			imageSanitizer.Configure(runContext);
			imageSanitizer.DownloadImageResult = (imageUrl) => new Bitmap(100, 200);

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(200, int.Parse(ampElement.GetAttribute("height")));
		}

		[TestMethod]
		public void ReturnAmpImageElementWithLayoutAttributeSetToFixedHeight_IfTheOriginalIFrameElementHasOnlyHeightAttributeAndShouldDownloadImagesIsNotSpecified()
		{
			// Arrange
			const string ExpectedResult = "fixed-height";
			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "http://www.mywebsite.com/img1.jpg";
			imageElement.DisplayHeight = 100;

			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var actualResult = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
		}

		[TestMethod]
		public void ReturnAmpImageElementWithLayoutAttributeSetToFill_IfTheOriginalImageElementHasNoWidthAndHeightAttributesAndShouldDownloadImagesIsNotSpecified()
		{
			// Arrange
			const string ExpectedResult = "fill";
			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "http://www.mywebsite.com/img1.jpg";

			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var actualResult = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
		}

		[TestMethod]
		public void ReturnAmpImageElementWithLayoutAttributeSetToResponsive_IfTheOriginalImageElementHasBothWidthAndHeightAttributes()
		{
			// Arrange
			const string ExpectedResult = "responsive";
			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "http://www.mywebsite.com/img1.jpg";
			imageElement.DisplayWidth = 100;
			imageElement.DisplayHeight = 100;

			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var actualResult = new ImageSanitizer().Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
		}

		[TestMethod]
		public void ReturnAmpImageElementWithLayoutAttributeSetToResponsive_IfTheOriginalImageElementHasNoWidthAndHeightButShouldDownloadImagesEqualsTrue()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration { ShouldDownloadImages = true });

			const string ExpectedResult = "responsive";
			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "http://www.mywebsite.com/img1.jpg";

			ElementFactory.Document.Body.Append(imageElement);

			var imageSanitizer = new ImageSanitizerTestDouble();
			imageSanitizer.DownloadImageResult = (imageUrl) => new Bitmap(100, 200);
			imageSanitizer.Configure(runContext);

			// Act
			var actualResult = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
		}

		[TestMethod]
		public void PutImageWidthAndHeightInTheCache_WhenTheyAreNotSpecifiedAndAreMissingInTheCache()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com" });

			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "/images/logo1.png";

			var imageSanitizer = new ImageSanitizerTestDouble();
			imageSanitizer.Configure(runContext);
			imageSanitizer.DownloadImageResult = (imageUrl) => new Bitmap(100, 200);

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.AreEqual(1, runContext.ImagesCache.Count);
			Assert.AreEqual(100, runContext.ImagesCache["/images/logo1.png"].Width);
			Assert.AreEqual(200, runContext.ImagesCache["/images/logo1.png"].Height);
		}

		[TestMethod]
		public void NotCallDownloadImageMethod_WhenWidthAndHeightOfThatImageArePresentInTheCache()
		{
			// Arrange
			var runContext = new RunContext(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com" });
			runContext.ImagesCache["/images/logo1.png"] = new Models.Image() { Width = 100, Height = 200 };

			var imageElement = ElementFactory.CreateImage();
			imageElement.Source = "/images/logo1.png";

			var imageSanitizer = new ImageSanitizerSpy();
			imageSanitizer.Configure(runContext);
			imageSanitizer.DownloadImageResult = (imageUrl) => new Bitmap(100, 200);

			// Adding image element to the document in order to simulate real herarchy
			ElementFactory.Document.Body.Append(imageElement);

			// Act
			var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

			// Assert
			Assert.IsFalse(imageSanitizer.DownloadImageIsCalled);
		}
	}
}