using Ch11CardLib;
using static System.Console;

Deck myDeck = new Deck();
myDeck.Shuffle();
for (int i = 0; i < 52; i++)
{
    Card tempCard = myDeck.GetCard(i);
    Write(tempCard.ToString());
    if (i != 51)
        Write(", ");
    else
        WriteLine();
}
ReadKey();