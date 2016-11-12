using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Html2Amp.IntegrationTests.Infrastructure
{
	public static class TestNameResolver
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetCurrentTestName()
		{
			var stackTrace = new StackTrace();

			var method = stackTrace.GetFrame(1).GetMethod();

			return string.Format(@"{0}\{1}", method.DeclaringType.Name, method.Name);
		}
	}
}