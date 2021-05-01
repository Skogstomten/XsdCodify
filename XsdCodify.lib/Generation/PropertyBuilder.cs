using System;

using XsdCodify.Lib.Generation.BuilderContexts;

namespace XsdCodify.Lib.Generation
{
    public class PropertyBuilder
    {
        public PropertyBuilder()
        { }

        public PropertyBuilderFluidSyntax Create(string typeName, string propertyName)
        {
            PropertyContext context = new PropertyContext(typeName, propertyName);
            return new PropertyBuilderFluidSyntax(context);
        }

        public class PropertyBuilderFluidSyntax
        {
            private PropertyContext context;

            public PropertyBuilderFluidSyntax(PropertyContext context)
            {
                this.context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public PropertyBuilderFluidSyntax Attribute(IAttributeContext attribute)
            {
                if (attribute == null) throw new ArgumentNullException(nameof(attribute));
                this.context.AddAttribute(attribute);
                return this;
            }

            public IPropertyContext Build()
            {
                VerifyRequiredArguments();
                return this.context;
            }

            private void VerifyRequiredArguments()
            {
                this.context.Verify();
            }
        }
    }
}