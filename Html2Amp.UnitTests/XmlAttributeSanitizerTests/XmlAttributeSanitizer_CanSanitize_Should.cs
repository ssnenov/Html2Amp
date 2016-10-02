using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.XmlAttributeSanitizerTests
{
    [TestClass]
    public class XmlAttributeSanitizer_CanSanitize_Should
    {
        [TestMethod]
        public void ReturnFalse_WhenTheHtmlElementIsNull()
        {
            // Act
            var actualResult = new XmlAttributeSanitizer().CanSanitize(null);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnFalse_WhenTheHtmlElementHasNoAttributeStartingWithXml()
        {
            // Act
            var actualResult = new XmlAttributeSanitizer().CanSanitize(ElementFactory.CreateAnchor());

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnTrue_WhenTheHtmlElementHasAnAttributeStartingWithXml()
        {
            // Arrange
            var htmlString = "<p xml:space=\"preserve\">Some text</p>";
            var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

            // Act
            var actualResult = new XmlAttributeSanitizer().CanSanitize(htmlElement);

            // Assert
            Assert.IsTrue(actualResult);
        }
    }
}