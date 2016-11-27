using Html2Amp.Sanitization.Implementation;
using Html2Amp.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.BorderAttributeSanitizerTests
{
	[TestClass]
	public class BorderAttributeSanitizer_CanSanitize_Should
	{
		[TestMethod]
		public void ReturnFalse_WhenElementIsNotTableAndHasNotBorderAttribute()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateImage();

			// Act
			var actualResult = new BorderAttributeSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnTrue_WhenElementIsNotTableAndHasBorderAttribute()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateImage();
			htmlElement.SetAttribute("border", "1");

			// Act
			var actualResult = new BorderAttributeSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsTrue(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementIsNull()
		{
			// Act
			var actualResult = new BorderAttributeSanitizer().CanSanitize(null);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementIsTable()
		{
			// Arrange
			var htmlElement = ElementFactory.CreateTable();

			// Act
			var actualResult = new BorderAttributeSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementIsRow()
		{
			// Arrange
			var htmlElement = ElementFactory.Create("tr");

			// Act
			var actualResult = new BorderAttributeSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}

		[TestMethod]
		public void ReturnFalse_WhenElementIsCell()
		{
			// Arrange
			var htmlElement = ElementFactory.Create("td");

			// Act
			var actualResult = new BorderAttributeSanitizer().CanSanitize(htmlElement);

			// Assert
			Assert.IsFalse(actualResult);
		}
	}
}