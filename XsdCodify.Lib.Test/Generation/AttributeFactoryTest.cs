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
    }
}