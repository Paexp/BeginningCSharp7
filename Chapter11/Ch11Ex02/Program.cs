using Ch11Ex02;

Animals animalCollection = new Animals();
animalCollection.Add(new Cow("Donna"));
animalCollection.Add(new Chicken("Mary"));
foreach (Animal animal in animalCollection)
{
    animal.Feed();
}
Console.ReadKey();