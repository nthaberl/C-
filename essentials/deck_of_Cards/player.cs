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
            Hand = new List<Card>();
        }

        
    }
}