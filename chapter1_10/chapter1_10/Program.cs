using System;

namespace chapter1_10
{
    class Program
    {
        static void Print9x9()
        {
            for(int j = 1; j <= 9; j++)
            {
                for(int i = 1; i <= 9; i++)
                {
                    Console.Write("{0} ", j * i);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Print9x9();
        }
    }
}
