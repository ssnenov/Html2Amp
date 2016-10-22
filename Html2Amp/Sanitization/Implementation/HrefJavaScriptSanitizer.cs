using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;

namespace Html2Amp.Sanitization.Implementation
{
	public class HrefJavaScriptSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			if (element == null || !(element is IHtmlAnchorElement))
			{
				return false;
			}

			var hrefAttribute = element.GetAttribute("href");
			return hrefAttribute != null && hrefAttribute.StartsWith("javascript:");
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.SetAttribute("href", "#");

			return htmlElement;
		}
	}
}