using System.Reflection;

namespace TestRunner{
    public class OverallRunner(ClassRunner classRunner)
    {
        private readonly ClassRunner _classRunner = classRunner;

        public OverallResult RunAll(Assembly assembly)
        {
            var testClassInfos = assembly.GetTypes()
                .Where(t => t.IsClass && t.GetMethods().Any(m => m.IsDefined(typeof(MyTest), false)))
                .Select(ExtractInfo.ExtractTestClassInfo)
                .ToList();

            var classResults = testClassInfos
                .Select(info => _classRunner.Run(info)) 
                .ToList();

            return new OverallResult(classResults);
        }
    }
}