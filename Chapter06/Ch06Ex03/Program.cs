using static System.Console;

static int SumVals(params int[] vals)
{
    int sum = 0;
    foreach (int val in vals)
    {
        sum += val;
    }
    return sum;
}

int sum = SumVals(1, 5, 2, 9, 8);
WriteLine($"Summed Values = {sum}");
ReadKey();