using System;

namespace chapter8_3
{
    public interface Sorting
    {
        // int型の配列を返すメソッド
        int[] Sort(int[] array);
    }

    // バブルソート
    public class Bubble : Sorting
    {
        public int[] Sort(int[] array)
        {
            Console.WriteLine("バブルソートをします。");
            int[] nums = array;
            int start, end, tmp;

            for (start = 1; start < nums.Length; start++)
            {
                for (end = nums.Length - 1; end >= start; end--)
                {
                    if (nums[end - 1] > nums[end])
                    {
                        tmp = nums[end - 1];
                        nums[end - 1] = nums[end];
                        nums[end] = tmp;
                    }
                }
            }

            return nums;
        }
    }

    // 選択ソート
    public class Selection : Sorting
    {
        public int[] Sort(int[] array)
        {
            Console.WriteLine("選択ソートをします。");
            int[] nums = array;
            int n = nums.Length;
            int minj = 0;

            for (int i = 0; i < n; i++)
            {
                minj = i;
                for (int j = minj; j < n; j++)
                {
                    if (nums[j] < nums[minj])
                    {
                        minj = j;
                    }
                }
                int tmp = nums[i];
                nums[i] = nums[minj];
                nums[minj] = tmp;
            }

            return nums;
        }
    }

    // ソートするアルゴリズムのコンテクスト
    public class Algo
    {
        private static Sorting _rithm;

        public int[] Sort(string type, int[] array)
        {
            if (type == "1")
            {
                _rithm = new Bubble();
            }
            else if(type == "2")
            {
                _rithm = new Selection();
            }
            else
            {
                Console.WriteLine("不正な入力です。ソートしませんでした。");
                return array;
            }

            return _rithm.Sort(array);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 11, 5, 9, 100, 200 };
            Console.WriteLine("バブルソートなら1を、選択ソートなら2を入力してください。");
            string type = Console.ReadLine();

            Algo _algorithm = new Algo();
            Console.WriteLine("result:");

            int[] result = _algorithm.Sort(type, array);

            for (int i=0;i<result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
