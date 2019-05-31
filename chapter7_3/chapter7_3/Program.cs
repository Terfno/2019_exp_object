using System;

namespace chapter7_3
{
    public abstract class Food
    {
        private int spentDay;
        private int expiredDay;

        public Food(int expiredDay, int firstDay)
        {
            this.Init(expiredDay, firstDay);
        }

        private void Init(int expiredDay, int firstDay)
        {
            this.expiredDay = expiredDay;
            this.spentDay = firstDay;
        }

        public int GetDay()
        {
            return this.spentDay;
        }

        public void SpentDay()
        {
            this.spentDay = this.spentDay + 1;
        }

        public abstract int GetMaturity();
        public bool IsEatable()
        {
            return this.expiredDay >= this.spentDay;
        }
    }

    class Apple: Food
    {
        public static int EXPIREDDAY = 50;
        public Apple(int firstDay):base(EXPIREDDAY, firstDay)
        {

        }

        public override int GetMaturity()
        {
            return (int)(10.0 / (1.0 + (10.0 / 0.1 - 1.0) * Math.Exp(0.2 * (double)(-this.GetDay()))));
        }
    }

    public class Orange: Food
    {
        public static int EXPIREDDAY = 14;
        public Orange(int firstDay):base(EXPIREDDAY, firstDay)
        {

        }
        public override int GetMaturity()
        {
            return (int)(10.0 / (1.0 + (10.0 / 0.1 - 1.0) * Math.Exp(0.6 * (double)(-this.GetDay()))));
        }
    }

    public class Terminal
    {
        private static void CheckFood(Food f)
        {
            Console.WriteLine("熟成度合いは{0}です。", f.GetMaturity());
            if (f.IsEatable())
            {
                Console.WriteLine("まだ食べられます。");
            }
            else
            {
                Console.WriteLine("もう食べられません。");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("食品の状態チェッカーです。");
            Console.WriteLine("調べたい食品がオレンジなら1を、りんごなら2を入力してください。");

            string checkFoodInput = Console.ReadLine();
            Console.WriteLine("食品を購入してから何日経過したか入力してください。");
            string checkDateInput = Console.ReadLine();
            int checkDate = Convert.ToInt32(checkDateInput);

            Console.WriteLine("{0} {1}", checkFoodInput, checkDate);

            if(checkFoodInput[0] == '1')
            {
                Console.WriteLine("オレンジを選択しました。");
                Orange o = new Orange(checkDate);
                CheckFood(o);
            }
            else if (checkFoodInput[0] == '2')
            {
                Console.WriteLine("りんごを選択しました。");
                Apple a = new Apple(checkDate);
                CheckFood(a);
            }
            else
            {
                Console.WriteLine("不正な入力です。");
            }

            Console.ReadKey();
        }
    }
}
