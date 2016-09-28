using Html2Amp.Sanitization.Implementation;
using System;
using System.Drawing;

namespace Html2Amp.UnitTests.TestDoubles
{
    public class ImageSanitizerTestDouble : ImageSanitizer
    {
        public ImageSanitizerTestDouble()
        {
            this.DownloadImageResult = base.DownloadImage;
        }

        public Func<string, Image> DownloadImageResult { get; set; }

        protected override Image DownloadImage(string imageUrl)
        {
            return this.DownloadImageResult(imageUrl);
        }
    }
}