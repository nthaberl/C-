using System;
using System.Collections.Generic;

namespace puzzles
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Names();
            // RandomArray();
            // Console.WriteLine(TossCoin());
            Console.WriteLine(TossMultipleCoins(20));
        }

        public static int[] RandomArray() {
            int [] randomArray = new int[10];

            Random randNum = new Random();
            for (int i = 0; i < 10; i ++){
                randomArray[i] = randNum.Next(5, 26);
            }
            int max = randomArray[0];
            int min = randomArray[0];
            int sum = 0;

            for(int i = 0; i < randomArray.Length; i++){
                sum += randomArray[i];
                if (randomArray[i] > max)
                {
                    max = randomArray[i];
                }
                if (randomArray[i] < min)
                {
                    min = randomArray[i];
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", randomArray));
            Console.WriteLine($"Sum:{sum}, Min: {min}, Max: {max}");

            return randomArray;
        }

        public static string TossCoin(){
            Console.WriteLine("Tossing a Coin!");
            Random toss = new Random();
            int result = toss.Next(0,2);
            string coin;
            if (result == 0)
            {
                coin = "Heads";
            }
            else
            {
                coin = "Tails";
            }
            return coin;
        }

        public static double TossMultipleCoins(int num){
            
            int headsCount = 0;
            int tailsCount = 0;

            for (int i = 0; i < num; i++)
            {
                TossCoin();
                if (TossCoin() == "Heads") 
                {
                    headsCount++;
                }
                else{
                    tailsCount++;
                }

            }
            Console.WriteLine($"Heads:{headsCount}, Tails: {tailsCount}, Total tosses {num}");
            double flipRatio = (double)headsCount/(double)num;
            return flipRatio;
        }
        public static List<string> Names()
        {
            List<string> Names = new List<string>()
            {
                "Todd",
                "Tiffany",
                "Charlie",
                "Geneva",
                "Sydney",
            };

            Random random = new Random();
            int i = Names.Count;
            while (i > 1)
            {
                i--; 
                int j = random.Next(i + 1);
                string value = Names[j];
                Names[j] = Names[i];
                Names[i] = value;
            }

            foreach (var name in Names)
            {
                Console.WriteLine(name);
            }
            return Names;
        }

    }
}
