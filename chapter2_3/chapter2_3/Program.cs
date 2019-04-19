using System;

namespace chapter2_3
{
    class Program
    {
        static double[] CreateXAxis(int n, double min, double max)
        {
            double tick = (max - min) / n;

            double[] axisData = new double[n];
            int tick_cnt = 0;

            for (double x = min; tick_cnt < n; x = Math.Truncate((x + tick) * 100.0) / 100.0)
            {
                axisData[tick_cnt] = x;
                tick_cnt++;
            }
            return axisData;
        }

        private static void PrintDoubleArray(double[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                Console.Write(d[i] + " ");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            double[] d = CreateXAxis(20, 1.0, 10.0);
            PrintDoubleArray(d);

            Console.ReadKey();
        }
    }
}
