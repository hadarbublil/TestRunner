using System.Reflection;

namespace TestRunner{

    public class ExtractInfo{ 
        public static TestClassInfo ExtractTestClassInfo(Type type)
        {
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var classInfo = new TestClassInfo{
                ClassType = type
            };

            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<MyClassSetup>() != null){
                    classInfo.ClassSetup = method;
                }
                else if (method.GetCustomAttribute<MyClassTeardown>() != null){
                    classInfo.ClassTeardown = method;
                }
                else if (method.GetCustomAttribute<MySetup>() != null){
                    classInfo.SetupMethods.Add(method);
                }
                else if (method.GetCustomAttribute<MyTeardown>() != null){
                    classInfo.TeardownMethods.Add(method);
                }
                else if (method.GetCustomAttribute<MyTest>() != null){
                    classInfo.TestMethods.Add(method);
                }
            }

            return classInfo;
        }
    }

}