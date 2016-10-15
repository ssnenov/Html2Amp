using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.IntegrationTests.Infrastructure
{
	public static class HtmlTestFileToAmpConverter
	{
		public static string Convert(string testName)
		{
			var html = TestDataProvider.GetInFile(testName);
			
			var ampHtml = new HtmlToAmpConverter().ConvertFromHtml(html);

			return ampHtml;
		}
	}
}