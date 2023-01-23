/*
1. Write a failing test(As close to zero changes to code)
2. Make the test pass(DO NOT CHANGE TEST!)
3. Change the code (without breaking the test) aka refactoring
*/


ExecuteTest(Test1);
ExecuteTest(Test3);
// TEST Executor
static void ExecuteTest(Action test)
{
    try
    {
        test();
    }
    catch (Exception e2)
    {
        if (e2 is InvalidTimeZoneException)
        {

        }
        else
        {
            throw new System.Exception($"unexpected exception type {e2.GetType()}");
        }
    }
}


static void Test1()
{
    try
    {
        throw new DivideByZeroException("Divide by zero");
    }
    catch (DivideByZeroException e)
    {

    }
}

static void Test3()
{
    try
    {
        throw new System.InvalidTimeZoneException("This exception should fail");
    }
    catch (DivideByZeroException e)
    {

    }
}









