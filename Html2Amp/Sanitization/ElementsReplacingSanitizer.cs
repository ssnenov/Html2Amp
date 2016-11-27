using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System.Collections.Generic;
using System.Linq;

namespace Html2Amp.Sanitization.Implementation
{
	public abstract class ElementsReplacingSanitizer : Sanitizer
	{
		private Dictionary<string, string> elementsToReplace;

		public ElementsReplacingSanitizer()
		{
			this.elementsToReplace = new Dictionary<string, string>();
		}

		public ElementsReplacingSanitizer(Dictionary<string, string> elementsToReplace)
		{
			this.elementsToReplace = elementsToReplace;
		}

		public override bool CanSanitize(IElement element)
		{
			return element != null && this.elementsToReplace.Keys.Contains(element.TagName.ToLower());
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			var elementToReplaceWith = this.elementsToReplace[htmlElement.TagName.ToLower()];
			var newElement = document.CreateElement(elementToReplaceWith);
			newElement.InnerHtml = htmlElement.InnerHtml;

			if (this.ShouldCopyAttributes)
			{
				htmlElement.CopyAttributes(newElement);
			}

			htmlElement.Parent.ReplaceChild(newElement, htmlElement);

			return newElement;
		}

		protected abstract bool ShouldCopyAttributes { get; }
	}
}