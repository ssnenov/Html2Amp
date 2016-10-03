using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.UnitTests.Accessors;
using Html2Amp.UnitTests.Helpers;
using System.Collections.Specialized;

namespace Html2Amp.UnitTests.YouTubeVideoSanitizerTests
{
	[TestClass]
	public class YouTubeVideoSanitizer_SetVideoParams_Should
	{
		[TestMethod]
		public void ThrowArgumentException_WhenArgumentAmpElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new YouTubeVideoSanitizerAccessor().SetVideoParams(null, null), "ampElement");
		}

		[TestMethod]
		public void ThrowArgumentException_WhenArgumentVideoParamsIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new YouTubeVideoSanitizerAccessor().SetVideoParams(ElementFactory.CreateImage(), null), "videoParams");
		}

		[TestMethod]
		public void SetDataAttributes_WhenVideoParamsArePassed()
		{
			// Arrange
			var ampElement = ElementFactory.CreateIFrame();

			var videoParams = new NameValueCollection();
			videoParams["first"] = "1";
			videoParams["second"] = "2";

			// Act
			new YouTubeVideoSanitizerAccessor().SetVideoParams(ampElement, videoParams);

			// Assert
			Assert.AreEqual("1", ampElement.GetAttribute("data-param-first"));
			Assert.AreEqual("2", ampElement.GetAttribute("data-param-second"));
		}
	}
}