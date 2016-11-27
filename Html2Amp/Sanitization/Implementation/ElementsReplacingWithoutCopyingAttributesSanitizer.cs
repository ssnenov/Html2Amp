using System.Collections.Generic;
namespace Html2Amp.Sanitization.Implementation
{
	public class ElementsReplacingWithoutCopyingAttributesSanitizer : ElementsReplacingSanitizer
	{
		public ElementsReplacingWithoutCopyingAttributesSanitizer()
			: base(new Dictionary<string, string> { { "font", "span" } })
		{
		}

		public ElementsReplacingWithoutCopyingAttributesSanitizer(Dictionary<string, string> elementsToReplace) : 
			base(elementsToReplace)
		{
		}

		protected override bool ShouldCopyAttributes
		{
			get { return false; }
		}
	}
}