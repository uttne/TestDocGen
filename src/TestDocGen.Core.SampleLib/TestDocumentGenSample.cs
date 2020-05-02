using System;
using TestDocGen.Builders;

namespace TestDocGen.Core.SampleLib
{
    public class TestDocumentGenSample:ITestDocumentGen
    {
        public TestDocument Create()
        {
            var builder = new TestDocumentBuilder()
            {
                Title = "Test title"
            };

            return builder.Build();
        }
    }
}
