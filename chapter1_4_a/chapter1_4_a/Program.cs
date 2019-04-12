using System;

namespace chapter1_4_a
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[3];
            int[] b = a;
            Console.WriteLine(b[2]);

            a[2] = 42;
            Console.WriteLine(b[2]);
        }
    }
}
