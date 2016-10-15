using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.IntegrationTests.Infrastructure;

namespace Html2Amp.IntegrationTests
{
	[TestClass]
	public class HtmlToAmpConverting
	{
		[TestMethod]
		public void ConvertSimpleImageElementToAmp()
		{
			// Arrange
			string htmlToConvert = "<img src=\"test-image.png\" width=\"100\" height=\"100\" />";
			var htmlToAmpConverter = new HtmlToAmpConverter();

			// Act
			string ampHtml = htmlToAmpConverter.ConvertFromHtml(htmlToConvert);

			// Assert
			Assert.AreEqual("<amp-img src=\"test-image.png\" width=\"100\" height=\"100\" layout=\"responsive\"></amp-img>", ampHtml);
		}

		/// <summary>
		/// This test is required, because of problem with relative urls in AngleSharp
		/// and it's ensuring the output html is correct.
		/// </summary>
		[TestMethod]
		public void ConvertingAnchorElementWithJavaScirptInHrefAttribute()
		{
			// Arrange
			string htmlToConvert = "<a href=\"javascript:void(0);\">link</a>";
			var htmlToAmpConverter = new HtmlToAmpConverter();

			// Act
			string ampHtml = htmlToAmpConverter.ConvertFromHtml(htmlToConvert);

			// Assert
			Assert.AreEqual("<a href=\"#\">link</a>", ampHtml);
		}
	}
}