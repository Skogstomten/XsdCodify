using System;
using System.Text;

namespace XsdCodify.Lib.Generation
{
    public class ClassBuilder
    {
        private string className;

        public ClassBuilderFluidSyntax Class(string className)
        {
            this.className = className ?? throw new ArgumentNullException(nameof(className));
            return new ClassBuilderFluidSyntax(this);
        }

        public class ClassBuilderFluidSyntax
        {
            private ClassBuilder owner;

            public ClassBuilderFluidSyntax(ClassBuilder owner)
            {
                this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            }

            public ClassBuilderFluidSyntax Property(string property)
            {
                return this;
            }

            public string Build()
            {
                StringBuilder sb = new StringBuilder()
                    .AppendLine($"public class {this.owner.className}")
                    .AppendLine("{")
                    .AppendLine()
                    .AppendLine("}");
                return sb.ToString().Trim();
            }
        }
    }
}