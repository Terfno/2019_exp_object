using System;

namespace chapter2_6
{
    class Program
    {
        static void PrintTriangle(int h)
        {
            int center = h / 2;
            for(int j = 0; j < h; j++)
            {
                for (int i = 0; i < h * 2; i++)
                {
                    if (center * 2 == j)
                    {
                        if (i == h*2-1)
                        {
                            break;
                        }
                        Console.Write("* ");
                    }
                    else if (center*2 + j == i || center*2 - j == i)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            PrintTriangle(5);
            Console.ReadKey();
        }
    }
}
