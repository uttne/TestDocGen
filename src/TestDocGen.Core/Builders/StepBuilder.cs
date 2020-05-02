using System.Diagnostics;
using System.Linq;

namespace TestDocGen.Builders
{
    public class StepBuilder
    {
        public StepBuilder(TestItemBuilder test)
        {
            Test = test;
        }

        public string Content { get; set; }
        public string No { get; set; }
        public TestItemBuilder Test { get; }
        public string Validation { get; set; }

        public StepBuilder SetContent(string content)
        {
            Content = content;
            return this;
        }
        public StepBuilder SetNo(string no)
        {
            No = no;
            return this;
        }
        public StepBuilder SetValidation(string validation)
        {
            Validation = validation;
            return this;
        }

        public Step Build(Step prevStep = null, IStepNoGen stepNoGen = null)
        {
            var gen = stepNoGen ?? new NumericalStepNoGen();

            return new Step()
            {
                No = No ?? gen.NextNo(prevStep),
                Content = Content,
                Validation = Validation,
            };
        }
    }
}