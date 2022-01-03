using static System.Console;

const string myName = "paexp";
const string niceName = "andrea";
const string sillyName = "pang";
string name;
WriteLine("What is your name?");
name = ReadLine();
switch (name.ToLower())
{
    case myName:
        WriteLine("Your have the same name as me!");
        break;
    case niceName:
        WriteLine("My, what a nice name your have!");
        break;
    case sillyName:
        WriteLine("That's a very silly name.");
        break;
}
WriteLine($"Hello {name}!");
ReadKey();