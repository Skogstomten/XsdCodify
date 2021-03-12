using System;
using System.Text;
using System.Collections.Generic;

namespace XsdCodify.Lib.Generation
{
    public class PropertyBuilder
    {
        private string typeName, propertyName;
        private List<string> attributes = new List<string>();

        public PropertyBuilderFluidSyntax Property(string typeName, string propertyName)
        {
            this.typeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
            this.propertyName = propertyName ?? throw new ArgumentNullException(nameof(ArgumentNullException));
            return new PropertyBuilderFluidSyntax(this);
        }

        public class PropertyBuilderFluidSyntax
        {
            private PropertyBuilder owner;
            
            public PropertyBuilderFluidSyntax(PropertyBuilder owner)
            {
                this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            }

            public PropertyBuilderFluidSyntax Attribute(string attribute)
            {
                if (string.IsNullOrWhiteSpace(attribute))
                    throw new ArgumentNullException(nameof(attribute));

                this.owner.attributes.Add(attribute);
                return this;
            }

            public string Build()
            {
                StringBuilder sb = new StringBuilder();
                this.owner.attributes.ForEach(attribute => sb.AppendLine(attribute));
                sb.AppendLine($"public {this.owner.typeName} {this.owner.propertyName} {{ get; set; }}");
                return sb.ToString().Trim();
            }

            private void VerifyRequiredArguments()
            {
                if (string.IsNullOrWhiteSpace(this.owner.typeName))
                    throw new InvalidOperationException($"Missing argument {nameof(this.owner.typeName)}");
                if (string.IsNullOrWhiteSpace(this.owner.propertyName))
                    throw new InvalidOperationException($"Missing argument {nameof(this.owner.propertyName)}");
            }
        }
    }
}