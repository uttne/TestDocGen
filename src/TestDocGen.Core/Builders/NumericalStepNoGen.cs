namespace TestDocGen.Builders
{
    public class NumericalStepNoGen : IStepNoGen
    {
        public string NextNo(Step prevStep)
        {
            int.TryParse(prevStep?.No ?? "0", out var no);
            return (++no).ToString();
        }
    }
}