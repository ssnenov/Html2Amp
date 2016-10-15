using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.IntegrationTests.Infrastructure
{
	public class AmpValidatorRunner
	{
		private const string NodeModulesPath = "node_modules";

		private const string AmpValidatorCommandName = "amphtml-validator";

		private const string NodeCommandName = "node.exe";

		private static readonly Lazy<string> AmpValidatorCommandPath = new Lazy<string>(GetAmpValidatorCommandPath);

		public AmpValidationResult RunValidator(string pathToFile, out string errors)
		{
			var proc = new Process();
			proc.StartInfo.FileName = NodeCommandName;
			proc.StartInfo.Arguments = string.Format("{0} {1}", AmpValidatorCommandPath.Value, pathToFile);

			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.CreateNoWindow = true;
			proc.StartInfo.RedirectStandardInput = true;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.RedirectStandardError = true;

			try
			{
				proc.Start();
				
				errors = proc.StandardError.ReadToEnd();
				if (!string.IsNullOrEmpty(errors))
				{
					return AmpValidationResult.Fail;
				}

				var validationOutcome = proc.StandardOutput.ReadLine();
				if (validationOutcome != null && validationOutcome.EndsWith(": PASS"))
				{
					return AmpValidationResult.Pass;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				proc.Dispose();
			}

			return AmpValidationResult.Fail;
		}

		private static string GetAmpValidatorCommandPath()
		{
			var executingAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			return Path.Combine(executingAssemblyDirectory, @"..\..\..\", NodeModulesPath, AmpValidatorCommandName);
		}
	}
}