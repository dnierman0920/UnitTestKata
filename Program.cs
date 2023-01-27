/*
1. Write a failing test(As close to zero changes to code) - compilation errors are okay to fix in prod! 
2. Make the test pass(DO NOT CHANGE TEST!)
3. Change the code (without breaking the test) aka refactoring
*/

/*
4 PARTS TO TEST FRAMEWORK
1) Test Discovery
2) Executer
3) Asserter
4) Result Summarizer
*/


internal class Program
{

    private static void Main(string[] args)
    {
        Action[] tests = { Test1, Test3, Test4, Test5, Test6, Test7, CallPassedTestTwice, CallRecordFailingTest, CallRecordFailingTwice, CallRecordFailingTestName, CallRecordFailingTestToTestException, CallExecuteTestsToTestSummary, CallExecuteTestToTestPassedCount, CallExecuteTestToTestFailedCount };
        ExecuteTests(tests, new System.IO.StringWriter());

        //  Executor
        static void ExecuteTests(Action[] tests, System.IO.TextWriter writer)
        {
            var testResults = new TestResults();
            foreach (System.Action test in tests)
            {
                try
                {
                    test();
                    testResults.RecordPassingTest(test.Method.Name, writer);
                }
                catch (Exception e)
                {
                    testResults.RecordFailingTest(test.Method.Name, writer, e);
                }

            }
            testResults.Summarize(writer);

            System.Console.Write($"\n{writer.ToString()}");
        }
        // Asserter
        static void Assert<TException>(Action test) where TException : Exception
        {
            try
            {
                test();
            }
            catch (TException)
            {

            }

            catch (Exception e2)
            {
                throw new System.Exception($"unexpected exception type {e2.GetType()}");
            }
        }

        // Test Discovery
        static void Test1()
        {
            static void M()
            {
                throw new DivideByZeroException("Divide by zero");
            }
            Assert<DivideByZeroException>(M);
        }

        static void Test3()
        {
            static void M()
            {
                throw new System.InvalidTimeZoneException("This exception should fail");
            }
            Assert<InvalidTimeZoneException>(M);
        }

        static void Test4()
        {
            static void M()
            {
                throw new System.ArgumentException("This exception should fail");
            }
            Assert<ArgumentException>(M);
        }

        // testResults.Summarize is building the correct string to display passed count & failed count
        static void Test5()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            testResults.Summarize(sw);
            string expected = $"Passed#:{0} | Failed#:{0}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // testResult.RecordPassingTest is incrementing passed test count by 1 (passedCount)
        static void Test6()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            testResults.RecordPassingTest("random string", System.IO.TextWriter.Null);
            testResults.Summarize(sw);
            string expected = $"Passed#:{1} | Failed#:{0}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // testResults.RecordPassingTest is building correct string to display nameOfTest
        static void Test7()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            var nameOfTest = "TEST#";
            testResults.RecordPassingTest(nameOfTest, sw);
            string expected = $"Passed:{nameOfTest}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // testResult.RecordPassingTest is incrementing passed test count by 1 each time it is called (passedCount)
        static void CallPassedTestTwice()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            testResults.RecordPassingTest("random string", System.IO.TextWriter.Null);
            testResults.RecordPassingTest("random string", System.IO.TextWriter.Null);
            testResults.Summarize(sw);
            string expected = $"Passed#:{2} | Failed#:{0}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // testResult.RecordFailingTest is incrementing failed test count by 1 (failedCount)
        static void CallRecordFailingTest()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            testResults.RecordFailingTest("random string", System.IO.StringWriter.Null, new System.Exception());
            testResults.Summarize(sw);
            string expected = $"Passed#:{0} | Failed#:{1}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // testResult.RecordFailingTest is incrementing failed test count by 1 each time it is called (failedCount)
        static void CallRecordFailingTwice()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            testResults.RecordFailingTest("random string", System.IO.StringWriter.Null, new System.Exception());
            testResults.RecordFailingTest("random string", System.IO.StringWriter.Null, new System.Exception());
            testResults.Summarize(sw);
            string expected = $"Passed#:{0} | Failed#:{2}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // testResults.RecordPassingTest is building correct string to display nameOfTest
        static void CallRecordFailingTestName()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            string nameOfTest = "Test#";
            var e = new System.Exception("This is the exception that was thrown");
            testResults.RecordFailingTest(nameOfTest, sw, e);
            string expected = $"Failed:{nameOfTest} - {e.ToString()}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // testResults.RecordFailingTest is building correct string to display nameOfTest and exception
        static void CallRecordFailingTestToTestException()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            string nameOfTest = "Test#";
            var e = new System.Exception("This is the exception that was thrown");
            testResults.RecordFailingTest(nameOfTest, sw, e);
            string expected = $"Failed:{nameOfTest} - {e.ToString()}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        // The following tests (relating to calling ExecuteTests) were used for discovery and are not needed to be called to test production
        static void CallExecuteTestsToTestSummary()
        {
            Action[] tests = { };

            System.IO.StringWriter sw = new System.IO.StringWriter();
            ExecuteTests(tests, sw);
            var testResults = new TestResults();
            string expected = $"Passed#:{0} | Failed#:{0}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }

        }

        static void CallExecuteTestToTestPassedCount()
        {
            static void PassingTest()
            {

            }
            Action[] tests = { PassingTest };

            System.IO.StringWriter sw = new System.IO.StringWriter();
            ExecuteTests(tests, sw);
            string expected = "";
            foreach (Action test in tests)
            {
                expected += $"Passed:{test.Method.Name}\n";
            }
            expected += $"Passed#:{tests.Length} | Failed#:{0}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
            }
        }

        static void CallExecuteTestToTestFailedCount()
        {
            Exception e = new System.Exception("This Test Failed!");
            void FailingTest()
            {
                throw e;
            }
            Action[] tests = { FailingTest };

            System.IO.StringWriter sw = new System.IO.StringWriter();
            ExecuteTests(tests, sw);
            string expected = "";
            foreach (Action test in tests)
            {
                expected += $"Failed:{test.Method.Name} - {e.ToString()}\n";
            }
            expected += $"Passed#:{0} | Failed#:{1}\n";
            if (string.Equals(expected, sw.ToString()))
            {

            }
            else
            {
                throw new System.Exception($"Strings did NOT match\n Expected: \n'{expected}'\n Actual: \n'{sw.ToString()}'");
            }
        }
    }
}

// Result Summarizer
class TestResults
{
    int passedCount = 0;
    int failedCount = 0;
    public void Summarize(System.IO.TextWriter writer)
    {
        writer.WriteLine($"Passed#:{passedCount} | Failed#:{failedCount}");
    }
    public void RecordPassingTest(string testName, System.IO.TextWriter writer)
    {
        writer.WriteLine($"Passed:{testName}");
        passedCount++;
    }

    public void RecordFailingTest(string testName, System.IO.TextWriter writer, System.Exception e)
    {
        writer.WriteLine($"Failed:{testName} - {e.ToString()}");
        failedCount++;
    }
}





