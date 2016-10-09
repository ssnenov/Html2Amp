using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Html2Amp.UnitTests.JavaScriptRelatedAttributeSanitizerTests
{
    [TestClass]
    public class JavaScriptRelatedAttributeSanitizer_Sanitize_Should
    {
        [TestMethod]
        public void ThrowException_WhenHtmlElementIsNull()
        {
            // Assert
            Ensure.ArgumentExceptionIsThrown(() => new JavaScriptRelatedAttributeSanitizer().Sanitize(null, null), "htmlElement");
        }

        [TestMethod]
        public void RemoveAllAttributesStartingWithOnAndLengthGreaterThanTwo()
        {
            // Arrange
            var htmlString = "<button onclick=\"myFunction()\">Click me</button>";
            var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

            // Act
            var actualResult = new JavaScriptRelatedAttributeSanitizer().Sanitize(null, htmlElement);
            var onAttributesExist = htmlElement.Attributes.Any(a => a.Name.StartsWith("on") && a.Name.Length > 2);

            // Assert
            Assert.IsFalse(onAttributesExist);
        }

        [TestMethod]
        public void NotRemoveOnAttribute()
        {
            // Arrange
            var htmlString = "<button onclick=\"myFunction()\" on=\"yes\">Click me</button>";
            var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

            // Act
            var actualResult = new JavaScriptRelatedAttributeSanitizer().Sanitize(null, htmlElement);
            var onAttributeExists = htmlElement.HasAttribute("on");

            // Assert
            Assert.IsTrue(onAttributeExists);
        }
    }
}