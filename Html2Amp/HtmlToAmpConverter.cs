using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using AngleSharp.Services.Default;
using Html2Amp.Sanitization;
using Html2Amp.Sanitization.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp
{
	public class HtmlToAmpConverter
	{
		public HashSet<ISanitizer> Sanitizers { get; set; }

		public HtmlToAmpConverter()
		{
			Sanitizers = new HashSet<ISanitizer>();

			Sanitizers.Add(new ImageSanitizer());
			Sanitizers.Add(new StyleAttributeSanitizer());
		}

		public HtmlToAmpConverter(HashSet<ISanitizer> sanitizers)
		{
			this.Sanitizers = sanitizers;
		}

		public string ConvertFromHtml(string htmlSource)
		{
			if (string.IsNullOrEmpty(htmlSource))
			{
				return string.Empty;
			}

			IHtmlDocument document = new HtmlParser().Parse(htmlSource);
			IHtmlHtmlElement htmlElement = (IHtmlHtmlElement)document.DocumentElement;

			ConvertFromHtmlElement(document, document.Body);

			return document.Body.InnerHtml;
		}

		private void ConvertFromHtmlElement(IDocument document, IElement htmlElement)
		{
			foreach (var sanitizer in Sanitizers)
			{
				if (sanitizer.CanSanitize(htmlElement))
				{
					htmlElement = sanitizer.Sanitize(document, htmlElement);

					// May should rewrite with all possible sanitizers
					//break;
				}
			}

			foreach (var childElement in htmlElement.Children)
			{
				ConvertFromHtmlElement(document, childElement);
			}
		}
	}
}