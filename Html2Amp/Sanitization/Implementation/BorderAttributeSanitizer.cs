using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;

namespace Html2Amp.Sanitization.Implementation
{
	public class BorderAttributeSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			return element != null
				&& !(element is IHtmlTableElement) 
				&& !(element is IHtmlTableCellElement) 
				&& !(element is IHtmlTableRowElement)
				&& element.HasAttribute("border");
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			// TODO: export the border as css in future versions
			htmlElement.RemoveAttribute("border");

			return htmlElement;
		}
	}
}