using static System.Console;

static int MaxValue(int[] intArray)
{
    int maxVal = intArray[0];
    for (int i = 1; i < intArray.Length; i++)
    {
        if( intArray[i] > maxVal)
        {
            maxVal = intArray[i];
        }
    }
    return maxVal; 
}

int[] myArray = { 1, 8, 3, 6, 2, 5, 9, 3, 0, 2 };
int maxVal = MaxValue(myArray);
WriteLine($"The maximum value in myArray is {maxVal}.");
ReadKey();