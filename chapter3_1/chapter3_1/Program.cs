using System;

namespace chapter3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int di;
            int p = 0;
            for (int i = 1; i <= 8000; i++)
            {
                di = 0;

                for(int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        di++;
                    }
                }

                if (di == 2)
                {
                    Console.Write(i + " ");
                    p++;
                    if (p == 1000)
                    {
                        break;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
