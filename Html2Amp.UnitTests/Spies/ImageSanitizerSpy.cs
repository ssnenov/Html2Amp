using AngleSharp.Dom;
using Html2Amp.UnitTests.TestDoubles;
using System.Drawing;

namespace Html2Amp.UnitTests.Spies
{
	public class ImageSanitizerSpy : ImageSanitizerTestDouble
	{
		public bool SetImageSizeCalled { get; set; }

		public bool DownloadImageIsCalled { get; set; }

		protected override void SetImageSize(IElement htmlElement)
		{
			this.SetImageSizeCalled = true;
			base.SetImageSize(htmlElement);
		}

		protected override Image DownloadImage(string imageUrl)
		{
			this.DownloadImageIsCalled = true;
			return base.DownloadImage(imageUrl);
		}
	}
}