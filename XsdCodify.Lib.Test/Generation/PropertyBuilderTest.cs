using System;

using Xunit;

using XsdCodify.Lib.Generation;
using XsdCodify.Lib.Generation.Arguments;

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
            string result = target.Property("string", "MyProperty")
                .Build();
            
            //Then
            Assert.Equal("public string MyProperty { get; set; }", result);
        }

        [Fact]
        public void CanMakePropertyWithOneAttribute()
        {
            //Given
            PropertyBuilder target = new PropertyBuilder();
            AttributeFactory attributeFactory = new AttributeFactory();
            
            //When
            string result = target.Property("int", "MyValue")
                .Attribute(attributeFactory.Create("MyAttribute"))
                .Build();
            
            //Then
            string expected = 
                $"[MyAttribute]" + Environment.NewLine +
                $"public int MyValue {{ get; set; }}";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanMakePropertyWithMoreAdvancedAttributes()
        {
            //Given
            PropertyBuilder target = new PropertyBuilder();
            AttributeFactory attributeFactory = new AttributeFactory();
            
            //When
            string result = target.Property("MyType", "MyProperty")
                .Attribute(attributeFactory.Create(
                    "SimpleAttribute"
                ))
                .Attribute(attributeFactory.Create(
                    "CustomAttribute",
                    new AttributeNamedStringConstantArgument("arg1", "val1"),
                    new AttributeNamedStringConstantArgument("arg2", "val2")
                ))
                .Build();
            
            //Then
            string expected = $"[SimpleAttribute]" + Environment.NewLine +
                $"[CustomAttribute(arg1=\"val1\", arg2=\"val2\")]" + Environment.NewLine +
                $"public MyType MyProperty {{ get; set; }}";
            Assert.Equal(expected, result);
        }
    }
}