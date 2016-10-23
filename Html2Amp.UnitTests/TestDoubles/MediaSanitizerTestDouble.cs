using AngleSharp.Dom;
using Html2Amp.Sanitization;
using System;

namespace Html2Amp.UnitTests.TestDoubles
{
	public class MediaSanitizerTestDouble : MediaSanitizer
	{
		private bool shoulRequestResourcesOnlyViaHttps;

		public MediaSanitizerTestDouble(bool shoulRequestResourcesOnlyViaHttps = false)
		{
			this.shoulRequestResourcesOnlyViaHttps = shoulRequestResourcesOnlyViaHttps;
		}

		public override bool CanSanitize(IElement element)
		{
			throw new NotImplementedException();
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			throw new NotImplementedException();
		}

		protected override bool ShoulRequestResourcesOnlyViaHttps
		{
			get
			{
				return this.shoulRequestResourcesOnlyViaHttps;
			}
		}
	}
}