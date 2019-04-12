using System;

namespace chapter1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] dlist = new double[] { 3.14, 1592, 6534 };

            foreach(double d in dlist)
            {
                Console.WriteLine(d);
            }
        }
    }
}
