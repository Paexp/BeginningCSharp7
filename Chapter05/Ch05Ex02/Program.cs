using static System.Console;

namespace Ch05Ex02
{
    enum Orientation : byte
    {
        north = 1,
        south = 2,
        east = 3,
        west = 4,
    }

    class Program
    {
        static void Main(string[] args)
        {
            byte directionByte;
            string directionString;
            Orientation myDirection = Orientation.north;
            WriteLine($"myDirection = {myDirection}");

            directionByte = (byte)myDirection;
            directionString = Convert.ToString(myDirection);
            WriteLine($"byte equivalent = {directionByte}");
            WriteLine($"string equivalent = {directionString}");
            ReadKey();
        }
    }
}
