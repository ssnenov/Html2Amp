using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization.Implementation
{
	public class ScriptElementSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			return element != null && element.TagName == "SCRIPT";
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.Parent.RemoveChild(htmlElement);

			return null;
		}
	}
}