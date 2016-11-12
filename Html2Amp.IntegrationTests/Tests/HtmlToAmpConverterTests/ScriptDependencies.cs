using Html2Amp.IntegrationTests.Infrastructure;
using Html2Amp.Sanitization.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Html2Amp.IntegrationTests.Tests.HtmlToAmpConverterTests
{
	[TestClass]
	public class ScriptDependencies
	{
		[TestMethod]
		public void RetrunScriptDependencies()
		{
			// Arrange
			const string TestName = "RetrunScriptDependencies";
			var dependencies = new List<string>();
			dependencies.AddRange(new IFrameSanitizer().GetScriptsDependencies());
			dependencies.AddRange(new AudioSanitizer().GetScriptsDependencies());
			dependencies.AddRange(new YouTubeVideoSanitizer().GetScriptsDependencies());

			// Act
			var convertionResult = HtmlTestFileToAmpConverter.Convert(new RunConfiguration { RelativeUrlsHost = "http://mydomain.com" }, TestName);

			// Assert
			Assert.AreEqual(3, convertionResult.ScriptsReferencies.Intersect(dependencies).Count());
		}
	}
}