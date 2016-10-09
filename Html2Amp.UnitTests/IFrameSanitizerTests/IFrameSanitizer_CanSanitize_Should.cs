using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Html2Amp.UnitTests.IFrameSanitizerTests
{
    [TestClass]
    public class IFrameSanitizer_CanSanitize_Should
    {
        [TestMethod]
        public void ReturnFalse_WhenElementArgumentIsNull()
        {
            // Act
            var actualResult = new IFrameSanitizer().CanSanitize(null);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnFalse_WhenElementArgumentIsNotIFrameElement()
        {
            // Arrange
            var htmlElement = ElementFactory.Create("div");

            // Act
            var actualResult = new IFrameSanitizer().CanSanitize(htmlElement);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnTrue_WhenElementIsIFrameElementAndTheSourceIsDifferentThanTheDocumentsSource()
        {
            // Arrange
            var htmlElement = ElementFactory.CreateIFrame();
            htmlElement.Source = "https://www.example.com/example-source";

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(new RunConfiguration { RelativeUrlsHost = "https://www.mywebsite.com" });

            // Act
            var actualResult = iframeSanitizer.CanSanitize(htmlElement);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void ReturnTrue_WhenElementIsIFrameElementAndTheSourceEqualsTheDocumentSourceAndAllowSameOriginIsSpecified()
        {
            // Arrange
            var htmlString = "<iframe src=\"http://www.mywebsite.com/example-resource\" sandbox=\"allow-same-origin\" />";
            var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(new RunConfiguration { RelativeUrlsHost = "https://www.mywebsite.com" });

            // Act
            var actualResult = iframeSanitizer.CanSanitize(htmlElement);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void ReturnFalse_WhenElementIsIFrameElementAndTheSourceEqualsTheDocumentSourceAndAllowSameOriginIsNotSpecified()
        {
            // Arrange
            var htmlElement = ElementFactory.CreateIFrame();
            htmlElement.Source = "http://www.mywebsite.com/example-resource";

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(new RunConfiguration { RelativeUrlsHost = "https://www.mywebsite.com" });

            // Act
            var actualResult = iframeSanitizer.CanSanitize(htmlElement);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnFalse_WhenElementIsIFrameElementButRunConfigurationIsMissing()
        {
            // Arrange
            var htmlElement = ElementFactory.CreateIFrame();
            htmlElement.Source = "http://www.example.com/example-resource";

            var iframeSanitizer = new IFrameSanitizer();

            // Act
            var actualResult = iframeSanitizer.CanSanitize(htmlElement);

            // Assert
            Assert.IsFalse(actualResult);
        }
    }
}