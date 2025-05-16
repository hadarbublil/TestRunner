namespace TestRunner
{
    public class SampleTests1
    {
        [MyTest]
        public void TestPassing()
        {
            // This test passes
        }

        [MyTest]
        public void TestFailing()
        {
            throw new Exception("This test fails intentionally.");
        }

        [MyTest]
        public void TestWithAssertion()
        {
            int expected = 5;
            int actual = 2 + 3;   

            if (expected != actual)
            {
                throw new Exception($"Expected {expected}, but got {actual}");
            }
        }

        public void NotATest()
        {
            // This should not run
        }
    }
}