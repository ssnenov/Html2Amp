using AngleSharp.Dom;
using Html2Amp.UnitTests.TestDoubles;

namespace Html2Amp.UnitTests.Spies
{
	public class ImageSanitizerSpy : ImageSanitizerTestDouble
	{
		public bool SetImageSizeCalled { get; set; }

		protected override void SetImageSize(IElement htmlElement)
		{
			this.SetImageSizeCalled = true;
		}
	}
}