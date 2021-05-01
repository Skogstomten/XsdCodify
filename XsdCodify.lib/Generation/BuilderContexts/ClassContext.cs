using System;
using System.Text;
using System.Collections.Generic;

namespace XsdCodify.Lib.Generation.BuilderContexts
{
    public class ClassContext : IClassContext
    {
        private readonly string className;
        private readonly List<IPropertyContext> properties = new List<IPropertyContext>();

        public ClassContext(string className)
        {
            this.className = className ?? throw new ArgumentNullException(nameof(className));
        }

        internal void AddProperty(IPropertyContext property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            this.properties.Add(property);
        }

        internal void Verify()
        {
            if (string.IsNullOrWhiteSpace(this.className))
                throw new InvalidOperationException("Class name must have a value");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public class {this.className}")
              .AppendLine("{");
            foreach (IPropertyContext context in this.properties)
            {
                sb.AppendLine(context.ToString());
            }
            sb.AppendLine("}");
            return sb.ToString().Trim();
        }
    }
}