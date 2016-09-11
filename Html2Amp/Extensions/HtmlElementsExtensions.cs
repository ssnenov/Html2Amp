using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Html
{
	public static class HtmlElementsExtensions
	{
		public static void CopyTo(this IElement source, IElement destination)
		{
			destination.InnerHtml = source.InnerHtml;

			foreach (var attribute in source.Attributes)
			{
				destination.SetAttribute(attribute.Name, attribute.Value);
			}
		}
	}
}