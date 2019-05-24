using System;

namespace chapter6_1
{
    class Hello
    {
        public Hello()
        {
            Console.WriteLine("こんにちは");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("インスタンスの作成前");
            Hello echo = new Hello();
            Console.WriteLine("インスタンスの作成後");
            Console.ReadKey();
        }
    }
}
