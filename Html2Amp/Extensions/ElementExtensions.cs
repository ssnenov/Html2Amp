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
			// We should copy the children of the source element because
			// when we append the child to the destionation, AngleSharp
			// removes the node from the source element.
			var sourceChildren = source.Children.ToList();

			foreach (var node in sourceChildren)
			{
				destination.AppendChild(node);
			}

			foreach (var attribute in source.Attributes)
			{
				destination.SetAttribute(attribute.Name, attribute.Value);
			}
		}

		public static void CopyAttributes(this IElement source, IElement destionation, IEnumerable<string> attributesToCopy)
		{
			foreach (var attribute in attributesToCopy)
			{
				var attributeValue = source.GetAttribute(attribute);

				if (!string.IsNullOrEmpty(attributeValue))
				{
					destionation.SetAttribute(attribute, attributeValue);
				}
			}
		}
	}
}