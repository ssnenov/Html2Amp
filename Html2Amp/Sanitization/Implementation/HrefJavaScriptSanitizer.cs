using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization.Implementation
{
	public class HrefJavaScriptSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			return element != null
				&& element is IHtmlAnchorElement
				&& element.GetAttribute("href").StartsWith("javascript:");
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.SetAttribute("href", "#");

			return htmlElement;
		}
	}
}