using System;

namespace chapter5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] terms = input.Split(' ');
            int[] nums = new int[terms.Length];

            for (int i = 0; i < terms.Length; i++)
            {
                nums[i] = Convert.ToInt32(terms[i]);
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
