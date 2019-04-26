using System;

namespace chapter3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 10;
            int[,] pascal = new int[h+2, h+2];
            for(int i = 1; i <= h; i++)
            {
                for(int j = 1; j <= h; j++)
                {
                    if (j == 1)
                    {
                        pascal[i, j] = 1;
                    }

                    if (j == i)
                    {
                        pascal[i, j] = 1;
                        break;
                    }
                    else
                    {
                        pascal[i, j] = pascal[i - 1, j - 1] + pascal[i - 1, j];
                    }
                }
            }

            for (int i = 0; i < pascal.GetLength(0); i++)
            {
                for(int j = 0; j < pascal.GetLength(1); j++)
                {
                    if (pascal[i, j] == 0)
                    {
                        continue;
                    }
                    Console.Write(pascal[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
