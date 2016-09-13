using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization.Implementation
{
	public class StyleAttributeSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			return element != null && element.HasAttribute("style");
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.RemoveAttribute("style");

			return htmlElement;
		}
	}
}