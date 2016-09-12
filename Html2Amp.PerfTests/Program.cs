using BenchmarkDotNet.Running;
using Html2Amp.PerfTests.ElementExtensionsTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.PerfTests
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BenchmarkRunner.Run<ElementExtensions_CopyTo>();
		}
	}
}