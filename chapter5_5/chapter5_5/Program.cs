using System;
using System.Collections.Generic;

namespace chapter5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sampleList = new List<int>();

            sampleList.Add(3);
            sampleList.Add(1);
            sampleList.Add(4);
            sampleList.Add(1);
            sampleList.Add(5);

            for(int i = 0; i < sampleList.Count; i++)
            {
                Console.WriteLine(sampleList[i]);
            }
        }
    }
}
