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
// TEST 2 (Testing try sys method)
try
{
    try
    {
        throw new System.Exception("This exception should fail");
        throw new DivideByZeroException("Divide by zero");
    }
    catch (DivideByZeroException e)
    {

    }
}
catch
{

}

// TEST 3
try
{
    try
    {
        throw new System.InvalidTimeZoneException("This exception should fail");
        throw new DivideByZeroException("Divide by zero");
    }
    catch (DivideByZeroException e)
    {

    }
}
catch (Exception e2)
{
    if (e2 is InvalidCastException)
    {

    }
    else
    {
        throw new System.Exception($"unexpected exception type {e2.GetType()}");
    }
}







