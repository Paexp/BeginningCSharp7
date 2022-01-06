using static System.Console;

WriteLine($"{args.Length} command line arguments were specified:");
foreach (string arg in args)
    WriteLine(arg);
ReadKey();