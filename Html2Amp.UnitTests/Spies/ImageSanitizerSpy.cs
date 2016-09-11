using AngleSharp.Dom;
using Html2Amp.Sanitization.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.Spies
{
	public class ImageSanitizerSpy : ImageSanitizer
	{
		public bool SetImageSizeCalled { get; set; }

		protected override void SetImageSize(IElement htmlElement)
		{
			this.SetImageSizeCalled = true;
		}
	}
}