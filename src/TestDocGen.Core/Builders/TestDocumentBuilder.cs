using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDocGen.Builders
{
    public class TestDocumentBuilder
    {
        public string Description { get; set; }
        public Guid? Id { get; set; }
        public string SubTitle { get; set; }
        public List<TestItemBuilder> Tests { get; } = new List<TestItemBuilder>();
        public string Title { get; set; }
        public string Version { get; set; }
        public IStepNoGen StepNoGen { get; set; }
        public TestDocumentBuilder AddTestItem(AddTestItemHandler handler)
        {
            var test = new TestItemBuilder(this)
            {
                StepNoGen = StepNoGen,
            };
            Tests.Add(test);

            handler?.Invoke(test);

            return this;
        }

        public TestDocument Build()
        {
            return new TestDocument()
            {
                Id = Id ?? Guid.NewGuid(),
                Title = Title,
                SubTitle = SubTitle,
                Version = Version,
                Description = Description,
                Tests = Tests.Select(x => x.Build()).ToList()
            };
        }

        public TestDocumentBuilder SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public TestDocumentBuilder SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public TestDocumentBuilder SetSubTitle(string subTitle)
        {
            SubTitle = subTitle;
            return this;
        }

        public TestDocumentBuilder SetTitle(string title)
        {
            Title = title;
            return this;
        }
        public TestDocumentBuilder SetVersion(string version)
        {
            Version = version;
            return this;
        }
    }
}