using System;

using Xunit;

using XsdCodify.Lib.Generation;
using XsdCodify.Lib.Generation.BuilderContexts;

using XsdCodify.Lib.Test.TestUtilities;

namespace XsdCodify.Lib.Test.Generation
{
    public class ClassBuilderTest
    {
        [Fact]
        public void CanMakeEmptyClass()
        {
            //Given
            ClassBuilder target = new ClassBuilder();
            
            //When
            IClassContext result = target.Class("MyClass").Build();
            
            //Then
            string expected = $"public class MyClass" + Environment.NewLine +
                "{" + Environment.NewLine + Environment.NewLine + "}";
            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void CanMakeClassWithProperties()
        {
            //Given
            ClassBuilder target = new ClassBuilder();
            PropertyBuilder propertyBuilder = new PropertyBuilder();
            AttributeBuilder attributeFactory = new AttributeBuilder();
            
            //When
            IClassContext result = target.Class("MyClass")
                .Property(propertyBuilder.Create("string", "Prop1").Build())
                .Property(propertyBuilder.Create("MyType", "Prop2")
                    .Attribute(attributeFactory
                        .Create("MyAttribute")
                        .NamedStringConstantArgument("arg1", "val1")
                        .Build())
                    .Build())
                .Build();
            
            //Then
            string expected = TemplateLoader.Load("CanMakeClassWithProperties");
            Assert.Equal(expected, result.ToString());
        }
    }
}