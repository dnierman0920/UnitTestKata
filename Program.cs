/*
1. Write a failing test(As close to zero changes to code)
2. Make the test pass(DO NOT CHANGE TEST!)
3. Change the code (without breaking the test) aka refactoring
*/


ExecuteTest(Temp);
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


// TEST 1 (Testing throw sys method)
try
{
    Test1();
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


// TEST 3 (Testing sys method catch)
// This try/catch is the production code
try
{
    // This try/catch is the test
    Test3();
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

static void Temp()
{
    throw new System.ArgumentException("This is an argument exception");
}










