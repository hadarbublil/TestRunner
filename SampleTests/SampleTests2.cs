namespace TestRunner
{
    public class SampleTests2
    {
        [MyClassSetup]
        public void InitClass()
        {
            Console.WriteLine("Init class");
        }

        [MySetup]
        public void Setup()
        {
            Console.WriteLine("Setup executed");
        }

        [MyTeardown]
        public void Teardown()
        {
            Console.WriteLine("Teardown executed");
        }

        [MyTest]
        public void TestMethod1()
        {
            // should pass
        }

        [MyTest]
        public void TestMethod2()
        {
            //should pass
        }

        [MyClassTeardown]
        public void CleanupClass()
        {
            Console.WriteLine("Clean up class");
        }
    }
}
