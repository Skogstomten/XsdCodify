using System;

using XsdCodify.Lib.Generation.BuilderContexts;
using XsdCodify.Lib.Generation.Arguments;

namespace XsdCodify.Lib.Generation
{
    public class AttributeBuilder
    {
        public AttributeBuilderFluidSyntax Create(string attributeName)
        {
            if (attributeName == null) throw new ArgumentNullException(nameof(attributeName));
            AttributeContext context = new AttributeContext(attributeName);
            return new AttributeBuilderFluidSyntax(context);
        }

        public class AttributeBuilderFluidSyntax
        {
            private readonly AttributeContext context;

            public AttributeBuilderFluidSyntax(AttributeContext context)
            {
                this.context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public IAttributeContext Build()
            {
                this.context.Verify();
                return this.context;
            }

            public AttributeBuilderFluidSyntax NamedStringConstantArgument(string argumentName, string argumentValue)
            {
                this.context.AddArgument(new AttributeNamedStringConstantArgument(argumentName, argumentValue));
                return this;
            }
        }
    }
}