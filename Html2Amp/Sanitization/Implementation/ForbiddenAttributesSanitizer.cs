using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System.Linq;

namespace Html2Amp.Sanitization.Implementation
{
	public class ForbiddenAttributesSanitizer : Sanitizer
	{
		private readonly string[] forbiddenAttributes = { "align", "frameborder" };

		public override bool CanSanitize(IElement element)
		{
			return element != null && element.Attributes
				.Select(x => x.Name).Intersect(this.forbiddenAttributes).Count() > 0;
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			var attributesToRemove = htmlElement.Attributes.Select(x => x.Name)
				.Intersect(this.forbiddenAttributes).ToList();

			foreach (var attribute in attributesToRemove)
			{
				htmlElement.RemoveAttribute(attribute);
			}

			return htmlElement;
		}
	}
}