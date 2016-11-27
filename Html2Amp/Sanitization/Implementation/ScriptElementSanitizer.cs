using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;

namespace Html2Amp.Sanitization.Implementation
{
	public class ScriptElementSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			return element != null && element is IHtmlScriptElement;
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.Parent.RemoveChild(htmlElement);

			return null;
		}
	}
}