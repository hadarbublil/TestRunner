namespace TestRunner
{
    public class SetupTeardownResult
    {
        public bool Exists { get; }
        public bool? Succeeded { get; }
        public string? Error { get; }
        public bool Passed => Exists && Succeeded == true;

        public SetupTeardownResult(bool exists, bool? succeeded, string? error)
        {
            Exists = exists;
            Succeeded = succeeded;
            Error = error;
        }
    }
}
