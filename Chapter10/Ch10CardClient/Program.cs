using static System.Console;
using Ch10CardLib;

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