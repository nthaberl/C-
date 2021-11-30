using System;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // RandomArray();
            TossMultipleCoins();
        }

        public static int[] RandomArray() {
            int [] randomArray = new int[10];
            int min = 5;
            int max = 25;

            Random randNum = new Random();
            for (int i = 0; i <= 10; i ++){
                randomArray[i] = randNum(min, max);
            }
            Console.WriteLine(randomArray);
            return randomArray;
        }

        public static double TossMultipleCoins(){
            Console.WriteLine("Tossing a Coin!");

        }
    }
}
