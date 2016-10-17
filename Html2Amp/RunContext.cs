using ComboRox.Core.Utilities.SimpleGuard;
using Html2Amp.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Html2Amp
{
	public class RunContext
	{
		public RunConfiguration Configuration { get; private set; }

		public Uri RelativeUrlsHostAsUri { get; private set; }

		internal ConcurrentDictionary<string, ImageSize> ImagesCache { get; private set; }

		public RunContext(RunConfiguration configuration)
		{
			Guard.Requires(configuration, "configuration").IsNotNull();

			this.Configuration = configuration;
			this.ImagesCache = new ConcurrentDictionary<string, ImageSize>(StringComparer.Ordinal);

			this.Initialize();
		}

		private void Initialize()
		{
			if (!string.IsNullOrEmpty(this.Configuration.RelativeUrlsHost))
			{
				this.RelativeUrlsHostAsUri = new Uri(this.Configuration.RelativeUrlsHost);
			}
		}
	}
}