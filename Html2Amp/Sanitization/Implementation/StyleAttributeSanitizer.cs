using AngleSharp.Dom;
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
			if(element != null)
			{
				return element.HasAttribute("style");
			}

			return false;
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			if (htmlElement == null)
			{
				throw new ArgumentNullException("htmlElement");
			}

			htmlElement.RemoveAttribute("style");

			return htmlElement;
		}
	}
}