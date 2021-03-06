using static System.Console;
using static System.Convert;

double balance, interestRate, targetBalance;
WriteLine("What is your current balance?");
balance = ToDouble(ReadLine());
WriteLine("What is your current annual interest rate (in %)?");
interestRate = 1 + ToDouble(ReadLine()) / 100.0;
WriteLine("What balance would you like to have?");
targetBalance = ToDouble(ReadLine());
int totalYears = 0;
if (balance < targetBalance)
{
    do
    {
        balance *= interestRate;
        totalYears++;
    } 
    while (balance < targetBalance);
}
WriteLine($"In {totalYears} year{(totalYears == 1 ? "" : "s")} " +
    $"you'll have a balance of {balance}.");
ReadKey();