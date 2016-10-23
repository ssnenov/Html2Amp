using AngleSharp.Dom;
using Html2Amp.UnitTests.TestDoubles;

namespace Html2Amp.UnitTests.Spies
{
	public class MediaSanitizerSpy : MediaSanitizerTestDouble
	{
		public MediaSanitizerSpy(bool shoulRequestResourcesOnlyViaHttps = false)
			: base(shoulRequestResourcesOnlyViaHttps)
		{
		}

		public bool SetMediaElementLayoutMethodIsCalled { get; set; }

		public bool SetElementLayoutMethodIsCalled { get; set; }

		protected override void SetElementLayout(IElement element, IElement ampElement)
		{
			this.SetElementLayoutMethodIsCalled = true;
			base.SetElementLayout(element, ampElement);
		}

		protected override void SetMediaElementLayout(IElement element, IElement ampElement)
		{
			this.SetMediaElementLayoutMethodIsCalled = true;
			base.SetMediaElementLayout(element, ampElement);
		}
	}
}