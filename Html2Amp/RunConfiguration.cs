using AngleSharp;
using AngleSharp.Parser.Html;
namespace Html2Amp
{
	public class RunConfiguration
	{
		const string IFramesPlaceholderValue = "<span>This part of the page will be loaded later.</span>";

		/// <summary>
		/// Gets or sets the host used for resolving relative URLs.
		/// </summary>
		/// <example>http://localhost</example>
		/// <example>https://mydomain.com</example>
		/// <example>mydomain.com</example>
		/// <example>mydomain.com/blogs</example>
		public string RelativeUrlsHost { get; set; }

		/// <summary>
		/// Gets or sets a flag used to determine shoud to download images. Downloading images
		/// is used to set width and/or height of an image (if they aren't specified) in order to 
		/// present the image responsively.
		/// </summary>
        public bool ShouldDownloadImages { get; set; }

		/// <summary>
		/// Gets or sets the element used as placeholder for iframes.
		/// By default, the value is: <span>This part of the page will be loaded later.</span>
		/// </summary>
		/// <example><p class="custom-class">This source will be available soon.</p></example>
		public string IFramesPlaceholder { get; set; }

		public RunConfiguration()
		{
			this.ShouldDownloadImages = true;
			this.IFramesPlaceholder = IFramesPlaceholderValue;
		}
	}
}