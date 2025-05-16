namespace TestRunner
{
    public class TestReporter
    {
        private readonly IOutputWriter _output;
        private readonly SetupTeardownReporter _setupTeardownReporter;

        public TestReporter(IOutputWriter output)
        {
            _output = output;
            _setupTeardownReporter = new SetupTeardownReporter(output);
        }

        public void Report(TestResult result)
        {
            _setupTeardownReporter.Report("Setup", result.Setup);
            _output.WriteLine($"  {result.TestName}: {(result.Passed ? "Passed" : "Failed")}");
            if (!result.Passed && !string.IsNullOrEmpty(result.ErrorMessage))
            {
                _output.WriteLine($"    Error: {result.ErrorMessage}");
            }
            _setupTeardownReporter.Report("Teardown", result.Teardown);
            _output.WriteLine("");
        }
    }
}
