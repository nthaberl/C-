using System;
using System.Collections.Generic;

namespace deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            // deck.deal();
            Player nat = new Player("Nat");
            deck.Build();
            nat.Draw(deck);
            nat.Draw(deck);
            nat.Draw(deck);
            nat.Draw(deck);
            nat.Draw(deck);
            nat.Discard(2);
        }
    }

}