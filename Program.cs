/*
1. Write a failing test(As close to zero changes to code)
2. Make the test pass(DO NOT CHANGE TEST!)
3. Change the code (without breaking the test) aka refactoring
*/


internal class Program
{
    private static void Main(string[] args)
    {
        Action[] tests = { Test1, Test3, Test4, Test5, Test6, Test7 };
        ExecuteTests(tests);
        // TEST Executor
        static void ExecuteTests(Action[] tests)
        {
            foreach (Action test in tests)
            {
                try
                {
                    test();
                }
                catch (Exception e2)
                {
                    throw new System.Exception($"unexpected exception type {e2.GetType()}, {e2.ToString()}");

                }
            }

        }
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

        // 
        static void Test4()
        {
            static void M()
            {
                throw new System.ArgumentException("This exception should fail");
            }
            Assert<ArgumentException>(M);
        }



        // Test it is printing the right thing
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
    }
    static void Test6()
    {
        System.IO.StringWriter sw = new System.IO.StringWriter();
        var testResults = new TestResults();
        testResults.CountPassedTest(1);
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
    static void Test7()
    {
        System.IO.StringWriter sw = new System.IO.StringWriter();
        var testResults = new TestResults();
        var nameOfTest = "TEST#\n";
        testResults.CountPassedTest(nameOfTest);
        string expected = $"Passed:{nameOfTest}";
        if (string.Equals(expected, sw.ToString()))
        {

        }
        else
        {
            throw new System.Exception($"Strings did NOT match \n'{expected}'\n'{sw.ToString()}'");
        }
    }
}


class TestResults
{
    int passedCount = 0;
    public void Summarize(System.IO.TextWriter writer)
    {
        writer.WriteLine($"Passed#:{passedCount} | Failed#:{0}");
    }
    public void CountPassedTest(int count)
    {
        passedCount = count;
    }
    public void CountPassedTest(string testName)
    {

    }
}




