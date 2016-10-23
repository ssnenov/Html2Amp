using AngleSharp.Dom;
using Html2Amp.UnitTests.Spies;

namespace Html2Amp.UnitTests.Accessors
{
	public class MediaSanitizerAccessor : MediaSanitizerSpy
	{
		public MediaSanitizerAccessor(bool shoulRequestResourcesOnlyViaHttps = false)
			: base(shoulRequestResourcesOnlyViaHttps)
		{
		}

		public new bool ShoulRequestResourcesOnlyViaHttps
		{
			get
			{
				return base.ShoulRequestResourcesOnlyViaHttps;
			}
		}

		public new void SetElementLayout(IElement element, IElement ampElement)
		{
			base.SetElementLayout(element, ampElement);
		}

		public new void SetMediaElementLayout(IElement element, IElement ampElement)
		{
			base.SetMediaElementLayout(element, ampElement);
		}

		public new void RewriteSourceAttribute(IElement htmlElement)
		{
			base.RewriteSourceAttribute(htmlElement);
		}

		public new IElement SanitizeCore<T>(IDocument document, IElement htmlElement, string ampElementTagName)
		where T : IElement
		{
			return base.SanitizeCore<T>(document, htmlElement, ampElementTagName);
		}
	}
}