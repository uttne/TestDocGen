using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TestDocGen
{
    public static class TestDocumentExtensions
    {
        public static string ToYaml(this TestDocument self)
        {
            var serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();

            return serializer.Serialize(self);
        }
    }
}