using System;

namespace chapter6_5
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
            Introduction echo = new Introduction("イチロー");
            Console.WriteLine("インスタンスの作成後");
            Console.ReadKey();
        }
    }

    class Introduction: Hello
    {
        public Introduction(string name) : base()
        {
            Console.WriteLine("私の名前は{0}です。", name);
        }
    }
}
