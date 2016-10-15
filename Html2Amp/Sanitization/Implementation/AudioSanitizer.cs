using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;

namespace Html2Amp.Sanitization.Implementation
{
    public class AudioSanitizer : MediaSanitizer
    {
        public override bool CanSanitize(IElement element)
        {
            return element != null && element is IHtmlAudioElement;
        }

        public override IElement Sanitize(IDocument document, IElement htmlElement)
        {
            Guard.Requires(document, "document").IsNotNull();
            Guard.Requires(htmlElement, "htmlElement").IsNotNull();

            var audioElement = (IHtmlAudioElement)htmlElement;

            if (!string.IsNullOrEmpty(audioElement.Source))
            {
                this.RewriteSourceAttribute(audioElement);
            }

            var ampElement = document.CreateElement("amp-audio");
            audioElement.CopyTo(ampElement);

            this.SetElementLayout(audioElement, ampElement);

            audioElement.Parent.ReplaceChild(ampElement, audioElement);

            return ampElement;
        }

        protected override void SetMediaElementLayout(IElement element, IElement ampElement)
        {
            Guard.Requires(element, "element").IsNotNull();
            Guard.Requires(ampElement, "ampElement").IsNotNull();

            if (!ampElement.HasAttribute("layout"))
            {
                if (ampElement.HasAttribute("height"))
                {
                    if (ampElement.HasAttribute("width"))
                    {
                        if (ampElement.GetAttribute("width") == "auto")
                        {
                            ampElement.SetAttribute("layout", "responsive");
                        }
                        else
                        {
                            ampElement.SetAttribute("layout", "fixed");
                        }
                    }
                    else
                    {
                        ampElement.SetAttribute("layout", "fixed-height");
                    }
                }
            }
        }
    }
}