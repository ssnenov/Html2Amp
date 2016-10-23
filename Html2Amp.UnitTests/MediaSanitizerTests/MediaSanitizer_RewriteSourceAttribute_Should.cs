using Html2Amp.UnitTests.Accessors;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Html2Amp.UnitTests.MediaSanitizerTests
{
	[TestClass]
	public class MediaSanitizer_RewriteSourceAttribute_Should
	{
		[TestMethod]
		public void NotChangeTheSourceAttribute_WhenItIsUnderHttps()
		{
			// Arrange
			const string ExpectedResult = "https://foo.com/iframe";
			var htmlString = "<amp-iframe src=\"https://foo.com/iframe\" sandbox=\"allow-same-origin\" layout=\"fill\"></amp-iframe>";
			var ampElement = ElementFactory.CreateFromHtmlString(htmlString);

			// Act
			new MediaSanitizerAccessor().RewriteSourceAttribute(ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("src"));
		}

		[TestMethod]
		public void RewriteTheSourceAttributeWithHttps_WhenItIsNotUnderHttps()
		{
			// Arrange
			const string ExpectedResult = "https";
			var htmlString = "<amp-iframe src=\"http://foo.com/iframe\" sandbox=\"allow-same-origin\" layout=\"fill\"></amp-iframe>";
			var ampElement = ElementFactory.CreateFromHtmlString(htmlString);

			// Act
			new MediaSanitizerAccessor().RewriteSourceAttribute(ampElement);
			var srcScheme = new Uri(ampElement.GetAttribute("src")).Scheme;

			// Assert
			Assert.AreEqual(ExpectedResult, srcScheme);
		}

		[TestMethod]
		public void NotIncludeDefaultPorts_Always()
		{
			// Arrange
			const string ExpectedResult = "https://foo.com/iframe";
			var htmlString = "<amp-iframe src=\"http://foo.com/iframe\" sandbox=\"allow-same-origin\" layout=\"fill\"></amp-iframe>";
			var ampElement = ElementFactory.CreateFromHtmlString(htmlString);

			// Act
			new MediaSanitizerAccessor().RewriteSourceAttribute(ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("src"));
		}

		[TestMethod]
		public void PreserveTheOtherPartOfTheSourceAttribute_WhenTheSourceContainsAdditionalParams()
		{
			// Arrange
			const string ExpectedResult = "https://foo.com/iframe:8082?q=12&s=ex";
			var htmlString = "<amp-iframe src=\"http://foo.com/iframe:8082?q=12&s=ex\" sandbox=\"allow-same-origin\" layout=\"fill\"></amp-iframe>";
			var ampElement = ElementFactory.CreateFromHtmlString(htmlString);

			// Act
			new MediaSanitizerAccessor().RewriteSourceAttribute(ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("src"));
		}
	}
}