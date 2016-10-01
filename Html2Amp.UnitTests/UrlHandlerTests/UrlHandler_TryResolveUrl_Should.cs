using Html2Amp.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.UrlHandlerTests
{
    [TestClass]
    public class UrlHandler_TryResolveUrl_Should
    {
        public UrlHandler UrlHandler { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.UrlHandler = new UrlHandler();
        }

        [TestMethod]
        public void ReturnTheUrl_WhenTheHostIsMissingAndTheUrlIsAbsoluteAndValidAndTheProtocolIsHttp()
        {
            // Arrange
            var url = "http://mydomain.com/images/pic.jpg";

            // Act
            var actualResult = this.UrlHandler.TryResolveUrl(null, url);

            // Assert
            Assert.AreEqual("http://mydomain.com/images/pic.jpg", actualResult);
        }

        [TestMethod]
        public void ReturnTheUrl_WhenTheHostIsMissingAndTheUrlIsAbsoluteAndValidAndTheProtocolIsHttps()
        {
            // Arrange
            var url = "https://mydomain.com/images/pic.jpg";

            // Act
            var actualResult = this.UrlHandler.TryResolveUrl(null, url);

            // Assert
            Assert.AreEqual("https://mydomain.com/images/pic.jpg", actualResult);
        }

        [TestMethod]
        // TODO: Discuss if it should be the correct behaviour of the method in this case
        public void ReturnNull_WhenTheHostIsMissingAndTheUrlIsRelative()
        {
             // Arrange
            var url = "/images/pic.jpg";

            // Act
            var actualResult = this.UrlHandler.TryResolveUrl(null, url);

            // Assert
            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void ReturnNull_WhenTheHostIsMissingAndTheUrlIsInvalid()
        {
             // Arrange
            var url = "mydomain.com/images/pic.jpg";

            // Act
            var actualResult = this.UrlHandler.TryResolveUrl(null, url);

            // Assert
            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void ReturnResultUrl_WhenTheHostAndTheUrlComposeValidUrl()
        {
            // Arrange
            var host = "http://mydomain.com";
            var url = "/images/pic.jpg";

            // Act
            var actualResult = this.UrlHandler.TryResolveUrl(host, url);

            // Assert
            Assert.AreEqual("http://mydomain.com/images/pic.jpg", actualResult);
        }
    }
}