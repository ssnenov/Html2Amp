using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.PerfTests
{
	public class HtmlConverting
	{
		private static HtmlToAmpConverter htmlToAmpConverter = new HtmlToAmpConverter();

		[Benchmark]
		public ConvertionResult ConvertSimpleImageElementToAmp()
		{
			return htmlToAmpConverter.ConvertFromHtml("<img src=\"test-image.png\" width=\"100\" height=\"100\" />");
		}
	}
}