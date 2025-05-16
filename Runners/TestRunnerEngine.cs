using System.Reflection;

namespace TestRunner{
    public class TestRunnerEngine
    {
        public TestResult RunTest(
            MethodInfo method,
            object instance,
            List<MethodInfo> setupMethods,
            List<MethodInfo> teardownMethods)
        {
            var className = method.DeclaringType?.Name ?? "Unknown";
            var testName = method.Name;

            try
            {
                SetupTeardownResult? setupResult = null;
                foreach (var setupMethod in setupMethods)
                {
                    setupResult = SetupTeardownRunner.RunSetupTeardown(instance, setupMethod);
                    if (!setupResult.Passed)
                    {
                        return new TestResult(testName, className, false, "Setup failed", setupResult, null);
                    }
                }

                method.Invoke(instance, null);

                SetupTeardownResult? lastTeardownRes = null;
                foreach (var teardownMethod in teardownMethods)
                {
                    lastTeardownRes = SetupTeardownRunner.RunSetupTeardown(instance, teardownMethod);
                    if (!lastTeardownRes.Passed)
                    {
                        return new TestResult(testName, className, false, "Teardown failed", setupResult, lastTeardownRes);
                    }
                }
                return new TestResult(testName, className, true, null, setupResult, lastTeardownRes);

            }
            catch (Exception ex)
            {
                return new TestResult(testName, className, false, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}