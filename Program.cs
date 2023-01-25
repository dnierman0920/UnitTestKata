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
        Action[] tests = { Test1, Test3, Test4, Test5, Test6, Test7, CallPassedTestTwice, CallRecordFailingTest };
        ExecuteTests(tests);

        //  Executor
        static void ExecuteTests(Action[] tests)
        {
            foreach (System.Action test in tests)
            {
                try
                {
                    test();
                    // test.Method.Name;
                }
                catch (Exception e2)
                {
                    // TestResults.RecordFailingTest
                    throw new System.Exception($"unexpected exception type {e2.GetType()}, {e2.ToString()}");
                }
            }

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

        // testResult.RecordFailingTest is incrementing passed test count by 1 (passedCount)
        static void CallRecordFailingTest()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var testResults = new TestResults();
            testResults.RecordFailingTest();
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

    public void RecordFailingTest()
    {
        failedCount++;
    }
}
// bonus points print out the error message




