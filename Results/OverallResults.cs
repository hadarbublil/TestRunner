namespace TestRunner
{
    public class OverallResult
    {
        public List<ClassResult> ClassResults { get; }

        public int TotalTests { get; }
        public int PassedTests { get; }
        public int FailedTests => TotalTests - PassedTests;

        public OverallResult(List<ClassResult> classResults)
        {
            ClassResults = classResults;

            int total = 0;
            int passed = 0;

            foreach (var classResult in classResults)
            {
                total += classResult.TestResults.Count;
                passed += classResult.PassedCount;
            }

            TotalTests = total;
            PassedTests = passed;
        }
    }
}