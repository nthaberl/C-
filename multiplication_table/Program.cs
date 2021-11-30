using System;
using System.Text;

namespace multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            //Attempt
            // int [,] table = new int[10,10];
            // for (int i = 1; i <= 10; i++){
            //     for (int j = 1; j <= 10; j++){
            //         table [i, j] = (i + 1) * (j + 1);
            //         }
            // }
            // return table;

            //Solution
            var table = BuildTable(10);
            RenderTable(table);
        }
        public static int[,] BuildTable(int size)
        {
            int[,] table = new int[size,size];
            for(var row = 0; row < size; row++)
                for(var col = 0; col < size; col++)
                    table[row,col] = (row + 1) * (col + 1);
            return table;
        }
        public static void RenderTable(int[,] multiArray)
        {
            // StringBuilder class good for mutating strings
            StringBuilder sb = new StringBuilder();

            // gets length of specified dimention of multi array
            int size = multiArray.GetLength(0);
            
            for(var row = 0; row < size; row++)
            {
                sb.Append("[");
                for(var col = 0; col < size; col++)
                {
                    sb.Append($"{multiArray[row,col]}, ");
                }
                sb.Append("]\n");
            }
            Console.WriteLine(sb);
        }

        //Solution

    }
}
