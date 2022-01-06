using static System.Console;

namespace Ch07Ex02
{
    class Program
    {
        static string[] eTypes = { "none", "simple", "index", "nested index", "filter" };

        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    WriteLine("Main() try block reached.");        // Line 15
                    WriteLine($"ThrowException(\"{eType}\") called.");
                    ThrowException(eType);
                    WriteLine("Main() try block continues.");      // Line 18
                }
                catch (System.IndexOutOfRangeException e) when (eType == "filter")
                {
                    BackgroundColor = ConsoleColor.Red;
                    WriteLine("Main() FILTERED System.IndexOutOfRangeException" +
                              $"catch block reached. Message:\n\"{e.Message}\"");
                    ResetColor();
                }
                catch (System.IndexOutOfRangeException e)                 // Line 27
                {
                    WriteLine("Main() System.IndexOutOfRangeException catch " +
                              $"block reached. Message:\n\"{e.Message}\"");
                }
                catch                                                     // Line 32
                {
                    WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    WriteLine("Main() finally block reached.");
                }
                WriteLine();
            }
            ReadKey();
        }
        static void ThrowException(string exceptionType)
        {
            WriteLine($"ThrowException(\"{exceptionType}\") reached.");
            switch (exceptionType)
            {
                case "none":
                    WriteLine("Not throwing an exception.");
                    break;                                               // Line 51
                case "simple":
                    WriteLine("Throwing System.Exception.");
                    throw new System.Exception();                      // Line 54
                case "index":
                    WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[5] = "error";                                 // Line 57
                    break;
                case "nested index":
                    try                                                  // Line 60
                    {
                        WriteLine("ThrowException(\"nested index\") " +
                                          "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 65
                    }
                    catch                                                // Line 67
                    {
                        WriteLine("ThrowException(\"nested index\") general"
                                          + " catch block reached.");
                        throw;
                    }
                    finally
                    {
                        WriteLine("ThrowException(\"nested index\") finally"
                                          + " block reached.");
                    }
                    break;
                case "filter":
                    try                                                  // Line 80
                    {
                        WriteLine("ThrowException(\"filter\") " +
                                          "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 85
                    }
                    catch                                                // Line 87
                    {
                        WriteLine("ThrowException(\"filter\") general"
                                          + " catch block reached.");
                        throw;
                    }
                    break;
            }
        }
    }
}