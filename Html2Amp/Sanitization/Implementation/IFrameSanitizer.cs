using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using System;

namespace Html2Amp.Sanitization.Implementation
{
    public class IFrameSanitizer : Sanitizer
    {
        public override bool CanSanitize(IElement element)
        {
            return element != null && element is IHtmlInlineFrameElement;
        }

        public override IElement Sanitize(IDocument document, IElement htmlElement)
        {
            Guard.Requires(document, "document").IsNotNull();
            Guard.Requires(htmlElement, "htmlElement").IsNotNull();

            var iframeElement = (IHtmlInlineFrameElement)htmlElement;
            this.SetSourceAttribute(iframeElement);

            var ampElement = document.CreateElement("amp-iframe");
            iframeElement.CopyTo(ampElement);

            if (!this.IsValidSourceAttribute(ampElement))
            {
                throw new InvalidOperationException("Iframes could not be in the same origin as the container, unless they do not specify allow-same-origin");
            }

            iframeElement.Parent.ReplaceChild(ampElement, iframeElement);

            return ampElement;
        }

        protected override void SetElementLayout(IElement element, IElement ampElement)
        {
            base.SetElementLayout(element, ampElement);

            // If the base class hasn't set a layout attribute
            if (!ampElement.HasAttribute("layout"))
            {
                if (ampElement.HasAttribute("height"))
                {
                    if (ampElement.HasAttribute("width"))
                    {
                        ampElement.SetAttribute("layout", "responsive");
                    }
                    else
                    {
                        ampElement.SetAttribute("layout", "fixed-height");
                    }
                }
                else
                {
                    ampElement.SetAttribute("layout", "container");
                }
            }
        }

        private void SetSourceAttribute(IHtmlInlineFrameElement iframeElement)
        {
            //Resources can be requested only via HTTPS
            var iframeElementSrc = new Uri(iframeElement.Source);

            if (iframeElementSrc.Scheme != "https")
            {
                var newUrl = new UriBuilder("https", iframeElementSrc.Host, iframeElementSrc.Port, iframeElementSrc.PathAndQuery).ToString();

                iframeElement.Source = newUrl;
            }
        }

        private bool IsValidSourceAttribute(IElement ampElement)
        {
            var source = new Uri(ampElement.GetAttribute("src"));
            var sandbox = ampElement.GetAttribute("sandbox");

            //amp-iframes could not be in the same origin as the container, unless they do not specify allow-same-origin.
            if (!string.IsNullOrEmpty(this.Configuration.RelativeUrlsHost))
            {
                if (this.Configuration.RelativeUrlsHost == source.Host)
                {
                    if (!string.IsNullOrEmpty(sandbox) && sandbox.Contains("allow-same-origin"))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}