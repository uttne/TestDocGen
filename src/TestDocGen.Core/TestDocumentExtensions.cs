using YamlDotNet.Serialization;

namespace TestDocGen
{
    public static class TestDocumentExtensions
    {
        public static string ToYaml(this TestDocument self)
        {
            var serializer = new SerializerBuilder().Build();

            return serializer.Serialize(self);
        }
    }
}