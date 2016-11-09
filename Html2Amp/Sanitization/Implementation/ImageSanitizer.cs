namespace Html2Amp.Sanitization.Implementation
{
	public class ImageSanitizer : ImageSanitizerBase
	{
		protected internal override string GetAmpElementTag()
		{
			return "amp-img";
		}
	}
}