using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Html2Amp.UnitTests.XmlAttributeSanitizerTests
{
    [TestClass]
    public class XmlAttributeSanitizer_Sanitize_Should
    {
        [TestMethod]
        public void ThrowException_WhenHtmlElementIsNull()
        {
            // Assert
            Ensure.ArgumentExceptionIsThrown(() => new XmlAttributeSanitizer().Sanitize(null, null), "htmlElement");
        }

        [TestMethod]
        public void RemoveAllXmlAttributes()
        {
            // Arrange
            var htmlString = "<p xml:space=\"preserve\">Some text</p>";
            var htmlElement = ElementFactory.CreateFromHtmlString(htmlString);

            // Act
            var actualResult = new XmlAttributeSanitizer().Sanitize(null, htmlElement);
            var xmlAttributesExist = htmlElement.Attributes.Any(a => a.Name.StartsWith("xml"));

            // Assert
            Assert.IsFalse(xmlAttributesExist);
        }
    }
}