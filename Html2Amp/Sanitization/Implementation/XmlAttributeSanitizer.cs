using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using System.Linq;

namespace Html2Amp.Sanitization.Implementation
{
    public class XmlAttributeSanitizer : Sanitizer
    {
        public override bool CanSanitize(IElement element)
        {
            return element != null && element.Attributes.Any(a => a.Name.StartsWith("xml"));
        }

        public override IElement Sanitize(IDocument document, IElement htmlElement)
        {
            Guard.Requires(htmlElement, "htmlElement").IsNotNull();
           
            var xmlAttributes = htmlElement.Attributes.Where(a => a.Name.StartsWith("xml")).ToList();

            foreach (var xmlAttribute in xmlAttributes)
            {
                htmlElement.RemoveAttribute(xmlAttribute.Name);
            }

            return htmlElement;
        }
    }
}