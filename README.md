# 🧪 TestRunner

A test runner in C# that supports per-test and per-class setup/teardown logic, and produces structured test reports with detailed failure messages.

---

## 🚀 Features

- ✅ Execute individual test methods dynamically via reflection  
- ⚙️ Supports `[Setup]` and `[Teardown]` attributes for both test methods and test classes  
- 📋 Reports pass/fail status for each test, including detailed error messages  
- 📂 Reports pass/fail/not exist status for each setup/teardown method  
- 📂 Outputs results to file or console 
- 🧼 Clean object-oriented design with support for extensibility  
- 📊 Summary reporting per class, and for all the running tests

---

## ✅ How to Write Tests

Annotate methods in your test classes using custom attributes:

```csharp
[Test]
public void ShouldAddNumbersCorrectly() { ... }

[Setup]
public void InitTestEnvironment() { ... }

[Teardown]
public void CleanUp() { ... }

You can also define class-level setup/teardown:

[ClassSetup]
public void SetupAll() { ... }

[ClassTeardown]
public void TeardownAll() { ... }

```

## 📦 Running Tests
    Run the tests by executing the `Program.cs` file with the following command in your terminal:
    dotnet run
    Before running, make sure to modify the assembly path in the code to specify which assembly to load, for example:
    var assembly = Assembly.LoadFrom("bin/Debug/net8.0/TestRunner.dll");

## 📄 Output Example

   Results for FailingTeardownTest class:
   Class Setup: Not present
   Setup: Passed
   Test: Failed
     Error: Teardown failed
   Teardown: Failed - Teardown failed intentionally

## 🧰 Requirements
    .NET 6.0 or higher
    C# 10 or newer (nullable reference types enabled recommended)


## Next steps:

🧠 Richer Error Reporting
Include additional debugging info such as execution time, stack trace, and optional logs when a test fails.

🧪 Support for Parameterized Tests
Extend the runner to support tests that accept parameters (e.g., using [TestCase(...)]-like attributes).

⚡ Multi-threaded Execution
Improve performance by running tests in parallel where safe.

🎯 Selective Test Execution
Add the ability to run a specific subset of tests based on class name, method name, or attributes.