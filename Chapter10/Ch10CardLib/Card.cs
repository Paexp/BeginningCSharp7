using System;
using System.Collections.Generic;
using System.Linq;
namespace Ch10CardLib
{
    public class Card
    {
        public readonly Rank rank;
        public readonly Suit suit;

        private Card() {}

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public override string ToString() => "The " + rank + " of " + suit + "s";
    }
}