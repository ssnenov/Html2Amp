using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.AudioSanitizerTests
{
    [TestClass]
    public class AudioSanitizer_CanSanitize_Should
    {
        [TestMethod]
        public void ReturnFalse_WhenElementArgumentIsNull()
        {
            // Act
            var actualResult = new AudioSanitizer().CanSanitize(null);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnFalse_WhenElementArgumentIsNotAudioElement()
        {
            // Arrange
            var htmlElement = ElementFactory.Create("div");

            // Act
            var actualResult = new AudioSanitizer().CanSanitize(htmlElement);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void ReturnTrue_WhenElementArgumentIsAudioElement()
        {
            // Arrange
            var htmlElement = ElementFactory.Create("audio");

            // Act
            var actualResult = new AudioSanitizer().CanSanitize(htmlElement);

            // Assert
            Assert.IsTrue(actualResult);
        }
    }
}