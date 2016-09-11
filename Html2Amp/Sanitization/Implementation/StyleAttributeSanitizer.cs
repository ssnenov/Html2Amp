﻿using AngleSharp.Dom;
using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization.Implementation
{
	public class StyleAttributeSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			if(element != null)
			{
				return element.HasAttribute("style");
			}

			return false;
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			if (htmlElement == null)
			{
				throw new ArgumentNullException("htmlElement");
			}

			htmlElement.RemoveAttribute("style");

			return htmlElement;
		}
	}
}