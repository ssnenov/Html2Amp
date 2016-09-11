using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.UnitTests.Helpers
{
	public static class Ensure
	{
		public static void ArgumentExceptionIsThrown(Action action, string argumentName)
		{
			bool succeed = false;

			try
			{
				action();
			}
			catch (ArgumentException exception) 
			{
				succeed = exception.ParamName == argumentName;
			}
			catch (Exception) { }

			string message = string.Format("ArgumentException for parameter \"{0}\" has not been thrown", argumentName);
			Assert.IsTrue(succeed, message);
		}
	}
}