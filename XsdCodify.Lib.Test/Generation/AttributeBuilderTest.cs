using Xunit;

using XsdCodify.Lib.Generation;
using XsdCodify.Lib.Generation.BuilderContexts;

namespace XsdCodify.Lib.Test.Generation
{
    public class AttributeBuilderTest
    {
        [Fact]
        public void CanCreateSimpleAttribute()
        {
            //Given
            AttributeBuilder target = new AttributeBuilder();
        
            //When
            IAttributeContext result = target.Create("MyAttribute").Build();

            //Then
            Assert.Equal("[MyAttribute]", result.ToString());
        }

        [Fact]
        public void CanCreateAttributeWithStringValueArgument()
        {
            //Given
            AttributeBuilder target = new AttributeBuilder();
            
            //When
            IAttributeContext result = target.Create("MyAttribute")
                .NamedStringConstantArgument("argName", "myValue")
                .Build();
            
            //Then
            Assert.Equal("[MyAttribute(argName=\"myValue\")]", result.ToString());
        }

        [Fact]
        public void CanCreateAttributeWithMultipleStringValueArguments()
        {
            //Given
            AttributeBuilder target = new AttributeBuilder();
            
            //When
            IAttributeContext result = target.Create("MyAttribute")
                .NamedStringConstantArgument("arg1", "value1")
                .NamedStringConstantArgument("arg2", "value2")
                .Build();
            
            //Then
            Assert.Equal("[MyAttribute(arg1=\"value1\", arg2=\"value2\")]", result.ToString());
        }
    }
}