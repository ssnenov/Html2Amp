using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.PerfTests.ElementExtensionsTests
{
	public class ElementExtensions_CopyTo
	{
		private IElement source;
		private IElement destination;

		public ElementExtensions_CopyTo()
		{
			var htmlDocument = new HtmlParser().Parse(string.Empty);

			this.source = htmlDocument.CreateElement("source");
			this.source.SetAttribute("dummy1", string.Empty);
			this.source.SetAttribute("dummy2", string.Empty);
			this.source.SetAttribute("dummy3", string.Empty);
			this.source.SetAttribute("dummy4", string.Empty);

			var childElement = htmlDocument.CreateElement("childElement");
			childElement.SetAttribute("id", "elementId");
			childElement.InnerHtml = "<p>text</p>";
			
			this.source.AppendChild(childElement);

			this.destination = htmlDocument.CreateElement("target");
		}

		[Benchmark]
		public void CopyToMethod()
		{
			source.CopyTo(this.destination);
		}
	}
}