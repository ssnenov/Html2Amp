using AngleSharp.Dom;
using System;
using System.Collections.Generic;

namespace Html2Amp.Sanitization.Implementation
{
	public class GifImageSanitizer : ImageSanitizerBase, IScriptsDependable
	{
		public override bool CanSanitize(IElement element)
		{
			return base.CanSanitize(element)
				&& element.GetAttribute("src").EndsWith(".gif", StringComparison.OrdinalIgnoreCase);
		}

		protected internal override string GetAmpElementTag()
		{
			return "amp-anim";
		}

		public IList<string> GetScriptsDependencies()
		{
			return new[] { "https://cdn.ampproject.org/v0/amp-anim-0.1.js" };
		}
	}
}