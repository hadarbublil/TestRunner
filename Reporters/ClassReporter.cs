namespace TestRunner
{
    public class ClassReporter
    {
        private readonly TestReporter _testReporter;
        private readonly IOutputWriter _output;
        private readonly SetupTeardownReporter _setupTeardownReporter;

        public ClassReporter(TestReporter testReporter, IOutputWriter output)
        {
            _testReporter = testReporter;
            _output = output;
            _setupTeardownReporter = new SetupTeardownReporter(output);
        }

        public void Report(ClassResult classResult)
        {
            _output.WriteLine($"\nResults for {classResult.ClassName} class:");

            _setupTeardownReporter.Report(
                "Class Setup",
                classResult.ClassSetup
            );

            foreach (var testResult in classResult.TestResults)
            {
                _testReporter.Report(testResult);
            }

            _setupTeardownReporter.Report(
                "Class Teardown",
                classResult.ClassTeardown
            );

            _output.WriteLine($"  {classResult.ClassName} - Passed: {classResult.PassedCount}, Failed: {classResult.FailedCount}");
        }
    }
}
