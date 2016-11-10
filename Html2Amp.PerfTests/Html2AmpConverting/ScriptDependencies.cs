using BenchmarkDotNet.Attributes;

namespace Html2Amp.PerfTests.Html2AmpConverting
{
	public class ScriptDependencies
	{
		private static HtmlToAmpConverter htmlToAmpConverter = new HtmlToAmpConverter();

		[Benchmark]
		public ConvertionResult ConvertSimpleImageElementToAmp()
		{
			return htmlToAmpConverter.ConvertFromHtml("<img src=\"test-image.gif\" width=\"100\" height=\"100\" /><iframe src=\"http://some-iframe.com\" ></iframe><iframe src=\"http://www.youtube.com/embed/d8fr3AdK_tQ4\" ></iframe>");
		}
	}
}