using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Html2Amp.Sanitization
{
	public interface ISanitizer
	{
		bool CanSanitize(IElement element);

		IElement Sanitize(IDocument document, IElement htmlElement);

		void Configure(RunContext configuration);
	}
}