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
	}
}