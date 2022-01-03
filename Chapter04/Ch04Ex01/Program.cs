using static System.Console;
using static System.Convert;

WriteLine("Enter an integer:");
int myInt = ToInt32(ReadLine());
bool isLessThan10 = myInt < 10;
bool isBetween0And5 = (0 <= myInt) && (myInt <= 5);
WriteLine($"Integer less than 10? {isLessThan10}");
WriteLine($"Integer between 0 and 5? {isBetween0And5}");
WriteLine($"Exactly one of the above is true? " +
    $"{isLessThan10 ^ isBetween0And5}");
ReadKey();