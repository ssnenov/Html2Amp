using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.Helpers
{
	public class ElementFactory
	{
		private static readonly IHtmlDocument document = new HtmlParser().Parse(string.Empty);

		public static IHtmlDocument Document
		{
			get
			{
				return document;
			}
		}

		public static IElement Create(string name)
		{
			return document.CreateElement(name);
		}

		public static IHtmlImageElement CreateImage()
		{
			return (IHtmlImageElement)Create("img");
		}

		public static IHtmlAnchorElement CreateAnchor()
		{
			return (IHtmlAnchorElement)Create("a");
		}
	}
}