using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Text;
using System.Collections.Generic;

namespace Html2Amp.Sanitization.Implementation
{
	public class IFrameSanitizer : MediaSanitizer, IScriptsDependable
	{
		protected override bool ShoulRequestResourcesOnlyViaHttps
		{
			get { return true; }
		}

		public override bool CanSanitize(IElement element)
		{
			return element != null
				&& element is IHtmlInlineFrameElement
				&& this.IsValidSourceAttribute(element);
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(document, "document").IsNotNull();
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			return this.SanitizeCore<IHtmlInlineFrameElement>(document, htmlElement, "amp-iframe");
		}

		private bool IsValidSourceAttribute(IElement htmlElement)
		{
			var source = new Uri(htmlElement.GetAttribute("src"));
			var sandbox = htmlElement.GetAttribute("sandbox");

			// iframes could not be in the same origin as the container, unless they do not specify allow-same-origin.
			if (this.RunContext != null
				&& this.RunContext.Configuration != null
				&& this.RunContext.RelativeUrlsHostAsUri != null)
			{
				if (this.RunContext.RelativeUrlsHostAsUri.Host == source.Host)
				{
					if (!string.IsNullOrEmpty(sandbox) && sandbox.Contains("allow-same-origin"))
					{
						return true;
					}
				}
				else
				{
					return true;
				}
			}

			return false;
		}

		public virtual IList<string> GetScriptsDependencies()
		{
			return new[] { "https://cdn.ampproject.org/v0/amp-iframe-0.1.js" };
		}
	}
}