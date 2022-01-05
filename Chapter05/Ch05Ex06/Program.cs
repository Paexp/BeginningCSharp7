using static System.Console;

string myString = "This is a test.";
char[] separator = { ' ' };
string[] myWords;
myWords = myString.Split(separator);
foreach (var word in myWords)
{
    WriteLine($"{word}");
}