using System.Reflection;

namespace TestRunner
{
    public class TestClassInfo
    {
        public required Type ClassType { get; set; }
        public MethodInfo? ClassSetup { get; set; }
        public MethodInfo? ClassTeardown { get; set; }
        public List<MethodInfo> SetupMethods { get; set; } = new();
        public List<MethodInfo> TeardownMethods { get; set; } = new();
        public List<MethodInfo> TestMethods { get; set; } = new();
    }
}
