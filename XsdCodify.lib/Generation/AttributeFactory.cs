using System;
using XsdCodify.Lib.Generation.Arguments;

namespace XsdCodify.Lib.Generation
{
    public class AttributeFactory
    {
        public string Create(string attributeName, params IAttributeArgument[] attributeArguments)
        {
            if (attributeName == null) throw new ArgumentNullException(nameof(attributeName));

            return $"[{attributeName}]";
        }
    }
}