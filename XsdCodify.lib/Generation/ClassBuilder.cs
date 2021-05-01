using System;

using XsdCodify.Lib.Generation.BuilderContexts;

namespace XsdCodify.Lib.Generation
{
    public class ClassBuilder
    {
        public ClassBuilder()
        { }

        public ClassBuilderFluidSyntax Class(string className)
        {
            ClassContext context = new ClassContext(className);
            return new ClassBuilderFluidSyntax(context);
        }

        public class ClassBuilderFluidSyntax
        {
            private readonly ClassContext context;

            public ClassBuilderFluidSyntax(ClassContext context)
            {
                this.context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public IClassContext Build()
            {
                this.context.Verify();
                return this.context;
            }

            public ClassBuilderFluidSyntax Property(IPropertyContext property)
            {
                this.context.AddProperty(property);
                return this;
            }
        }
    }
}