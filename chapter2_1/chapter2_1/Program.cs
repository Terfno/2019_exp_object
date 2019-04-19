using System;

namespace chapter2_1
{
    class Program
    {
        static int[] ReverseArray(int[] a, int stopIndex)
        {
            int[] revArray = new int[stopIndex];
            int i = a.Length - 1;
            for (int j = 0; j < stopIndex; j++)
            {
                revArray[j] = a[i];
                i--;
            }
            return revArray;
        }

        static void PrintIntArray(int[] a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            int[] a = new int[10] { 1, 3, 10, 4, 6, 5, 2, 8, 9, 7 };

            int[] revA = ReverseArray(a, 5);
            PrintIntArray(revA);
            Console.ReadKey();
        }
    }
}
