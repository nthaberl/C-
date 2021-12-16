using System;
using System.Collections.Generic;

namespace deck_of_Cards
{
    class Player
    {
        public string Name;
        public List<Card> Hand = new List<Card>();

        public Player(string name)
        {
            Name = name;
            // Hand = new List<Card>();
        }

        public Card Draw(Deck card)
        {
            Card drawcard = card.deal();
            Hand.Add(drawcard);
            Console.WriteLine($"Drew a {drawcard.StringVal} of {drawcard.Suit}");
            return drawcard;
        }

        public Card Discard(int index)
        {
            if (Hand.Count > index)
            {
                Card discarded = Hand[index];
                Hand.Remove(discarded);
                Console.WriteLine($"{discarded.StringVal} of {discarded.Suit} was discarded. There are only {Hand.Count} cards left in hand.");
                return discarded;
            }
            else
            {
                return null;
            }
        }
    }
}