using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;

namespace Html2Amp.Sanitization
{
	public abstract class Sanitizer : ISanitizer
	{
		protected RunContext RunContext { get; private set; }

		public abstract bool CanSanitize(AngleSharp.Dom.IElement element);

		public abstract IElement Sanitize(IDocument document, IElement htmlElement);

		protected virtual void SetElementLayout(IElement element, IElement ampElement)
		{
			Guard.Requires(element, "element").IsNotNull();
			Guard.Requires(ampElement, "ampElement").IsNotNull();

			// https://github.com/ampproject/amphtml/blob/master/spec/amp-html-layout.md#tldr-appendix-1-layout-table
			if (element.Style != null && (element.Style.Display == "none" || element.Style.Visibility == "hidden"))
			{
				ampElement.SetAttribute("layout", "nodisplay");
			}
		}

		public void Configure(RunContext runContext)
		{
			this.RunContext = runContext;
		}
	}
}