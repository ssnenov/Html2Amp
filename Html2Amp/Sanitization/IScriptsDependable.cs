using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization
{
	public interface IScriptsDependable
	{
		IList<string> GetScriptsDependencies();
	}
}