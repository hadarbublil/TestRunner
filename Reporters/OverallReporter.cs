namespace TestRunner{
    public class OverallReporter
    {
        private readonly ClassReporter _classReporter;
        private readonly IOutputWriter _output;

        public OverallReporter(ClassReporter classReporter, IOutputWriter output)
        {
            _classReporter = classReporter;
            _output = output;
        }

        public void Report(OverallResult overallResult)
        {
            foreach (var classResult in overallResult.ClassResults)
            {
                _classReporter.Report(classResult);
            }

            _output.WriteLine($"\nTotal Tests: {overallResult.TotalTests}");
            _output.WriteLine($"Total Passed: {overallResult.PassedTests}");
            _output.WriteLine($"Total Failed: {overallResult.FailedTests}");
        }
    }

}