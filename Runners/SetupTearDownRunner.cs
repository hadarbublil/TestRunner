using System.Reflection;

namespace TestRunner
{
    public static class SetupTeardownRunner
    {
        public static SetupTeardownResult RunSetupTeardown(object instance, MethodInfo? method)
        {
            if (method == null)
                return new SetupTeardownResult(false, null, null); // method doesn't exist

            try
            {
                method.Invoke(instance, null);
                return new SetupTeardownResult(true, true, null); // method exists and succeed
            }
            catch (TargetInvocationException ex)
            {
                var error = ex.InnerException?.Message ?? ex.Message;
                return new SetupTeardownResult(true, false, error); // method exists and failed
            }
        }
    }
}