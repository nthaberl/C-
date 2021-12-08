using System;
using System.Collections.Generic;

namespace deck_of_Cards
{
    class Deck
    { 
            //attribute
            public List<Card> Cards;
            public Deck()
            {
            Cards = new List<Card>();

            // string[] stringVal = new string[]{"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            // string[] suits = new string[]{"Hearts", "Spades", "Diamonds", "Clubs"};
            // for (int i = 0; i < suits.Length; i++)
            // {
            //     for (int j = 0; j < stringVal.Length; j++)
            //     {
            //     Cards.Add(new Card(suits[i], stringVal[j], j+1));
            //     System.Console.WriteLine($"{stringVal[j]} of {suits[i]}");
            //     }
            // }
            this.Build();
        }


        //method
        public Card deal()
        {
            Card card = Cards[0];
            System.Console.WriteLine($"Dealt {card.StringVal} of {card.Suit}");
            Cards.RemoveAt(0);
            return card;
        }

public static List<Card> Shuffle(List<Card> list)
        {
            Random random = new Random();
            {for (int i = list.Count - 1; i >= 1; i--)
            {
                int index = random.Next(0, i + 1);
                Card temp = list[index];
                list[index] = list [i];
                list[i] = temp;
            }
        }
        return list;
    }
        public void Build()
        //allows us to rebuild the deck on queue
        {
            Cards.Clear();
            string[] stringVal = new string[]{"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suits = new string[]{"Hearts", "Spades", "Diamonds", "Clubs"};
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < stringVal.Length; j++)
                {
                Cards.Add(new Card(suits[i], stringVal[j], j+1));
                // System.Console.WriteLine($"Fresh Deck {stringVal[j]} of {suits[i]}");
                }
            } 
            Cards = Shuffle(Cards);
        }
    }
}
