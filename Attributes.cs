namespace TestRunner
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MyTest : Attribute{}
    [AttributeUsage(AttributeTargets.Method)]
    public class MySetup : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyTeardown : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyClassTeardown : Attribute { }
    
    [AttributeUsage(AttributeTargets.Method)]
    public class MyClassSetup : Attribute { }



}
