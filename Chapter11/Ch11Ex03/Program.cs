using Ch11Ex03;

Primes primesFrom2To1000 = new Primes(2, 1000);
foreach ( long i in primesFrom2To1000 )
    Console.Write($"{i} ");
Console.ReadKey();