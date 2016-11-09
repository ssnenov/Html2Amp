using AngleSharp.Dom;
using Html2Amp.Sanitization.Implementation;
using System;
using System.Collections.Specialized;

namespace Html2Amp.UnitTests.Accessors
{
	public class YouTubeVideoSanitizerAccessor : YouTubeVideoSanitizer
	{
		public new void SetVideoParams(IElement ampElement, NameValueCollection videoParams)
		{
			base.SetVideoParams(ampElement, videoParams);
		}

		public new string GetVideoId(Uri videoUri)
		{
			return base.GetVideoId(videoUri);
		}
	}
}