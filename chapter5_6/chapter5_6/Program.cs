using System;
using System.Collections.Generic;

namespace chapter5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();

            string input = Console.ReadLine();
            string[] terms = input.Split(' ');

            for(int i = 0; i < terms.Length; i++)
            {
                nums.Add(Convert.ToInt32(terms[i]));
            }

            int sum = 0;
            foreach(int n in nums)
            {
                sum += n;
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
