using Html2Amp.IntegrationTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.IntegrationTests.Tests.ScriptElementSanitizationTests
{
	[TestClass]
	public class ScriptElementSanitization
	{
		[TestMethod]
		public void ScriptElementSanitizationWithOneScriptTag()
		{
			// Arrange
			const string TestName = "ScriptElementSanitizationWithOneScriptTag";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}

		[TestMethod]
		public void ScriptElementSanitizationWithMoreScriptTags()
		{
			// Arrange
			const string TestName = "ScriptElementSanitizationWithMoreScriptTags";

			// Act
			var actualResult = HtmlTestFileToAmpConverter.Convert(TestName);

			// Assert
			HtmlAssert.AreEqual(TestDataProvider.GetOutFile(TestName), actualResult);
			AmpAssert.IsValidAmp(TestName);
		}
	}
}