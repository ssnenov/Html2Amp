using System;

namespace Html2Amp.IntegrationTests.TestDoubles
{
	public class RunConfigurationTestDouble : RunConfiguration
	{
		public RunConfigurationTestDouble()
		{
			this.GetConfigurationValueCoreMethod = base.GetConfigurationValueCore;
		}

		public Func<string, object, object> GetConfigurationValueCoreMethod { get; set; }

		protected override object GetConfigurationValueCore(string key, object defaultValue)
		{
			return this.GetConfigurationValueCoreMethod(key, defaultValue);
		}
	}
}