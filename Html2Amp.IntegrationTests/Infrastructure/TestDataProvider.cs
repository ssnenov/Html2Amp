using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.IntegrationTests.Infrastructure
{
	public static class TestDataProvider
	{
		public const string TestDataFolder = "TestData";

		public const string TemplateName = "AMPHtmlTemplate.html";

		public static readonly Lazy<string> ExecutingDir = new Lazy<string>(() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
		
		private static readonly Lazy<string> AmpTemplate = new Lazy<string>(GetAmpTemplate);

		public static string GetOutFile(string testName)
		{
			return File.ReadAllText(GetOutFileName(testName));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="testName"></param>
		/// <returns>The path of created file</returns>
		public static string CreateAmpFile(string testName)
		{
			var ampFileName = GetAmpFileName(testName);
			var ampHtml = GetOutFile(testName);

			File.WriteAllText(ampFileName, AmpTemplate.Value.Replace("@AMPHTML", ampHtml));

			return ampFileName;
		}

		public static string GetOutFileName(string testName)
		{
			return Path.Combine(ExecutingDir.Value, TestDataFolder, testName, testName + ".out");
		}

		public static string GetAmpFileName(string testName)
		{
			return Path.Combine(ExecutingDir.Value, TestDataFolder, testName, testName + ".amp");
		}

		public static string GetInFileName(string testName)
		{
			return Path.Combine(ExecutingDir.Value, TestDataFolder, testName, testName + ".in");
		}

		public static string GetInFile(string testName)
		{
			return File.ReadAllText(GetInFileName(testName));
		}

		private static string GetAmpTemplate()
		{
			var templatePath = Path.Combine(ExecutingDir.Value, TestDataFolder, TemplateName);

			return File.ReadAllText(templatePath);
		}
	}
}