using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.UnitTests.Helpers;
using Html2Amp.UnitTests.Accessors;

namespace Html2Amp.UnitTests.YouTubeVideoSanitizerTests
{
	[TestClass]
	public class YouTubeVideoSanitizer_GetVideoId_Should
	{
		[TestMethod]
		public void ThrowArgumentException_WhenArgumentVideoUriIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new YouTubeVideoSanitizerAccessor().GetVideoId(null), "videoUri");
		}

		[TestMethod]
		public void ReturnVideoId_WhenUrlIsPassed()
		{
			// Arrange
			const string ExpectedResult = "AuA9440gjt";
			var uri = new Uri(string.Format("http://youtube.com/embed/{0}", ExpectedResult));

			// Act
			var actualResult = new YouTubeVideoSanitizerAccessor().GetVideoId(uri);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult);
		}

		[TestMethod]
		public void ReturnVideoId_WhenUrlHasTrailingSlash()
		{
			// Arrange
			const string ExpectedResult = "AuA9440gjt";
			var uri = new Uri(string.Format("http://youtube.com/embed/{0}/", ExpectedResult));

			// Act
			var actualResult = new YouTubeVideoSanitizerAccessor().GetVideoId(uri);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult);
		}

		[TestMethod]
		public void ReturnVideoId_WhenUrlHasQueryString()
		{
			// Arrange
			const string ExpectedResult = "AuA9440gjt";
			var uri = new Uri(string.Format("http://youtube.com/embed/{0}?q=1", ExpectedResult));

			// Act
			var actualResult = new YouTubeVideoSanitizerAccessor().GetVideoId(uri);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult);
		}

		[TestMethod]
		public void ReturnVideoId_WhenUrlHasMorePaths()
		{
			// Arrange
			const string ExpectedResult = "AuA9440gjt";
			var uri = new Uri(string.Format("http://youtube.com/embed/{0}/test/", ExpectedResult));

			// Act
			var actualResult = new YouTubeVideoSanitizerAccessor().GetVideoId(uri);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult);
		}
	}
}