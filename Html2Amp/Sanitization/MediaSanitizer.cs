using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Text;

namespace Html2Amp.Sanitization
{
    public abstract class MediaSanitizer : Sanitizer
    {
        protected virtual void SetMediaElementLayout(IElement element, IElement ampElement)
        {
            Guard.Requires(element, "element").IsNotNull();
            Guard.Requires(ampElement, "ampElement").IsNotNull();

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
                    ampElement.SetAttribute("layout", "fill");
                }
            }
        }

        protected virtual void RewriteSourceAttribute(IElement htmlElement)
        {
            //Resources can be requested only via HTTPS
            var htmlElementSrc = new Uri(htmlElement.GetAttribute("src"));

            if (htmlElementSrc.Scheme != "https")
            {
                var newUrl = new StringBuilder("https://");
                newUrl.Append(htmlElementSrc.Host);

                if (!htmlElementSrc.IsDefaultPort)
                {
                    newUrl.Append(":");
                    newUrl.Append(htmlElementSrc.Port);
                }

                newUrl.Append(htmlElementSrc.PathAndQuery);

                htmlElement.SetAttribute("src", newUrl.ToString());
            }
        }

        protected override void SetElementLayout(IElement element, IElement ampElement)
        {
            base.SetElementLayout(element, ampElement);
            this.SetMediaElementLayout(element, ampElement);
        }
    }
}