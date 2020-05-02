using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestDocGen.Builders
{
    public class TestItemBuilder
    {
        public TestItemBuilder(TestDocumentBuilder testDocument)
        {
            TestDocument = testDocument;
        }

        public string Chapter { get; set; }

        public string Description { get; set; }
        public TestDocumentBuilder TestDocument { get; }
        public string Name { get; set; }
        public string Section { get; set; }
        public List<StepBuilder> Steps { get; } = new List<StepBuilder>();
        public List<string> Tags { get; } = new List<string>();



        public TestItemBuilder SetChapter(string chapter)
        {
            Chapter = chapter;
            return this;
        }

        public TestItemBuilder SetDescription(string description)
        {
            Description = description;
            return this;
        }
        public TestItemBuilder SetName(string name)
        {
            Name = name;
            return this;
        }
        public TestItemBuilder SetSection(string section)
        {
            Section = section;
            return this;
        }
        public TestItemBuilder SetTags(IEnumerable<string> tags)
        {
            Tags.AddRange(tags ?? new string[]{});

            return this;
        }

        public TestItemBuilder AddTag(string tag)
        {
            Tags.Add(tag);
            return this;
        }

        public TestItemBuilder AddStep(AddStepHandler handler)
        {
            var step = new StepBuilder(this);
            Steps.Add(step);

            handler?.Invoke(step);

            return this;
        }

        public IStepNoGen StepNoGen { get; set; }

        public TestItem Build()
        {

            var stepNoGen = StepNoGen;
            return new TestItem()
            {
                Chapter = Chapter,
                Section = Section,
                Name = Name,
                Description = Description,
                Tags = Tags.ToList(),
                Steps = Steps.Aggregate(new List<Step>(), (list, x) =>
                {
                    list.Add(x.Build(list.LastOrDefault(),stepNoGen));
                    return list;
                }),
            };
        }
    }
}