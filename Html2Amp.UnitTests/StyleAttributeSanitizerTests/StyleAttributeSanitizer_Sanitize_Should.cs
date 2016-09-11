using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.StyleAttributeSanitizerTests
{
	[TestClass]
	public class StyleAttributeSanitizer_Sanitize_Should
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ThorwArgumentNullException_WhenElementIsNull()
		{
			// Act
			new StyleAttributeSanitizer().Sanitize(null, null);
		}

		[TestMethod]
		public void RemoveStyleAttribute()
		{
			// Arange
			var element = ElementFactory.Create("div");
			element.SetAttribute("style", "color: red;");

			// Act
			var actualResult = new StyleAttributeSanitizer().Sanitize(ElementFactory.Document, element);

			// Assert
			Assert.IsFalse(actualResult.HasAttribute("style"));
		}
	}
}