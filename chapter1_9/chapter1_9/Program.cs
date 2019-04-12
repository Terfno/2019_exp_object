using System;

namespace chapter1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("値1(整数)を入力してください");
            string value1 = Console.ReadLine();
            if (value1 == "e")
            {
                Environment.Exit(0);

            }
            int v1 = int.Parse(value1);

            Console.WriteLine("演算子(+,-,*,/)を入力してください");
            string cal = Console.ReadLine();
            if (value1 == "e")
            {
                Environment.Exit(0);
            }

            Console.WriteLine("値2(整数)を入力してください");
            string value2 = Console.ReadLine();
            if (value1 == "e")
            {
                Environment.Exit(0);
            }
            int v2 = int.Parse(value2);

            Console.WriteLine("答えは…");

            for(; ; )
            {
                switch (cal)
                {
                    case "+":
                        Console.WriteLine(v1 + v2);
                        break;
                    case "-":
                        Console.WriteLine(v1 - v2);
                        break;
                    case "*":
                        Console.WriteLine(v1 * v2);
                        break;
                    case "/":
                        Console.WriteLine(v1 / v2);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                Console.WriteLine("値1(整数)を入力してください");
                value1 = Console.ReadLine();
                if (value1 == "e")
                {
                    Environment.Exit(0);
                }
                v1 = int.Parse(value1);

                Console.WriteLine("演算子(+,-,*,/)を入力してください");
                cal = Console.ReadLine();
                if (value1 == "e")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine("値2(整数)を入力してください");
                value2 = Console.ReadLine();
                if (value1 == "e")
                {
                    Environment.Exit(0);
                }
                v2 = int.Parse(value2);

                Console.WriteLine("答えは…");

            }
        }
    }
}
