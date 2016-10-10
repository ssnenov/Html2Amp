using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp
{
	public class RunContext
	{
		public RunConfiguration Configuration { get; private set; }

		public RunContext(RunConfiguration configuration)
		{
			Guard.Requires(configuration, "configuration").IsNotNull();

			this.Configuration = configuration;

			this.Initialize();
		}

		private void Initialize()
		{
			// Here will be the additional initialization
		}
	}
}