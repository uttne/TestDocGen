using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDocGen.Builders;
using Xunit;
using Xunit.Abstractions;

namespace TestDocGen.Tests.Builders
{
    public class DocumentBuilderTests
    {
        private readonly ITestOutputHelper _output;

        public DocumentBuilderTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ItCreateDocument()
        {
            var builder = new DocumentBuilder()
            {
                StepNoGen = new NumericalStepNoGen(),
            };

            var id = Guid.NewGuid();

            builder
                .SetId(id)
                .SetTitle("Test Title")
                .SetSubTitle("Test Sub Title")
                .SetDescription("Test Description")
                .SetVersion("1.0.0.0")
                .AddTestItem(test => test
                    .SetChapter("Chapter1")
                    .SetSection("Section1")
                    .SetName("test1")
                    .SetDescription("description")
                    .SetTags(new[] {"tag1"})
                    .AddStep(step => step
                        .SetContent("content111")
                        .SetValidation("validation111")
                    )
                    .AddStep(step => step
                        .SetContent("content112")
                        .SetValidation("validation112")
                    )
                )
                .AddTestItem(test => test
                    .SetChapter("Chapter1")
                    .SetSection("Section2")
                    .SetName("test1")
                    .SetDescription("description")
                    .SetTags(new[] {"tag1"})
                    .AddStep(step => step
                        .SetContent("content121")
                        .SetValidation("validation121")
                    )
                    .AddStep(step => step
                        .SetContent("content122")
                        .SetValidation("validation122")
                    )
                )
                .AddTestItem(test => test
                    .SetChapter("Chapter2")
                    .SetSection("Section1")
                    .SetName("test1")
                    .SetDescription("description")
                    .SetTags(new[] { "tag1" })
                    .AddStep(step => step
                        .SetContent("content211")
                        .SetValidation("validation211")
                    )
                    .AddStep(step => step
                        .SetContent("content212")
                        .SetValidation("validation212")
                    )
                )
                .AddTestItem(test => test
                    .SetChapter("Chapter2")
                    .SetSection("Section2")
                    .SetName("test1")
                    .SetDescription("description")
                    .SetTags(new[] { "tag1" })
                    .AddStep(step => step
                        .SetContent("content221")
                        .SetValidation("validation221")
                    )
                    .AddStep(step => step
                        .SetContent("content222")
                        .SetValidation("validation222")
                    )
                );


            var document = builder.CreateDocument();
            
            Assert.Equal(id, document.Id);
            Assert.Equal("Test Title", document.Title);
            Assert.Equal("Test Sub Title", document.SubTitle);
            Assert.Equal("Test Description", document.Description);
            Assert.Equal("1.0.0.0", document.Version);

            var test = document.Tests[0];
            Assert.Equal("Chapter1", test.Chapter);
            Assert.Equal("Section1", test.Section);
            Assert.Equal("test1", test.Name);
            Assert.Equal("description", test.Description);
            Assert.True(new[]{"tag1"}.SequenceEqual(test.Tags));

            Assert.Equal("1", test.Steps[0].No);
            Assert.Equal("content111", test.Steps[0].Content);
            Assert.Equal("validation111", test.Steps[0].Validation);

            Assert.Equal("2", test.Steps[1].No);
            Assert.Equal("content112", test.Steps[1].Content);
            Assert.Equal("validation112", test.Steps[1].Validation);

            test = document.Tests[1];
            Assert.Equal("Chapter1", test.Chapter);
            Assert.Equal("Section2", test.Section);
            Assert.Equal("test1", test.Name);
            Assert.Equal("description", test.Description);
            Assert.True(new[] { "tag1" }.SequenceEqual(test.Tags));

            Assert.Equal("1", test.Steps[0].No);
            Assert.Equal("content121", test.Steps[0].Content);
            Assert.Equal("validation121", test.Steps[0].Validation);

            Assert.Equal("2", test.Steps[1].No);
            Assert.Equal("content122", test.Steps[1].Content);
            Assert.Equal("validation122", test.Steps[1].Validation);

            test = document.Tests[2];
            Assert.Equal("Chapter2", test.Chapter);
            Assert.Equal("Section1", test.Section);
            Assert.Equal("test1", test.Name);
            Assert.Equal("description", test.Description);
            Assert.True(new[] { "tag1" }.SequenceEqual(test.Tags));

            Assert.Equal("1", test.Steps[0].No);
            Assert.Equal("content211", test.Steps[0].Content);
            Assert.Equal("validation211", test.Steps[0].Validation);

            Assert.Equal("2", test.Steps[1].No);
            Assert.Equal("content212", test.Steps[1].Content);
            Assert.Equal("validation212", test.Steps[1].Validation);

            test = document.Tests[3];
            Assert.Equal("Chapter2", test.Chapter);
            Assert.Equal("Section2", test.Section);
            Assert.Equal("test1", test.Name);
            Assert.Equal("description", test.Description);
            Assert.True(new[] { "tag1" }.SequenceEqual(test.Tags));

            Assert.Equal("1", test.Steps[0].No);
            Assert.Equal("content221", test.Steps[0].Content);
            Assert.Equal("validation221", test.Steps[0].Validation);

            Assert.Equal("2", test.Steps[1].No);
            Assert.Equal("content222", test.Steps[1].Content);
            Assert.Equal("validation222", test.Steps[1].Validation);
        }
    }
}
