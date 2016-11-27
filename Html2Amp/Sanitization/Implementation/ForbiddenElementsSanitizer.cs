using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System.Linq;

namespace Html2Amp.Sanitization.Implementation
{
	public class ForbiddenElementsSanitizer : Sanitizer
	{
		private string[] forbiddenElements;

		public ForbiddenElementsSanitizer()
			: this(new string[] { "map" })
		{
		}

		public ForbiddenElementsSanitizer(string[] forbiddenElements)
		{
			this.forbiddenElements = forbiddenElements;
		}

		public override bool CanSanitize(IElement element)
		{
			return element != null && this.forbiddenElements.Contains(element.LocalName);
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.Parent.RemoveChild(htmlElement);

			return null;
		}
	}
}