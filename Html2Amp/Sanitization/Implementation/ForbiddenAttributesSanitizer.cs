using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System.Linq;

namespace Html2Amp.Sanitization.Implementation
{
	public class ForbiddenAttributesSanitizer : Sanitizer
	{
		private string[] forbiddenAttributes;

		public ForbiddenAttributesSanitizer()
			: this(new string[] { "align", "usemap" })
		{
		}

		public ForbiddenAttributesSanitizer(string[] forbiddenAttributes)
		{
			this.forbiddenAttributes = forbiddenAttributes;
		}

		public override bool CanSanitize(IElement element)
		{
			return element != null && element.Attributes.Any(a => this.forbiddenAttributes.Contains(a.Name));
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			foreach (var attribute in this.forbiddenAttributes)
			{
				htmlElement.RemoveAttribute(attribute);
			}

			return htmlElement;
		}
	}
}