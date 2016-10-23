using AngleSharp.Dom.Html;
using Html2Amp.UnitTests.Accessors;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.MediaSanitizerTests
{
	[TestClass]
	public class MediaSanitizer_SanitizeCore_Should
	{

		[TestMethod]
		public void ThowArgumentNullException_WhenDocumentArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(null, ElementFactory.CreateIFrame(), "amp-iframe"), "document");
		}

		[TestMethod]
		public void ThowArgumentNullException_WhenHtmlElementArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, null, "amp-iframe"), "htmlElement");
		}

		[TestMethod]
		public void ThowArgumentNullException_WhenAmpElementTagNameArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, ElementFactory.CreateIFrame(), null), "ampElementTagName");
		}

		[TestMethod]
		public void NotRewriteSourceAttribute_WhenResourcesCanBeRequestOnlyViaHttpsEqualsFalse()
		{
			// Arrange
			const string ExpectedResult = "http://www.example.com";
			var htmlElement = ElementFactory.CreateIFrame();
			htmlElement.Source = "http://www.example.com";
			ElementFactory.Document.Body.Append(htmlElement);
			
			// Act
			var actualResult = new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, htmlElement, "amp-iframe");

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("src"));
		}

		[TestMethod]
		public void RewriteSourceAttributeWithHttps_WhenResourcesCanBeRequestOnlyViaHttpsEqualsTrue()
		{
			// Arrange
			const string ExpectedResult = "https://www.example.com";
			var htmlElement = ElementFactory.CreateIFrame();
			htmlElement.Source = "http://www.example.com";
			ElementFactory.Document.Body.Append(htmlElement);
			var mediaSanitizer = new MediaSanitizerAccessor(true);

			// Act
			var actualResult = mediaSanitizer.SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, htmlElement, "amp-iframe");

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.GetAttribute("src"));
		}

		[TestMethod]
		public void ReturnAmpElementWithTagEqualToAmpElementTagNameParameter_Always()
		{
			// Arrange
			const string ExpectedResult = "AMP-IFRAME";
			var htmlElement = ElementFactory.CreateIFrame();
			ElementFactory.Document.Body.Append(htmlElement);

			// Act
			var actualResult = new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, htmlElement, "amp-iframe");

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.TagName);
		}

		[TestMethod]
		public void CopyAllAttributesFromTheOriginalHtmlElementToTheAmpElement_Always()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();
			htmlElement.Source = "https://www.example.com";
			htmlElement.Id = "iframeId";
			htmlElement.ClassName = "someClassName";
			htmlElement.DisplayWidth = 100;
			htmlElement.DisplayHeight = 200;
			ElementFactory.Document.Body.Append(htmlElement);

			// Act
			var actualResult = new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, htmlElement, "amp-iframe");

			// Assert
			Assert.AreEqual("https://www.example.com", actualResult.GetAttribute("src"));
			Assert.AreEqual("iframeId", actualResult.Id);
			Assert.AreEqual("someClassName", actualResult.ClassName);
			Assert.AreEqual(100, int.Parse(actualResult.GetAttribute("width")));
			Assert.AreEqual(200, int.Parse(actualResult.GetAttribute("height")));
		}

		[TestMethod]
		public void CopyAllChildrenFromTheOriginalHtmlElementToTheAmpElement_Always()
		{
			// Arrange
			const int ExpectedResult = 2;
			var htmlElement = ElementFactory.CreateIFrame();
			var firstChild = ElementFactory.Create("input");
			var secondChild = ElementFactory.Create("p");
			htmlElement.Append(firstChild);
			htmlElement.Append(secondChild);
			ElementFactory.Document.Body.Append(htmlElement);

			// Act
			var actualResult = new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, htmlElement, "amp-iframe");

			// Assert
			Assert.AreEqual(ExpectedResult, actualResult.Children.Length);
			
		}

		[TestMethod]
		public void CallSetElementLayoutMethod_Always()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();
			ElementFactory.Document.Body.Append(htmlElement);
			var mediaSanitizer = new MediaSanitizerAccessor();

			// Act
			var actualResult = mediaSanitizer.SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, htmlElement, "amp-iframe");

			// Assert
			Assert.IsTrue(mediaSanitizer.SetElementLayoutMethodIsCalled);
		}

		[TestMethod]
		public void ReplaceTheHtmlElementWitTheAmpElement_Always()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateIFrame();
			var parent = ElementFactory.Create("div");
			parent.AppendChild(htmlElement);
			ElementFactory.Document.Body.Append(parent);

			// Act
			var actualResult = new MediaSanitizerAccessor().SanitizeCore<IHtmlInlineFrameElement>(ElementFactory.Document, htmlElement, "amp-iframe");

			// Assert
			Assert.AreEqual(1, actualResult.Parent.ChildNodes.Length);
			Assert.AreEqual(actualResult.TagName, actualResult.Parent.ChildNodes[0].NodeName);
		}
	}
}