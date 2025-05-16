# 🧪 TestRunner

A test runner in C# that supports per-test and per-class setup/teardown logic, and produces structured test reports with detailed failure messages.

---

## Key design decisions:
- 🔍 **Reflection-based discovery**: Methods are annotated with custom attributes (`[Test]`, `[Setup]`, etc.), allowing dynamic identification and invocation.
- 🧼 **Separation of concerns**: The system is organized into multiple classes (e.g., runners, reporters, output writers) to maintain clean, testable and easy to enhance code.
- 📂 **Structured reporting**: Output includes class-level and method-level results, with clear handling for setup/teardown methods.
- 💾 **Flexible output**: Results can be printed to the console or written to a file.

---

## 🏗️ Architecture & Flow
The TestRunner is built around four primary components that work together across three levels of scope:

- Extractor: Responsible for discovering test classes and methods using reflection

    Find test classes, methods, and setup/teardown methods via attributes
    Create class information for execution


- Runners: Handle the execution of tests and their setup/teardown routines

    TestRunnerEngine: Runs individual test methods
    ClassRunner: Coordinates class-level setup/teardown and all tests within a class
    OverallRunner: Manages the overall execution across all test classes
    SetupTeardownRunner: Manages the execution of setup and teardown methods


- Results: Structured data classes that encapsulate test outcomes

    TestResult: Contains information about an individual test method execution
    ClassResult: Groups test results by class with class-level setup/teardown info
    OverallRunner: Aggregates all class results with overall statistics
    SetupTeardownResult: Encapsulates the outcome of setup/teardown methods


- Reporters: Format and output test results

    TestReporter: Reports results for individual tests
    ClassReporter: Displays class-level summary and test details
    OverallReporter: Shows the overall summary of the entire test run
    SetupTeardownReporter: Formats setup/teardown outcomes consistently

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
    Run the tests by executing the `Program.cs` file with the following commands in your terminal:
    dotnet build
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