using Html2Amp.Sanitization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Html2Amp
{
	public class ConvertionResult
	{
		private IList<string> scriptsReferencies;

		internal Dictionary<Type, IList<string>> scriptsReferenciesBucket = new Dictionary<Type, IList<string>>();

		/// <summary>
		/// Gets the output(AMP HTML) of the convertion.
		/// </summary>
		public string AmpHtml { get; internal set; }

		/// <summary>
		/// Gets the scripts required to be referenced in the page in order to work properly.
		/// </summary>
		public IList<string> ScriptsReferencies
		{
			get
			{
				if (scriptsReferencies == null)
				{
					scriptsReferencies = scriptsReferenciesBucket.Values.SelectMany(x => x).ToList();
				}

				return scriptsReferencies;
			}
		}
	}
}