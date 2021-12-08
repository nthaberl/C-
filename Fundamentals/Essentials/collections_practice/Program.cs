using System;
using System.Collections.Generic;

namespace collections_practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create an array to hold integer values 0 through 9
            int[] arr = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            //OR
            // int [] numbers = new int[10];
            //for (var i = 0; i < numbers.Length; i++)
            //numbers [i] = i;

            // /Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};

            //Create an array of length 10 that alternates between true and false values, starting with true
            // bool[] array = new bool[] {true, true, false, false, true, true, false, true, false, true};
            bool[] booleans = new bool[10];
            for (var i = 0; i < booleans.Length; i++)
                booleans[i] = i%2 == 0;


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
            //OR flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            //Create a dictionary that will store both string keys as well as string values
            Dictionary<string,string> iceCream = new Dictionary<string,string>();
            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
            foreach (var name in names)
                iceCream.Add(name, null);
                // For each name key, select a random flavor from the flavor list above and store it as the value
                Random rand = new Random();
                foreach(var name in names)
                iceCream[name] = (flavors[rand.Next(flavors.Count)]);
                // Loop through the dictionary and print out each user's name and their associated ice cream flavor
                foreach(var entry in iceCream)
                Console.WriteLine($"Their name is:" + entry.Key + " and they like:" + entry.Value);
        }
    }
}
