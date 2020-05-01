using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDocGen.Builders
{
    public class DocumentBuilder
    {
        public string Description { get; set; }
        public Guid? Id { get; set; }
        public string SubTitle { get; set; }
        public List<TestItemBuilder> Tests { get; } = new List<TestItemBuilder>();
        public string Title { get; set; }
        public string Version { get; set; }
        public IStepNoGen StepNoGen { get; set; }
        public DocumentBuilder AddTestItem(AddTestItemHandler handler)
        {
            var test = new TestItemBuilder(this)
            {
                StepNoGen = StepNoGen,
            };
            Tests.Add(test);

            handler?.Invoke(test);

            return this;
        }

        public TestDocument CreateDocument()
        {
            return new TestDocument()
            {
                Id = Id ?? Guid.NewGuid(),
                Title = Title,
                SubTitle = SubTitle,
                Version = Version,
                Description = Description,
                Tests = Tests.Select(x => x.CreateTest()).ToList()
            };
        }

        public DocumentBuilder SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public DocumentBuilder SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public DocumentBuilder SetSubTitle(string subTitle)
        {
            SubTitle = subTitle;
            return this;
        }

        public DocumentBuilder SetTitle(string title)
        {
            Title = title;
            return this;
        }
        public DocumentBuilder SetVersion(string version)
        {
            Version = version;
            return this;
        }
    }
}