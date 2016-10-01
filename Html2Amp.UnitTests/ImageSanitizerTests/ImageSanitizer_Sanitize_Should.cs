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
            Ensure.ArgumentExceptionIsThrown(() => new ImageSanitizer().Sanitize(null, null), "document");
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

        [TestMethod]
        [Ignore]
        // TODO: Remove "Ignore" attribute when we set the absolute url of images always.
        public void ResolveImageUrl_WhenSourceAttributeIsRelative()
        {
            // Arrange
            var imageElement = ElementFactory.CreateImage();
            imageElement.Source = "/images/logo.png";

            var imageSanitizer = new ImageSanitizerTestDouble();
            imageSanitizer.Configure(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com" });
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
            var imageElement = ElementFactory.CreateImage();
            imageElement.Source = "/images/logo.png";

            var imageSanitizer = new ImageSanitizerTestDouble();
            imageSanitizer.Configure(new RunConfiguration());
            imageSanitizer.DownloadImageResult = (imageUrl) => null;

            // Adding image element to the document in order to simulate real herarchy
            ElementFactory.Document.Body.Append(imageElement);

            // Act
            var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);
        }

        [TestMethod]
       
        public void SetImageWidth_WhenTheyAreNotSpecifiedAndTheImageUrlIsValid()
        {
            // Arrange
            var imageElement = ElementFactory.CreateImage();
            imageElement.Source = "/images/logo.png";

            var imageSanitizer = new ImageSanitizerTestDouble();
            imageSanitizer.Configure(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com" });
            imageSanitizer.DownloadImageResult = (imageUrl) => new Bitmap(100, 200);

            // Adding image element to the document in order to simulate real herarchy
            ElementFactory.Document.Body.Append(imageElement);

            // Act
            var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

            // Assert
            Assert.AreEqual(100, int.Parse(ampElement.GetAttribute("width")));
        }

        public void SetImageHeight_WhenTheyAreNotSpecifiedAndTheImageUrlIsValid()
        {
            // Arrange
            var imageElement = ElementFactory.CreateImage();
            imageElement.Source = "/images/logo.png";

            var imageSanitizer = new ImageSanitizerTestDouble();
            imageSanitizer.Configure(new RunConfiguration() { RelativeUrlsHost = "http://mywebsite.com" });
            imageSanitizer.DownloadImageResult = (imageUrl) => new Bitmap(100, 200);

            // Adding image element to the document in order to simulate real herarchy
            ElementFactory.Document.Body.Append(imageElement);

            // Act
            var ampElement = imageSanitizer.Sanitize(ElementFactory.Document, imageElement);

            // Assert
            Assert.AreEqual(200, int.Parse(ampElement.GetAttribute("height")));
        }
    }
}