using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an array to hold integer values 0 through 9
            int[] arr = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            // /Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};

            //Create an array of length 10 that alternates between true and false values, starting with true
            bool[] array = new bool[] {true, true, false, false, true, true, false, true, false, true};


            //Create a list of ice cream flavors that holds at least 5 different flavors
            List<string> flavors = new List<string>();

            flavors.Add("mint chocolate");
            flavors.Add("strawberry cheesecake");
            flavors.Add("Americone Dream");
            flavors.Add("Phish Food");
            flavors.Add("pistachio");

            //Output the length of this list after building it
            Console.WriteLine(flavors.Count);

            //Output the third flavor in the list, then remove this value
            Console.WriteLine(flavors[2]);
            flavors.Remove(flavors[2]);
            Console.WriteLine(flavors.Count);

            //Create a dictionary that will store both string keys as well as string values
            Dictionary<string,string> iceCream = new Dictionary<string,string>();

            foreach (var name in names)
                iceCream.Add(name, null);
                Random rand = new Random();
                foreach(var name in names)
                iceCream[name] = (flavors[rand.Next(flavors.Count)]);
                foreach(var entry in iceCream)
                Console.WriteLine($"Their name is:" + entry.Key + " and they like:" + entry.Value);
        }
    }
}
