using System;

namespace multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] table = new int[10,10];
            for (int i = 1; i <= 10; i++){
                for (int j = 1; j <= 10; j++){
                    table [i - 1, j - 1] = (i + 1) * (j + 1);
                    }
            }
            Console.WriteLine(table);
        }
    }
}
