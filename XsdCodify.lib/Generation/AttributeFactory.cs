using System;
using System.Linq;
using XsdCodify.Lib.Generation.Arguments;

namespace XsdCodify.Lib.Generation
{
    public class AttributeFactory
    {
        public string Create(string attributeName, params IAttributeArgument[] attributeArguments)
        {
            if (attributeName == null) throw new ArgumentNullException(nameof(attributeName));

            if (attributeArguments == null || !attributeArguments.Any()) {
                return $"[{attributeName}]";
            } else {
                string arguments = string.Join(", ", attributeArguments.Select(a => a.Formatted));
                return $"[{attributeName}({arguments})]";
            }
        }
    }
}