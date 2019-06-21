using System;

namespace chapter8_2
{
    public abstract class FoodFactory
    {
        public abstract Food CreateFood(int checkDate);
    }

    public class CompanyA: FoodFactory
    {
        public override Food CreateFood(int checkDate)
        {
            Console.WriteLine("オレンジを選択しました。");
            return new Orange(checkDate);
        }
    }

    public class CompanyB: FoodFactory
    {
        public override Food CreateFood(int checkDate)
        {
            Console.WriteLine("りんごを背なt区しました。");
            return new Apple(checkDate);
        }
    }

    public abstract class Food
    {
        private double maturity;
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

        public void SpendDay()
        {
            this.spentDay = this.spentDay + 1;
        }

        public abstract int GetMaturity();

        public bool IsEatabe()
        {
            return this.expiredDay >= this.spentDay;
        }
    }

    class Apple: Food
    {
        public static int EXPIREDDAY = 50;
        public Apple(int firstDay) : base(EXPIREDDAY, firstDay) { }
        public override int GetMaturity()
        {
            return (int)(10.0/(1.0+(10.0/0.1-1.0)*Math.Exp(0.2*(double)(-this.GetDay()))));
        }
    }

    public class Orange: Food
    {
        public static int EXPIREDDAY = 14;
        public Orange(int firstDay) : base(EXPIREDDAY, firstDay) { }
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
            if (f.IsEatabe())
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

            FoodFactory factory;

            if (checkFoodInput[0] == '1')
            {
                factory = new CompanyA();
            }
            else if (checkFoodInput[0] == '2')
            {
                factory = new CompanyB();
            }
            else
            {
                Console.WriteLine("不正な入力です。");
                Console.ReadKey();
                return;
            }

            CheckFood(factory.CreateFood(checkDate));
            Console.ReadKey();
        }
    }
}
