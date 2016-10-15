using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Html2Amp.UnitTests.IFrameSanitizerTests
{
    [TestClass]
    public class IFrameSanitizer_Sanitize_Should
    {
        [TestMethod]
        public void ThowArgumentNullException_WhenDocumentArgumentIsNull()
        {
            // Assert
            Ensure.ArgumentExceptionIsThrown(() => new IFrameSanitizer().Sanitize(null, null), "document");
        }

        [TestMethod]
        public void ThowArgumentNullException_WhenHtmlElementIsNull()
        {
            // Assert
            Ensure.ArgumentExceptionIsThrown(() => new IFrameSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
        }

        [TestMethod]
        public void ReturnAmpIFrameElement_Always()
        {
            // Arrange
            const string ExpectedResult = "AMP-IFRAME";
            var iframeElement = ElementFactory.CreateIFrame();
            iframeElement.Source = "http://www.mysite.com";
            ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(runContext);

            // Act
            var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.TagName);
        }

        [TestMethod]
        public void ReturnAmpIFrameElementWithSourceStartingWithHttps_Always()
        {
            // Arrange
            const string ExpectedResult = "https";
            var iframeElement = ElementFactory.CreateIFrame();
            iframeElement.Source = "http://www.mysite.com";
            ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(runContext);

            // Act
            var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);
            var ampElementSource = new Uri(actualResult.GetAttribute("src"));

            // Assert
            Assert.AreEqual(ExpectedResult, ampElementSource.Scheme);
        }

		[TestMethod]
		public void ReturnAmpIFrameElementWithTheSameUrlExceptTheProtocolWhenTheUrlHasNoPorts_Always()
		{
			// Arrange
			const string ExpectedResult = "https://www.mysite.com";
			var iframeElement = ElementFactory.CreateIFrame();
			iframeElement.Source = "http://www.mysite.com";
			ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

			var iframeSanitizer = new IFrameSanitizer();
			iframeSanitizer.Configure(runContext);

			// Act
			var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("src"));
		}

        [TestMethod]
        public void ReturnAmpIFrameElementWithSourceStartingWithHttpsAndTheOtherPartOfTheUrlPreserved_Always()
        {
            // Arrange
            const string ExpectedResult = "https://www.site.com:8082/test-resource?q=1";
            var iframeElement = ElementFactory.CreateIFrame();
            iframeElement.Source = "http://www.site.com:8082/test-resource?q=1";
            ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(runContext);

            // Act
            var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);
            var ampElementSource = new Uri(actualResult.GetAttribute("src"));

            // Assert
            Assert.AreEqual(ExpectedResult, ampElementSource.ToString());
        }

        [TestMethod]
        public void ReturnAmpIFrameElementWithNotChangedLayout_IfTheOriginalIFrameElementHasALayoutAttribute()
        {
            // Arrange
            const string ExpectedResult = "fill";
            var htmlString = "<iframe src=\"http://www.mywebsite.com/example-resource\" layout=\"fill\" />";
            var iframeElement = ElementFactory.CreateFromHtmlString(htmlString);
            ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(runContext);

            // Act
            var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }

        [TestMethod]
        public void ReturnAmpIFrameElementWithLayoutAttributeSetToFixedHeight_IfTheOriginalIFrameElementHasOnlyHeightAttribute()
        {
            // Arrange
            const string ExpectedResult = "fixed-height";
            var iframeElement = ElementFactory.CreateIFrame();
            iframeElement.Source = "http://www.mywebsite.com/example-resource";
            iframeElement.DisplayHeight = 100;
            ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(runContext);

            // Act
            var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }

        [TestMethod]
        public void ReturnAmpIFrameElementWithLayoutAttributeSetToFill_IfTheOriginalIFrameElementHasNoWidthAndHeightAttributes()
        {
            // Arrange
            const string ExpectedResult = "fill";
            var iframeElement = ElementFactory.CreateIFrame();
            iframeElement.Source = "http://www.mywebsite.com/example-resource";
            ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(runContext);

            // Act
            var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }

        [TestMethod]
        public void ReturnAmpIFrameElementWithLayoutAttributeSetToResponsive_IfTheOriginalIFrameElementHasBothWidthAndHeightAttributes()
        {
            // Arrange
            const string ExpectedResult = "responsive";
            var iframeElement = ElementFactory.CreateIFrame();
            iframeElement.Source = "http://www.mywebsite.com/example-resource";
            iframeElement.DisplayWidth = 100;
            iframeElement.DisplayHeight = 100;
            ElementFactory.Document.Body.Append(iframeElement);

			var runContext = new RunContext(new RunConfiguration { RelativeUrlsHost = "http://test-domain.com" });

            var iframeSanitizer = new IFrameSanitizer();
            iframeSanitizer.Configure(runContext);

            // Act
            var actualResult = iframeSanitizer.Sanitize(ElementFactory.Document, iframeElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }
    }
}