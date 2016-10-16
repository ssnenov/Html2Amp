namespace Html2Amp
{
	public class RunConfiguration
	{
		public string RelativeUrlsHost { get; set; }

        public bool ShouldDownloadImages { get; set; }

		public RunConfiguration()
		{
			ShouldDownloadImages = true;
		}
	}
}