using ComboRox.Core.Utilities.SimpleGuard;
using Html2Amp.Models;
using System.Collections.Generic;

namespace Html2Amp
{
	public class RunContext
	{
		public RunConfiguration Configuration { get; private set; }

		public Dictionary<string, Image> ImagesCache { get; private set; }

		public RunContext(RunConfiguration configuration)
		{
			Guard.Requires(configuration, "configuration").IsNotNull();

			this.Configuration = configuration;
			this.ImagesCache = new Dictionary<string, Image>();

			this.Initialize();
		}

		private void Initialize()
		{
			// Here will be the additional initialization
		}
	}
}