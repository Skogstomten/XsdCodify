using System;
using Xunit;
using XsdCodify.Lib.Generation;
using XsdCodify.Lib.Generation.Arguments;
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
            string result = target.Class("MyClass")
                .Build();
            
            //Then
            string expected = $"public class MyClass" + Environment.NewLine +
                "{" + Environment.NewLine + Environment.NewLine + "}";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanMakeClassWithProperties()
        {
            //Given
            ClassBuilder target = new ClassBuilder();
            PropertyBuilder propertyBuilder = new PropertyBuilder();
            AttributeFactory attributeFactory = new AttributeFactory();
            
            //When
            string result = target.Class("MyClass")
                .Property(propertyBuilder.Property("string", "Prop1")
                    .Build())
                .Property(propertyBuilder.Property("MyType", "Prop2")
                    .Attribute(attributeFactory.Create(
                        "MyAttribute",
                        new AttributeNamedStringConstantArgument("arg1", "value1")
                    ))
                    .Build())
                .Build();
            
            //Then
            string expected = TemplateLoader.Load("CanMakeClassWithProperties");
            Assert.Equal(expected, result);
        }
    }
}