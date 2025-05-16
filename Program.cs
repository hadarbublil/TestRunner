using System.Reflection;

namespace TestRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileOutputWriter = new FileOutputWriter("Output/test_results.txt"); // can also use ConsoleOutputWriter

            var testRunner = new TestRunnerEngine();
            var classRunner = new ClassRunner(testRunner);
            var overallRunner = new OverallRunner(classRunner);

            var testReporter = new TestReporter(fileOutputWriter);
            var classReporter = new ClassReporter(testReporter, fileOutputWriter);
            var overallReporter = new OverallReporter(classReporter, fileOutputWriter);

            var assembly = Assembly.LoadFrom("bin/Debug/net8.0/TestRunner.dll");
            
            var overallResult = overallRunner.RunAll(assembly);

            overallReporter.Report(overallResult);
        }

    }
}