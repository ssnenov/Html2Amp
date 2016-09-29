using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.UnitTests.Helpers;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Accessors;

namespace Html2Amp.UnitTests.ImageSanitizerTests
{
	[TestClass]
	public class ImageSanitizer_DownloadImage_Should
	{
		[TestMethod]
		public void ThrowException_WhenImageUrlIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ImageSanitizerAccessor().DownloadImage(null), "imageUrl");
		}

		[TestMethod]
		public void ThrowException_WhenImageUrlIsEmptyString()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ImageSanitizerAccessor().DownloadImage(string.Empty), "imageUrl");
		}
	}
}