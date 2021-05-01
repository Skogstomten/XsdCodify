using System;
using System.Text;
using System.Collections.Generic;

namespace XsdCodify.Lib.Generation.BuilderContexts
{
    public class PropertyContext : IPropertyContext
    {
        private readonly string typeName, propertyName;
        private List<IAttributeContext> attributes = new List<IAttributeContext>();

        public PropertyContext(string typeName, string propertyName)
        {
            this.typeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
            this.propertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        }

        public void AddAttribute(IAttributeContext attribute)
        {
            if (attribute == null) throw new ArgumentNullException(nameof(attribute));
            this.attributes.Add(attribute);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAttributeContext context in this.attributes)
            {
                sb.AppendLine(context.ToString());
            }
            sb.AppendLine($"public {this.typeName} {this.propertyName} {{ get; set; }}");
            return sb.ToString().Trim();
        }

        internal void Verify()
        {
            if (string.IsNullOrWhiteSpace(this.typeName))
                throw new InvalidOperationException("Property name needs a value");
            if (string.IsNullOrWhiteSpace(this.propertyName))
                throw new InvalidOperationException("Property type needs a value");
        }
    }
}