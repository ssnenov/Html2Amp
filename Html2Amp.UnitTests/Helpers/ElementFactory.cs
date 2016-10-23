using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System.Linq;

namespace Html2Amp.UnitTests.Helpers
{
	public class ElementFactory
	{
		private static readonly IHtmlDocument document = new HtmlParser(Configuration.Default.WithCss()).Parse(string.Empty);

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

        public static IElement CreateFromHtmlString(string html)
        {
			var config = Configuration.Default.WithCss();
            IHtmlDocument document = new HtmlParser(config).Parse(html);

            return document.Body.Children.First();
        }

		public static IHtmlImageElement CreateImage()
		{
			return (IHtmlImageElement)Create("img");
		}

		public static IHtmlAnchorElement CreateAnchor()
		{
			return (IHtmlAnchorElement)Create("a");
		}

		public static IHtmlInlineFrameElement CreateIFrame()
		{
			return (IHtmlInlineFrameElement)Create("iframe");
		}

		public static IHtmlScriptElement CreateScript()
		{
			return (IHtmlScriptElement)Create("script");
		}

        public static IHtmlAudioElement CreateAudio()
        {
            return (IHtmlAudioElement)Create("audio");
        }
	}
}