using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.ScriptElementSanitizerTests
{
	[TestClass]
	public class ScriptElementSanitizer_Sanitize_Should
	{
		[TestMethod]
		public void ThrowException_WhenHtmlElementIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new ScriptElementSanitizer().Sanitize(ElementFactory.Document, null), "htmlElement");
		}

		[TestMethod]
		public void ReturnNull_WhenScriptElementIsRemoved()
		{
			// Arrange
			var parentElement = ElementFactory.CreateAnchor();
			var scriptElement = ElementFactory.CreateScript();

			parentElement.AppendChild(scriptElement);

			// Act
			var actualResult = new ScriptElementSanitizer().Sanitize(null, scriptElement);

			// Assert
			Assert.IsNull(actualResult);
		}

		[TestMethod]
		public void RemoveScriptElement()
		{
			// Arrange
			var parentElement = ElementFactory.CreateAnchor();
			var scriptElement = ElementFactory.CreateScript();

			parentElement.AppendChild(scriptElement);

			// Act
			new ScriptElementSanitizer().Sanitize(null, scriptElement);

			// Assert
			Assert.AreEqual(0, parentElement.Children.Length);
		}
	}
}