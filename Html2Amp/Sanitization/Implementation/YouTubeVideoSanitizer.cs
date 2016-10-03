using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Html2Amp.Sanitization.Implementation
{
	public class YouTubeVideoSanitizer : Sanitizer
	{
		public const string VideoIdRegex = @"^/embed/(?<id>[^/\?]+)/?$";

		public override bool CanSanitize(IElement element)
		{
			// <iframe width="560" height="315" src="https://www.youtube.com/embed/znlFu_lemsU" frameborder="0" allowfullscreen></iframe>

			if (element == null || !(element is IHtmlInlineFrameElement))
			{
				return false;
			}

			var sourceAttributeValue = ((IHtmlInlineFrameElement)element).Source;

			Uri sourceUri;
			if (Uri.TryCreate(sourceAttributeValue, UriKind.Absolute, out sourceUri))
			{
				return sourceUri.LocalPath.StartsWith("/embed/")
					&& Regex.IsMatch(sourceUri.Host, @"^(www\.)?youtube\.com$");
			}

			return false;
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(document, "document").IsNotNull();
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			var ampElement = document.CreateElement("amp-youtube");

			ampElement.SetAttribute("layout", "responsive");
			ampElement.SetAttribute("width", htmlElement.GetAttribute("width"));
			ampElement.SetAttribute("height", htmlElement.GetAttribute("height"));

			Uri videoUri = new Uri(htmlElement.GetAttribute("src"));

			var videoId = this.GetVideoId(videoUri);
			ampElement.SetAttribute("data-videoid", videoId);

			var videoParams = HttpUtility.ParseQueryString(videoUri.Query);
			this.SetVideoParams(ampElement, videoParams);

			htmlElement.Parent.ReplaceChild(ampElement, htmlElement);

			return ampElement;
		}

		protected virtual void SetVideoParams(IElement ampElement, NameValueCollection videoParams)
		{
			Guard.Requires(ampElement, "ampElement").IsNotNull();
			Guard.Requires(videoParams, "videoParams").IsNotNull();

			foreach (var paramName in videoParams.AllKeys)
			{
				var ampParamAttributeName = "data-param-" + paramName;
				ampElement.SetAttribute(ampParamAttributeName, videoParams[paramName]);
			}
		}

		protected virtual string GetVideoId(Uri videoUri)
		{
			Guard.Requires(videoUri, "videoUri").IsNotNull();

			var videoIdMatch = Regex.Match(videoUri.LocalPath, VideoIdRegex);

			return videoIdMatch.Groups["id"].Value;
		}
	}
}