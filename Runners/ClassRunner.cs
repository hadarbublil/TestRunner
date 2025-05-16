using System.Reflection;

namespace TestRunner
{
    public class ClassRunner
    {
        private readonly TestRunnerEngine _testRunner;

        public ClassRunner(TestRunnerEngine testRunner)
        {
            _testRunner = testRunner;
        }

        public ClassResult Run(TestClassInfo classInfo)
        {
            var instance = Activator.CreateInstance(classInfo.ClassType)!;
            var classResult = new ClassResult(classInfo.ClassType.Name, new List<TestResult>());

            var setupResult = SetupTeardownRunner.RunSetupTeardown(instance, classInfo.ClassSetup);
            classResult.ClassSetup = setupResult;

            if (!setupResult.Exists || setupResult.Passed)
            {
                RunTests(classInfo, classResult, instance);
                var teardownResult = SetupTeardownRunner.RunSetupTeardown(instance, classInfo.ClassTeardown);
                classResult.ClassTeardown = teardownResult;
            }

            return classResult;
        }

        private void RunTests(TestClassInfo classInfo, ClassResult classResult, object instance)
        {
            List<MethodInfo> testMethods = classInfo.TestMethods;
            foreach (var method in testMethods)
            {
                var testResult = _testRunner.RunTest(
                    method,
                    instance, 
                    classInfo.SetupMethods,
                    classInfo.TeardownMethods
                );
                classResult.TestResults.Add(testResult);
            }
        }
    }
}
