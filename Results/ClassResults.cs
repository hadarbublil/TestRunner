namespace TestRunner
{
    public class ClassResult
    {
        public string ClassName { get; }
        public List<TestResult> TestResults { get; }

        public int PassedCount => TestResults.Count(t => t.Passed);
        public int FailedCount => TestResults.Count - PassedCount;

        public SetupTeardownResult ClassSetup { get; set;}
        public SetupTeardownResult ClassTeardown { get; set;}

        public ClassResult(string className, List<TestResult>? testResults = null,
            SetupTeardownResult? classSetup = null,
            SetupTeardownResult? classTeardown = null)
        {
            ClassName = className;
            TestResults = testResults ?? new List<TestResult>();
            
            // Default to "Not present" if no class setup/teardown is provided
            ClassSetup = classSetup ?? new SetupTeardownResult(false, null, null);
            ClassTeardown = classTeardown ?? new SetupTeardownResult(false, null, null);
        }
    }
}
