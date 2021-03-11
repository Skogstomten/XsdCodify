using Xunit;

using XsdCodify.Lib.Generation;
using XsdCodify.Lib.Generation.Arguments;

namespace XsdCodify.Lib.Test.Generation
{
    public class AttributeFactoryTest
    {
        [Fact]
        public void CanCreateSimpleAttribute()
        {
            //Given
            AttributeFactory target = new AttributeFactory();
        
            //When
            string result = target.Create("MyAttribute");

            //Then
            Assert.Equal("[MyAttribute]", result);
        }

        [Fact]
        public void CanCreateAttributeWithStringValueArgument()
        {
            //Given
            AttributeFactory target = new AttributeFactory();
            
            //When
            string result = target.Create("MyAttribute", new AttributeNamedStringConstantArgument("argName", "myValue"));
            
            //Then
            Assert.Equal("[MyAttribute(argName=\"myValue\")]", result);
        }

        [Fact]
        public void CanCreateAttributeWithMultipleStringValueArguments()
        {
            //Given
            AttributeFactory target = new AttributeFactory();
            
            //When
            string result = target.Create(
                "MyAttribute",
                new AttributeNamedStringConstantArgument("arg1", "value1"),
                new AttributeNamedStringConstantArgument("arg2", "value2")
            );
            
            //Then
            Assert.Equal("[MyAttribute(arg1=\"value1\", arg2=\"value2\")]", result);
        }
    }
}