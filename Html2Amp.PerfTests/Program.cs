using BenchmarkDotNet.Running;
using Html2Amp.PerfTests.Html2AmpConverting;

namespace Html2Amp.PerfTests
{
	public class Program
	{
		public static void Main()
		{
			//BenchmarkRunner.Run<ElementExtensions_CopyTo>();
			//BenchmarkRunner.Run<HtmlConverting>();
			BenchmarkRunner.Run<ScriptDependencies>();
		}
	}
}