using Html2Amp.UnitTests.Spies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.Accessors
{
	public class ImageSanitizerAccessor : ImageSanitizerSpy
	{
		public new Image DownloadImage(string imageUrl)
		{
			return base.DownloadImage(imageUrl);
		}
	}
}