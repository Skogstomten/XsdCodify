using System;

namespace XsdCodify.Lib.Generation.Arguments
{
    public class AttributeNamedStringConstantArgument : IAttributeArgument
    {
        private string argumentName, argumentValue;

        public AttributeNamedStringConstantArgument(string argumentName, string argumentValue)
        {
            this.argumentName = argumentName ?? throw new ArgumentNullException(nameof(argumentName));
            this.argumentValue = argumentValue ?? throw new ArgumentNullException(nameof(argumentValue));
        }

        public string Formatted => $"{argumentName}=\"{argumentValue}\"";
    }
}