using static System.Console;
using static System.Convert;

namespace Ch05Ex03;

enum Orientation : byte
{
    north = 1,
    south = 2,
    east = 3,
    west = 4
}

internal struct Route
{
    public Orientation direction;
    public double distance;
}

class Program
{
    static void Main(string[] args)
    {
        Route myRoute;
        double myDistance;
        WriteLine("1) North\n2) South\n3) East\n4) West");
        int myDirection;
        do
        {
            WriteLine("Select a direction:");
            myDirection = ToInt32(ReadLine());
        }
        while (myDirection < 1 || myDirection > 4);
        WriteLine("Input a distance:");
        myDistance = ToDouble(ReadLine());
        myRoute.direction = (Orientation)myDirection;
        myRoute.distance = myDistance;
        WriteLine($"myRoute specifies a direction of {myRoute.direction} " + $"and a distance of {myRoute.distance}");
        ReadKey();
    }
}
