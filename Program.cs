/*
1. Write a failing test(As close to zero changes to code)
2. Make the test pass(DO NOT CHANGE TEST!)
3. Change the code (without breaking the test) aka refactoring
*/


Action[] tests = { Test1, Test3, Test4 };
ExecuteTest(tests);
// TEST Executor
static void ExecuteTest(Action[] tests)
{
    foreach (Action test in tests)
    {
        try
        {
            test();
        }
        catch (InvalidTimeZoneException)
        {

        }
        catch (ArgumentException)
        {

        }
        catch (DivideByZeroException)
        {

        }
        catch (Exception e2)
        {
            throw new System.Exception($"unexpected exception type {e2.GetType()}");

        }
    }

}


static void Test1()
{

    throw new DivideByZeroException("Divide by zero");

}

static void Test3()
{
    throw new System.InvalidTimeZoneException("This exception should fail");
}

// 
static void Test4()
{
    throw new System.ArgumentException("This exception should fail");

}









