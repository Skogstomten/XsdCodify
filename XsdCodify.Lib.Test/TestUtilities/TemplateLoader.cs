using System.IO;

namespace XsdCodify.Lib.Test.TestUtilities
{
    public static class TemplateLoader
    {
        public static string Load(string templateName)
        {
            string fileContent = File.ReadAllText($"{templateName}.txt");
            return fileContent;
        }
    }
}