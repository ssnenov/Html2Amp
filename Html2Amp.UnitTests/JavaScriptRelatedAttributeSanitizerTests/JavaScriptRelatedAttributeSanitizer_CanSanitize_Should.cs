using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.JavaScriptRelatedAttributeSanitizerTests
{
    [TestClass]
    public class JavaScriptRelatedAttributeSanitizer_CanSanitize_Should
    {
        [TestMethod]
        public void ReturnFalse_WhenTheHtmlElementIsNull()
        {
            // Act
            var actualResult = new JavaScriptRelatedAttributeSanitizer().CanSanitize(null);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnFalse_WhenTheHtmlElementHasNoAttributeStartingWithOnPrefix()
        {
            // Act
            var actualResult = new JavaScriptRelatedAttributeSanitizer().CanSanitize(ElementFactory.CreateAnchor());

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnTrue_WhenTheHtmlElementHasAnAttributeStartingWithOnAndItsLengthIsGreaterThanTwo()
        {
            // Arrange
            var htmlString = "<button onclick=\"myFunction()\">Click me</button>";
            var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

            // Act
            var actualResult = new JavaScriptRelatedAttributeSanitizer().CanSanitize(htmlElement);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void ReturnFalse_WhenTheHtmlElementHasAnAttributeWhichNameIsOn()
        {
            // Arrange
            var htmlString = "<button on=\"true\">Click me</button>";
            var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

            // Act
            var actualResult = new JavaScriptRelatedAttributeSanitizer().CanSanitize(htmlElement);

            // Assert
            Assert.IsFalse(actualResult);
        }
    }
}