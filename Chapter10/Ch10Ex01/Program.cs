using Ch10Ex01;
using static System.Console;

WriteLine("Creating object myObject ...");
MyClass myObj = new MyClass("My Object");
WriteLine("MyObj created.");
for (int i = -1; i <= 0; i++)
{
    try
    {
        WriteLine($"\nAttempting to assign {i} to myObj.Val...");
        myObj.Val = i;
        WriteLine($"Value {myObj.Val} assigned to myObj.Val.");
    }
    catch (Exception e)
    {
        WriteLine($"Exception {e.GetType().FullName} thrown.");
        WriteLine($"Message:\n\"{e.Message}\"");
    }
}
WriteLine("\nOutputting myObj.ToString()...");
WriteLine(myObj.ToString());
WriteLine("myObj.ToString() Output.");
WriteLine("\nmyDoubledIntProp = 5...");
WriteLine($"Getting myDoubledIntProp of 5 is {myObj.myDoubledIntProp}");
ReadKey();