using System;

namespace chapter1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 図1.5
            int a = 1, b = 2, c = 3, d = 4, e = 5, f = 6;
            Console.WriteLine(a + b);
            Console.WriteLine(b - c);
            Console.WriteLine(c * d);
            Console.WriteLine(d / e);
            Console.WriteLine(e % f);

            // 図1.6
            double de = 5.0;
            Console.WriteLine(d / (int)de);
            Console.WriteLine(d / de);
            //Console.WriteLine((bool)42);

            Console.WriteLine("Hello World!" + "Takahito Sueda");
            Console.ReadKey();
        }
    }
}
