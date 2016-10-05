using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using Html2Amp.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization.Implementation
{
    public class ImageSanitizer : Sanitizer
    {
        public override bool CanSanitize(IElement element)
        {
            return element is IHtmlImageElement;
        }

        public override IElement Sanitize(IDocument document, IElement htmlElement)
        {
            Guard.Requires(document, "document").IsNotNull();
            Guard.Requires(htmlElement, "htmlElement").IsNotNull();

            var imageElement = (IHtmlImageElement)htmlElement;
            IElement ampElement = CreateAmpElement(document, imageElement);

            imageElement.CopyTo(ampElement);

            this.SetElementLayout(imageElement, ampElement);

			imageElement.Parent.ReplaceChild(ampElement, imageElement);

            return ampElement;
        }

        private static IElement CreateAmpElement(IDocument document, IHtmlImageElement imageElement)
        {
            if (Path.GetExtension(imageElement.Source) == ".gif")
            {
                return document.CreateElement("amp-anim");
            }

            return document.CreateElement("amp-img");
        }

        protected override void SetElementLayout(IElement element, IElement ampElement)
        {
            Guard.Requires(ampElement, "ampElement").IsNotNull();

            base.SetElementLayout(element, ampElement);

            // If the base class hasn't set a layout attribute
            if (!ampElement.HasAttribute("layout"))
            {
                ampElement.SetAttribute("layout", "responsive");
                if (!ampElement.HasAttribute("width") || !ampElement.HasAttribute("height"))
                {
                    this.SetImageSize(ampElement);
                }
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
            var resultUrl = urlHander.TryResolveUrl(this.Configuration.RelativeUrlsHost, imageUrl);

            if (!string.IsNullOrEmpty(resultUrl))
            {
                var image = this.DownloadImage(resultUrl);

                if (image != null)
                {
                    // Width & Height should be dynamically generated attributes
                    htmlElement.SetAttribute("width", image.Width.ToString());
                    htmlElement.SetAttribute("height", image.Height.ToString());
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