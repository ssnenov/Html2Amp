using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.IO;

namespace Html2Amp.Sanitization.Implementation
{
	public class GifImageSanitizer : ImageSanitizerBase, IScriptsDependable
	{
		public override bool CanSanitize(IElement element)
		{
			if (base.CanSanitize(element))
			{
				var sourceAttribute = element.GetAttribute("src");
				var queryStringIndex = sourceAttribute.IndexOf("?");

				if (queryStringIndex != -1)
				{
					sourceAttribute = sourceAttribute.Substring(0, queryStringIndex);
				}

				return Path.GetExtension(sourceAttribute) == ".gif";
			}

			return false;
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