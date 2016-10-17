using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using Html2Amp.Web;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace Html2Amp.Sanitization.Implementation
{
	public class ImageSanitizer : MediaSanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			return element != null && element is IHtmlImageElement;
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			return this.SanitizeCore<IHtmlImageElement>(document, htmlElement, this.GetAmpElementTag(htmlElement));
		}

		private string GetAmpElementTag(IElement imageElement)
		{
			if (Path.GetExtension(imageElement.GetAttribute("src")) == ".gif")
			{
				return "amp-anim";
			}

			return "amp-img";
		}

		protected override void SetMediaElementLayout(IElement element, IElement ampElement)
		{
			base.SetMediaElementLayout(element, ampElement);

			if (this.RunContext != null
				&& this.RunContext.Configuration != null
				&& this.RunContext.Configuration.ShouldDownloadImages
				&& (!ampElement.HasAttribute("width") || !ampElement.HasAttribute("height")))
			{
				ampElement.SetAttribute("layout", "responsive");
				this.SetImageSize(ampElement);
			}
		}

		protected virtual void SetImageSize(IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			if (!htmlElement.HasAttribute("src"))
			{
				return;
			}

			var imageUrl = htmlElement.GetAttribute("src");
			var urlHander = new UrlHandler();
			var resultUrl = urlHander.TryResolveUrl(this.RunContext.Configuration.RelativeUrlsHost, imageUrl);

			if (!string.IsNullOrEmpty(resultUrl))
			{
				int width = -1;
				int height = -1;

				if (this.RunContext.ImagesCache.ContainsKey(imageUrl))
				{
					width = this.RunContext.ImagesCache[imageUrl].Width;
					height = this.RunContext.ImagesCache[imageUrl].Height;
				}
				else
				{
					var image = this.DownloadImage(resultUrl);

					if (image != null)
					{
						width = image.Width;
						height = image.Height;
						this.RunContext.ImagesCache[imageUrl] = new Models.Image() { Width = width, Height = height };
					}
				}

				if (width != -1 && height != -1)
				{
					// Width & Height should be dynamically generated attributes
					htmlElement.SetAttribute("width", width.ToString());
					htmlElement.SetAttribute("height", height.ToString());
				}
			}
			else
			{
				throw new InvalidOperationException(string.Format("Invaid image url: {0}", imageUrl));
			}

			//TODO: Uncomment the following line when relative urls are not allowed in AMP.
			//htmlElement.SetAttribute("src", resultUrl);
		}

		protected virtual Image DownloadImage(string imageUrl)
		{
			Guard.Requires(imageUrl, "imageUrl").IsNotNullOrEmpty();

			Image image;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(imageUrl);

				using (var memoryStream = new MemoryStream(imageBytes))
				{
					image = Image.FromStream(memoryStream);
				}
			}

			return image;
		}
	}
}