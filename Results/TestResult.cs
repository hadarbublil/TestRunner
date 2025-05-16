namespace TestRunner
{
    public class TestResult
    {
        public string TestName { get; }
        public string ClassName { get; }
        public bool Passed { get; }
        public string? ErrorMessage { get; }

        public SetupTeardownResult Setup { get; }
        public SetupTeardownResult Teardown { get; }

        public TestResult(string testName, string className, bool passed, string? errorMessage = null,
                        SetupTeardownResult? setup = null, SetupTeardownResult? teardown = null)
        {
            TestName = testName;
            ClassName = className;
            Passed = passed;
            ErrorMessage = errorMessage;
            
            // Default to "Not present" if no setup/teardown is provided
            Setup = setup ?? new SetupTeardownResult(false, null, null);
            Teardown = teardown ?? new SetupTeardownResult(false, null, null);
        }
    }

}