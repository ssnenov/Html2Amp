using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization.Implementation
{
    public class IFrameSanitizer : Sanitizer
    {
        public override bool CanSanitize(IElement element)
        {
            // TODO: Implement logic for checking the iframe position in the DOM
            // and if the src attribute is a resource with https
            return element is IHtmlInlineFrameElement;
        }

        public override IElement Sanitize(IDocument document, IElement htmlElement)
        {
            throw new NotImplementedException();
        }
    }
}