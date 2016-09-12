using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleSharp.Dom
{
	public static class ElementExtensions
	{
		public static void CopyTo(this IElement source, IElement destination)
		{
			foreach (var node in source.Children)
			{
				destination.AppendChild(node);
			}

			foreach (var attribute in source.Attributes)
			{
				destination.SetAttribute(attribute.Name, attribute.Value);
			}
		}
	}
}