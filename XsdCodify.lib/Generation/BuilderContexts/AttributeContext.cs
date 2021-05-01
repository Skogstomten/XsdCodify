using System;
using System.Linq;
using System.Collections.Generic;

using XsdCodify.Lib.Generation.Arguments;

namespace XsdCodify.Lib.Generation.BuilderContexts
{
    public class AttributeContext : IAttributeContext
    {
        private readonly string attributeName;
        private List<IAttributeArgument> arguments = new List<IAttributeArgument>();

        public AttributeContext(string attributeName)
        {
            this.attributeName = attributeName ?? throw new ArgumentNullException(nameof(attributeName));
        }

        internal void Verify()
        {
            if (string.IsNullOrWhiteSpace(this.attributeName))
                throw new InvalidOperationException("Attribute name needs a value");
        }

        internal void AddArgument(AttributeNamedStringConstantArgument argument)
        {
            if (argument == null) throw new ArgumentNullException(nameof(argument));
            this.arguments.Add(argument);
        }

        public override string ToString()
        {
            if (this.arguments.Any())
            {
                string arguments = string.Join(", ", this.arguments.Select(a => a.Formatted));
                return $"[{this.attributeName}({arguments})]";
            } else
            {
                return $"[{this.attributeName}]";
            }
        }
    }
}