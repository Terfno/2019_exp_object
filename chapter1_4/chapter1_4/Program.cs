using System;

namespace chapter1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s4 = "しぶいおちゃ";

            Console.WriteLine(s4);

            s4 = s4.Remove(1, 1);
            s4 = s4.Insert(1, "ろ");
            s4 = s4.Remove(5, 1);
            s4 = s4.Insert(5, "ば");

            Console.WriteLine(s4);
            Console.ReadKey();
        }
    }
}
