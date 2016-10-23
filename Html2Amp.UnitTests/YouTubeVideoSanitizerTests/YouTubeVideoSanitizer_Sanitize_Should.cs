using AngleSharp.Dom.Html;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.YouTubeVideoSanitizerTests
{
	[TestClass]
	public class YouTubeVideoSanitizer_Sanitize_Should
	{
		private const string VideoId = "d8fr3AdK_tQ4";

		[TestMethod]
		public void ThrowException_WhenDocumentArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new YouTubeVideoSanitizer().Sanitize(null, null), "document");
		}

		[TestMethod]
		public void ThrowException_WhenHtmlElementArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
		}

		[TestMethod]
		public void ReturnAmpYouTubeElement()
		{
			// Arrange
			const string ExpectedResult = "AMP-YOUTUBE";
			var iframe = this.CreateIFrame();

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.TagName);
		}

		[TestMethod]
		public void ReturnAmpYouTubeElementWithAttributeDataVideoId()
		{
			// Arrange
			var iframe = this.CreateIFrame();

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(VideoId, actualResult.GetAttribute("data-videoid"));
		}

		[TestMethod]
		public void ReturnAmpYouTubeElementWithAttributeLayoutEqualToFill_WhenWidthAndHeightAreNotSpecified()
		{
			// Arrange
            const string ExpectedResult = "fill";
			var iframe = this.CreateIFrame();

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
		}

        [TestMethod]
        public void ReturnAmpYouTubeElementWithAttributeLayoutEqualToResponsive_WhenBothWidthAndHeightAreSpecified()
        {
            // Arrange
            const string ExpectedResult = "responsive";
            var iframe = this.CreateIFrame();
            iframe.DisplayHeight = 100;
            iframe.DisplayWidth = 100;

            // Act
            var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }

        [TestMethod]
        public void ReturnAmpYouTubeElementWithAttributeLayoutEqualToFixedHeight_WhenOnlyHeighIsSpecified()
        {
            // Arrange
            const string ExpectedResult = "fixed-height";
            var iframe = this.CreateIFrame();
            iframe.DisplayHeight = 100;

            // Act
            var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

            // Assert
            Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
        }

		[TestMethod]
		public void ReturnAmpYouTubeElementWithAttributeLayoutEqualToNoDisplay_WhenTheIframeHasStyleDisplayNone()
		{
			// Arrange
			const string ExpectedResult = "nodisplay";
			var iframe = this.CreateIFrame();
			iframe.DisplayHeight = 100;
			iframe.SetAttribute("style", "display:none");

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
		}

		[TestMethod]
		public void ReturnAmpYouTubeElementWithAttributeLayoutEqualToNoDisplay_WhenTheIframeHasStyleVisibilityHidden()
		{
			// Arrange
			const string ExpectedResult = "nodisplay";
			var iframe = this.CreateIFrame();
			iframe.DisplayHeight = 100;
			iframe.SetAttribute("style", "visibility:hidden");

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("layout"));
		}

		[TestMethod]
		public void ReturnAmpYouTubeElementWithAttributeWidth()
		{
			// Arrange
			const string ExpectedResult = "30";
			var iframe = this.CreateIFrame();
			iframe.DisplayWidth = 30;

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("width"));
		}

		[TestMethod]
		public void ReturnAmpYouTubeElementWithAttributeHeight()
		{
			// Arrange
			const string ExpectedResult = "50";
			var iframe = this.CreateIFrame();
			iframe.DisplayHeight = 50;

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("height"));
		}

		[TestMethod]
		public void ReturnAmpYouTubeElementWithAttributeId()
		{
			// Arrange
			const string ExpectedResult = "ytbPlayer";
			var iframe = this.CreateIFrame();
			iframe.Id = "ytbPlayer";

			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("id"));
		}

		[TestMethod]
		public void ReplaceIFrameWithAmpYouTubeElement()
		{
			// Arrange
			var iframe = this.CreateIFrame();
			var iframeParent = iframe.Parent;
			// Act
			var actualResult = new YouTubeVideoSanitizer().Sanitize(ElementFactory.Document, iframe);

			// Assert
			Assert.AreEqual(1, iframeParent.ChildNodes.Length);
			Assert.AreEqual("AMP-YOUTUBE", actualResult.TagName);
		}

		private IHtmlInlineFrameElement CreateIFrame()
		{
			var iframe = ElementFactory.CreateIFrame();
			iframe.Source = string.Format("http://youtube.com/embed/{0}", VideoId);

			var parent = ElementFactory.CreateAnchor();
			parent.AppendChild(iframe);

			return iframe;
		}
	}
}