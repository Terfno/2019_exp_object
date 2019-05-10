using System;

namespace chapter4_3
{
    class Program
    {
        static int[,] Rotate(int[,] origin)
        {
            int n = origin.GetLength(0);
            int[,] rotatedArray = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    rotatedArray[i, n - 1 - j] = origin[j, i];
                }
            }

            return rotatedArray;
        }

        static void Print(int[,] array)
        {
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int n = 4;
            int num = 0;

            int[,] origin = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    num++;
                    origin[i, j] = num;
                }
            }

            Print(Rotate(origin));
        }
    }
}
