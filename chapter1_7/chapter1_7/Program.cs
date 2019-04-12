using System;

namespace chapter1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int j = 0; j < 5; j++)
            {
                for(int i = 0; i <= j; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
