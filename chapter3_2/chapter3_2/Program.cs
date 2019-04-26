using System;

namespace chapter3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 9;
            for(int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i <= j)
                    {
                        if (i > j / 2)
                        {
                            Console.Write(j - i);
                        }
                        else
                        {
                            Console.Write(i);
                        }
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            return;
        }
    }
}
