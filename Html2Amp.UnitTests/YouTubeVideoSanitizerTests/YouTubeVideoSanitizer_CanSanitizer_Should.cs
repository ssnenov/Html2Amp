using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;

namespace Html2Amp.UnitTests.YouTubeVideoSanitizerTests
{
	[TestClass]
	public class YouTubeVideoSanitizer_CanSanitizer_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenElementIsNull()
		{
			// Act
			var actualResult = new YouTubeVideoSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenHtmlElementIsNotIFrame()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateAnchor();

			// Act
			var actualResult = new YouTubeVideoSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenIFrameHasNotSourceAttribute()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();

			// Act
			var actualResult = new YouTubeVideoSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenSourceAttributeIsNotYouTubeDomain()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();
			htmlElement.Source = "mydomain.com";

			// Act
			var actualResult = new YouTubeVideoSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenSourceAttributeIsNotEmbedUrlPath()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();
			htmlElement.Source = "http://youtube.com/not-valid/url-path";

			// Act
			var actualResult = new YouTubeVideoSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenSourceAttributeIsYouTubeDomainAndUrlPathIsEmbedWithYouTubeId()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();
			htmlElement.Source = "http://youtube.com/embed/d8fr3AdK_tQ4";

			// Act
			var actualResult = new YouTubeVideoSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsTrue(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenSourceAttributeIsYouTubeDomainAndStartsWithWWW()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();
			htmlElement.Source = "http://www.youtube.com/embed/d8fr3AdK_tQ4";

			// Act
			var actualResult = new YouTubeVideoSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}