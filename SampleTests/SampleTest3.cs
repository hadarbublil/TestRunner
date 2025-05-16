namespace TestRunner
{
    public class FailingSetupTest
    {
        [MySetup]
        public void Setup()
        {
            throw new Exception("Setup failed intentionally");
        }

        [MyTest]
        public void Test()
        {
            Console.WriteLine("skip test because setup failed");
        }

        [MyTeardown]
        public void Teardown()
        {

            Console.WriteLine("skip Teardown because setup failed");
        }
    }

    public class FailingTeardownTest
    {
        [MySetup]
        public void Setup()
        {
            Console.Write("Setup secceed\n");
        }

        [MyTest]
        public void Test()
        {
            Console.Write("test pass\n");
        }

        [MyTeardown]
        public void Teardown()
        {
            throw new Exception("Teardown failed intentionally\n");
        }
    }

    public class FailingClassSetup
    {
        [MyClassSetup]
        public void ClassSetup()
        {
            throw new Exception("Class Setup failed intentionally\n");
        }

        public void Setup()
        {
            Console.WriteLine("skip setup because class setup failed");
        }

        [MyTest]
        public void Test()
        {
            Console.WriteLine("skip test because class setup failed");
        }

        [MyTeardown]
        public void Teardown()
        {
            throw new Exception("skip teardown because class setup failed\n");
        }
        
        [MyClassTeardown]
        public void ClassTeardown()
        {
            throw new Exception("skip Class teardown because setup failed\n");
        }
    }
}