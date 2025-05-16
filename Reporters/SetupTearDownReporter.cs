namespace TestRunner
{
    public class SetupTeardownReporter
    {
        private readonly IOutputWriter _output;

        public SetupTeardownReporter(IOutputWriter output)
        {
            _output = output;
        }

        public void Report(string prefix, SetupTeardownResult res)
        {
            if (!res.Exists){
                _output.WriteLine($"  {prefix}: Not present");
            }
            else if (res.Passed){
                _output.WriteLine($"  {prefix}: Passed");
            }
            else{
                _output.WriteLine($"  {prefix}: Failed - {res.Error}");
            }
        }
    }
}
