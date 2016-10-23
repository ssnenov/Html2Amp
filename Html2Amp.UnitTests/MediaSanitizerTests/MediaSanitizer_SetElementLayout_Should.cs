using Html2Amp.UnitTests.Accessors;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.MediaSanitizerTests
{
	[TestClass]
	public class MediaSanitizer_SetElementLayout_Should
	{
		[TestMethod]
		public void ThowArgumentNullException_WhenElementArgumentIsNull()
		{
			// Arrange
			var ampElement = ElementFactory.Create("amp-iframe");

			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new MediaSanitizerAccessor().SetMediaElementLayout(null, ampElement), "element");
		}

		[TestMethod]
		public void ThowArgumentNullException_WhenAmpElementArgumentIsNull()
		{
			// Assert
			Ensure.ArgumentExceptionIsThrown(() => new MediaSanitizerAccessor().SetMediaElementLayout(ElementFactory.CreateAudio(), null), "ampElement");
		}

		[TestMethod]
		public void CallSetMediaElementLayoutMethod_Always()
		{
			// Arrange
			var element = ElementFactory.CreateIFrame();
			var ampElement = ElementFactory.Create("amp-iframe");
			var mediaSanitizer = new MediaSanitizerAccessor();

			// Act
			mediaSanitizer.SetElementLayout(element, ampElement);

			// Assert
			Assert.IsTrue(mediaSanitizer.SetMediaElementLayoutMethodIsCalled);
		}

		[TestMethod]
		public void SetLayoutAttributeToNoDisplay_WhenTheHtmlElementHasStyleAttributeDisplayNone()
		{
			// Arrange
			const string ExpectedResult = "nodisplay";
			var element = ElementFactory.CreateIFrame();
			element.SetAttribute("style", "display:none");
			var ampElement = ElementFactory.Create("amp-iframe");

			// Act
			new MediaSanitizerAccessor().SetElementLayout(element, ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("layout"));
		}

		[TestMethod]
		public void SetLayoutAttributeToNoDisplay_WhenTheHtmlElementHasStyleAttributeVisibilityHidden()
		{
			// Arrange
			const string ExpectedResult = "nodisplay";
			var element = ElementFactory.CreateIFrame();
			element.SetAttribute("style", "visibility:hidden");
			var ampElement = ElementFactory.Create("amp-iframe");

			// Act
			new MediaSanitizerAccessor().SetElementLayout(element, ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("layout"));
		}
	}
}