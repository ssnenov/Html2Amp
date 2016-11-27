using AngleSharp.Dom;
using AngleSharp.Html;
using ComboRox.Core.Utilities.SimpleGuard;

namespace Html2Amp.Sanitization.Implementation
{
	public class StyleAttributeSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			return element != null && element.HasAttribute(AttributeNames.Style);
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.RemoveAttribute(AttributeNames.Style);

			return htmlElement;
		}
	}
}