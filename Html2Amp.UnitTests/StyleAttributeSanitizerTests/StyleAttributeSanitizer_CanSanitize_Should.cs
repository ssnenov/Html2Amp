using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.Sanitization.Implementation;
using AngleSharp.Extensions;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using Html2Amp.UnitTests.Helpers;

namespace Html2Amp.UnitTests.StyleAttributeSanitizerTests
{
	[TestClass]
	public class StyleAttributeSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnTrue_WhenElementHasStyleAttribute()
		{
			// Arange
			var element = ElementFactory.Create("div");
			element.SetAttribute("style", "color: red;");

			// Act
			var actualResult = new StyleAttributeSanitizer().CanSanitize(element);

			// Assert
			Assert.IsTrue(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementHasNotStyleAttribute()
		{
			// Arange
			var element = ElementFactory.Create("div");

			// Act
			var actualResult = new StyleAttributeSanitizer().CanSanitize(element);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementArgumentIsNull()
		{
			// Act
			var actualResult = new StyleAttributeSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}
	}
}