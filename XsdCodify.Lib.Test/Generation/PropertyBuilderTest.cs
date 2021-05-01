using System;

using Xunit;

using XsdCodify.Lib.Generation;
using XsdCodify.Lib.Generation.BuilderContexts;

namespace XsdCodify.Lib.Test
{
    public class PropertyBuilderTest
    {
        [Fact]
        public void CanMakeSimpleProperty()
        {
            //Given
            PropertyBuilder target = new PropertyBuilder();

            //When
            IPropertyContext result = target.Create("string", "MyProperty").Build();
            
            //Then
            Assert.Equal("public string MyProperty { get; set; }", result.ToString());
        }

        [Fact]
        public void CanMakePropertyWithOneAttribute()
        {
            //Given
            PropertyBuilder target = new PropertyBuilder();
            AttributeBuilder attributeBuilder = new AttributeBuilder();
            
            //When
            IPropertyContext result = target.Create("int", "MyValue")
                .Attribute(attributeBuilder.Create("MyAttribute").Build())
                .Build();
            
            //Then
            string expected = 
                $"[MyAttribute]" + Environment.NewLine +
                $"public int MyValue {{ get; set; }}";
            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void CanMakePropertyWithMoreAdvancedAttributes()
        {
            //Given
            PropertyBuilder target = new PropertyBuilder();
            AttributeBuilder attributeBuilder = new AttributeBuilder();
            
            //When
            IPropertyContext result = target.Create("MyType", "MyProperty")
                .Attribute(attributeBuilder.Create("SimpleAttribute").Build())
                .Attribute(attributeBuilder.Create("CustomAttribute")
                    .NamedStringConstantArgument("arg1", "val1")
                    .NamedStringConstantArgument("arg2", "val2")
                    .Build()
                ).Build();
            
            //Then
            string expected = $"[SimpleAttribute]" + Environment.NewLine +
                $"[CustomAttribute(arg1=\"val1\", arg2=\"val2\")]" + Environment.NewLine +
                $"public MyType MyProperty {{ get; set; }}";
            Assert.Equal(expected, result.ToString());
        }
    }
}