using System;
using System.Collections.Generic;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using AngleSharp.Html;

namespace Html2Amp.Sanitization.Implementation
{
	public class AudioSanitizer : MediaSanitizer, IScriptsDependable
	{
		protected override bool ShoulRequestResourcesOnlyViaHttps
		{
			get { return true; }
		}

		public override bool CanSanitize(IElement element)
		{
			return element != null && element is IHtmlAudioElement;
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			return this.SanitizeCore<IHtmlAudioElement>(document, htmlElement, "amp-audio");
		}

		protected override void SetMediaElementLayout(IElement element, IElement ampElement)
		{
			Guard.Requires(element, "element").IsNotNull();
			Guard.Requires(ampElement, "ampElement").IsNotNull();

			if (!ampElement.HasAttribute("layout"))
			{
				if (ampElement.HasAttribute(AttributeNames.Height))
				{
					if (ampElement.HasAttribute(AttributeNames.Width))
					{
						if (ampElement.GetAttribute(AttributeNames.Width) == "auto")
						{
							ampElement.SetAttribute("layout", "responsive");
						}
						else
						{
							ampElement.SetAttribute("layout", "fixed");
						}
					}
					else
					{
						ampElement.SetAttribute("layout", "fixed-height");
					}
				}
			}
		}

		public virtual IList<string> GetScriptsDependencies()
		{
			return new string[] { "https://cdn.ampproject.org/v0/amp-audio-0.1.js" };
		}
	}
}