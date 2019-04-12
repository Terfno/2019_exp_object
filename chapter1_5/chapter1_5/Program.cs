using System;

namespace chapter1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            for (int i = 0; i < 6; i++)
            {
                input = Console.ReadLine();

                // 図1.14
                if (input.Length >= 10)
                {
                    Console.WriteLine("10文字以上");
                }
                else if (input.Length < 5)
                {
                    Console.WriteLine("5文字未満");
                }
                else
                {
                    Console.WriteLine("5文字以上10文字未満");
                }

                // 図1.15
                switch (input.Length)
                {
                    case 5:
                        Console.WriteLine("5文字ちょうど");
                        break;
                    case 10:
                        Console.WriteLine("10文字ちょうど");
                        break;
                    default:
                        Console.WriteLine("5文字でも10文字でもない");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
