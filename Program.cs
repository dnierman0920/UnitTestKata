/*
1. Write a failing test(As close to zero changes to code)
2. Make the test pass(DO NOT CHANGE TEST!)
3. Change the code (without breaking the test) aka refactoring
*/


// TEST 1 (Testing throw sys method)
try
{
    throw new DivideByZeroException("Divide by zero");
}
catch (DivideByZeroException e)
{

}

// TEST 3 (Testing sys method catch)
// This try/catch is the production code
try
{
    // This try/catch is the test
    try
    {
        throw new System.InvalidTimeZoneException("This exception should fail");
    }
    catch (DivideByZeroException e)
    {

    }
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







