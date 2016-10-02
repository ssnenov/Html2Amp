using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System.Linq;

namespace Html2Amp.Sanitization.Implementation
{
    public class JavaScriptRelatedAttributeSanitizer : Sanitizer
    {
        public override bool CanSanitize(IElement element)
        {
            return element != null
                && element.Attributes.Any(a => a.Name.StartsWith("on") 
                    && a.Name.Length > 2);
        }

        public override IElement Sanitize(IDocument document, IElement htmlElement)
        {
            Guard.Requires(htmlElement, "htmlElement").IsNotNull();

            var javascriptAttributes = htmlElement.Attributes
                .Where(a => a.Name.StartsWith("on") && a.Name.Length > 2)
                .ToList();

            foreach (var attribute in javascriptAttributes)
            {
                htmlElement.RemoveAttribute(attribute.Name);
            }

            return htmlElement;
        }
    }
}