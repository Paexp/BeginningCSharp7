using static System.Console;
using static System.Convert;

short shortResult, shortVal = 4;
int integerVal = 67;
long longResult;
float floatVal = 10.5f;
double doubleResult, doubleVal = 99.999;
string stringResult, stringVal = "17";
bool boolVal = true;
WriteLine("Variable Conversion Examples\n");
doubleResult = floatVal * shortVal;
WriteLine($"Implicit, -> double: {floatVal} * {shortVal} -> {doubleResult}");
shortResult = (short)floatVal;
WriteLine($"Explicit, -> short: \"{floatVal}\" + \"{shortResult}\" ->  " +
    $"{shortResult}");
stringResult = Convert.ToString(boolVal) + Convert.ToString(doubleVal);
WriteLine($"Explicit, -> short: \"{boolVal}\" + \"{doubleVal}\" ->  " +
    $"{stringResult}");
longResult = integerVal + ToInt64(stringVal);
WriteLine($"Mixed, -> long: {integerVal} + {stringVal} -> {longResult}");
ReadKey();