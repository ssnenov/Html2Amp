using Html2Amp.IntegrationTests.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
	public static class AmpAssert
	{
		public static void IsValidAmp(string testName)
		{
			string errors;

			string ampFilePath = TestDataProvider.CreateAmpFile(testName);
			
			var result = new AmpValidatorRunner().RunValidator(ampFilePath, out errors);

			if (result == AmpValidationResult.Fail)
			{
				Assert.Fail("The AMP validation faild with following erros: {0}{1}", Environment.NewLine, errors);
			}
		}
	}
}