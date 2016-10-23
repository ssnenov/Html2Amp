using Html2Amp.UnitTests.Accessors;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Html2Amp.UnitTests.MediaSanitizerTests
{
	[TestClass]
	public class MediaSanitizer_SetMediaElementLayout_Should
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
		public void NotSetLayoutAttribute_WhenTheAmpElementAlreadyHasALayoutAttribute()
		{
			// Arrange
			const string ExpectedResult = "nodisplay";
			var element = ElementFactory.CreateIFrame();

			var ampElement = ElementFactory.Create("amp-iframe");
			ampElement.SetAttribute("layout", "nodisplay");

			// Act
			new MediaSanitizerAccessor().SetMediaElementLayout(element, ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("layout"));
		}

		[TestMethod]
		public void SetLayoutAttributeToFixedHeight_WhenTheAmpElementHasOnlyHeightAttribute()
		{
			// Arrange
			const string ExpectedResult = "fixed-height";
			var element = ElementFactory.CreateIFrame();
			element.DisplayHeight = 100;
			
			var ampElement = ElementFactory.Create("amp-iframe");

			// Act
			new MediaSanitizerAccessor().SetMediaElementLayout(element, ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("layout"));
		}

		[TestMethod]
		public void SetLayoutAttributeToResponsive_WhenTheAmpElementHasBothWidthAndHeightAttributes()
		{
			// Arrange
			const string ExpectedResult = "responsive";
			var element = ElementFactory.CreateIFrame();
			element.DisplayHeight = 100;
			element.DisplayWidth = 200;

			var ampElement = ElementFactory.Create("amp-iframe");

			// Act
			new MediaSanitizerAccessor().SetMediaElementLayout(element, ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("layout"));
		}

		[TestMethod]
		public void SetLayoutAttributeToFill_WhenTheAmpElementHasNoWidthAndHeightAttributes()
		{
			// Arrange
			const string ExpectedResult = "fill";
			var element = ElementFactory.CreateIFrame();
			var ampElement = ElementFactory.Create("amp-iframe");

			// Act
			new MediaSanitizerAccessor().SetMediaElementLayout(element, ampElement);

			// Assert
			Assert.AreEqual(ExpectedResult, ampElement.GetAttribute("layout"));
		}
	}
}