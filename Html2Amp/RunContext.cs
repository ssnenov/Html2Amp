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
			// Here will be the additional initialization
		}
	}
}