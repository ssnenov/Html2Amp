using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;

namespace Html2Amp.UnitTests.TargetAttributeSanitizerTests
{
	[TestClass]
	public class TargetAttributeSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenElementIsNull()
		{
			// Act
			var actualResult = new TargetAttributeSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementIsNotIHtmlLinkElement()
		{
			// Act
			var actualResult = new TargetAttributeSanitizer().CanSanitize(ElementFactory.CreateImage());

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementHasTargetAttributeEqualToBlank()
		{
			// Arrange
			var linkElement = ElementFactory.CreateAnchor();
			linkElement.SetAttribute("target", "_blank");

			// Act
			var actualResult = new TargetAttributeSanitizer().CanSanitize(linkElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementHasNotTargetAttribute()
		{
			// Act
			var actualResult = new TargetAttributeSanitizer().CanSanitize(ElementFactory.CreateAnchor());

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenElementHasTargetAttributeNotEqualToBlank()
		{
			// Arrange
			var linkElement = ElementFactory.CreateAnchor();
			linkElement.SetAttribute("target", "_parent");

			// Act
			var actualResult = new TargetAttributeSanitizer().CanSanitize(linkElement);

			// Assert
			Assert.IsTrue(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenElementHasTargetAttributeEqualEmptyString()
		{
			// Arrange
			var linkElement = ElementFactory.CreateAnchor();
			linkElement.SetAttribute("target", string.Empty);

			// Act
			var actualResult = new TargetAttributeSanitizer().CanSanitize(linkElement);

			// Assert
			Assert.IsTrue(actualResult);
		}
	}
}