using System;

namespace chapter1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("値1(整数)を入力してください");
            string value1 = Console.ReadLine();
            int v1 = int.Parse(value1);

            Console.WriteLine("演算子(+,-,*,/)を入力してください");
            string cal = Console.ReadLine();

            Console.WriteLine("値2(整数)を入力してください");
            string value2 = Console.ReadLine();
            int v2 = int.Parse(value2);

            Console.WriteLine("答えは…");

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

            Console.ReadKey();
        }
    }
}
