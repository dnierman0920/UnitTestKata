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









