using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Html2Amp.UnitTests.AudioSanitizerTests
{
    [TestClass]
    public class AudioSanitizer_Sanitize_Should
    {
        [TestMethod]
        public void ThowArgumentNullException_WhenDocumentArgumentIsNull()
        {
            // Assert
            Ensure.ArgumentExceptionIsThrown(() => new AudioSanitizer().Sanitize(null, null), "document");
        }

        [TestMethod]
        public void ThowArgumentNullException_WhenHtmlElementIsNull()
        {
            // Assert
            Ensure.ArgumentExceptionIsThrown(() => new AudioSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
        }

        [TestMethod]
        public void ReturnAmpAudioElement_Always()
        {
            // Arrange
            const string ExpectedResult = "AMP-AUDIO";
            var audioElement = ElementFactory.CreateAudio();
            ElementFactory.Document.Body.Append(audioElement);

            // Act
            var actualResult = new AudioSanitizer().Sanitize(ElementFactory.Document, audioElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.TagName);
        }

        [TestMethod]
        public void ReturnAmpAudioElementWithSourceStartingWithHttps_WhenTheAudioElementHasSourceAttribute()
        {
            // Arrange
            const string ExpectedResult = "https";
            var audioElement = ElementFactory.CreateAudio();
            audioElement.Source = "http://www.mysite.com";
            ElementFactory.Document.Body.Append(audioElement);

            // Act
            var actualResult = new AudioSanitizer().Sanitize(ElementFactory.Document, audioElement);
            var ampElementSource = new Uri(actualResult.GetAttribute("src"));

            // Assert
            Assert.AreEqual(ExpectedResult, ampElementSource.Scheme);
        }

        [TestMethod]
        public void ReturnAmpAudioElementWithSourceStartingWithHttpsAndTheOtherPartOfTheUrlPreserved_WhenTheAudioElementHasSourceAttribute()
        {
            // Arrange
            const string ExpectedResult = "https://www.site.com:8082/test-resource?q=1";
            var audioElement = ElementFactory.CreateAudio();
            audioElement.Source = "http://www.site.com:8082/test-resource?q=1";
            ElementFactory.Document.Body.Append(audioElement);

            // Act
            var actualResult = new AudioSanitizer().Sanitize(ElementFactory.Document, audioElement);
            var ampElementSource = new Uri(actualResult.GetAttribute("src"));

            // Assert
            Assert.AreEqual(ExpectedResult, ampElementSource.ToString());
        }

        [TestMethod]
        public void ReturnAmpAudioElementWithLayoutAttributeSetToResponsive_IfTheOriginalAudioElementHasBothWidthAndHeightAttributesAndWidthHasValueEqualToAuto()
        {
            // Arrange
            const string ExpectedResult = "responsive";
            var audioElement = ElementFactory.CreateAudio();
            audioElement.SetAttribute("width", "auto");
            audioElement.SetAttribute("height", "100");
            ElementFactory.Document.Body.Append(audioElement);

            // Act
            var actualResult = new AudioSanitizer().Sanitize(ElementFactory.Document, audioElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }

        [TestMethod]
        public void ReturnAmpAudioElementWithLayoutAttributeSetToFixed_IfTheOriginalAudioElementHasBothWidthAndHeightAttributes()
        {
            // Arrange
            const string ExpectedResult = "fixed";
            var audioElement = ElementFactory.CreateAudio();
            audioElement.SetAttribute("width", "100");
            audioElement.SetAttribute("height", "100");
            ElementFactory.Document.Body.Append(audioElement);

            // Act
            var actualResult = new AudioSanitizer().Sanitize(ElementFactory.Document, audioElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }

        [TestMethod]
        public void ReturnAmpAudioElementWithLayoutAttributeSetToFixedHeight_IfTheOriginalAudioElementHasOnlyHeightAttributeSpecified()
        {
            // Arrange
            const string ExpectedResult = "fixed-height";
            var audioElement = ElementFactory.CreateAudio();
            audioElement.SetAttribute("height", "100");
            ElementFactory.Document.Body.Append(audioElement);

            // Act
            var actualResult = new AudioSanitizer().Sanitize(ElementFactory.Document, audioElement);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }
    }
}