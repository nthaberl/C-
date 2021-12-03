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

        // public static int[] RandomArray() {
        //     int [] randomArray = new int[10];
        //     // int min = 5;
        //     // int max = 26;
        //     // int sum = 0;
        //     Random randNum = new Random();
        //     for (int i = 0; i <= randomArray; i ++){
        //         randomArray[i] = randNum(min, max);
        //     }
        //     Console.WriteLine(randomArray);
        //     return randomArray;
        // }

        public static double TossMultipleCoins(int num){
            Console.WriteLine("Tossing a Coin!");
            int count = 0;
            for (int i = 1; i < num; i++)
            {
                TossCoin();
                if (TossCoin() == "Heads")
                {
                    count++;
                }
            }
            return count/num;
        }
    }
}
