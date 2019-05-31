using System;

namespace chapter7_5
{
    public interface IEatable
    {
        bool IsEatable();
    }

    public interface IForEat: IEatable
    {
        void IsAte();
    }

    public interface IForMilk
    {
        void GetMilk();
    }

    public interface IAnimal: Ilife
    {
        void GrowUp();
    }

    public interface Ilife
    {
        bool IsDead();
    }

    public class Cow : IForMilk, IAnimal
    {
        private int lifeLen;
        private int age;

        private const int eatableMinAge = 20;

        public Cow()
        {
            this.lifeLen = 5 * 12;
        }

        public void GetMilk()
        {
            Console.WriteLine("牛乳美味しい");
        }

        public void GrowUp()
        {
            this.age++;
        }

        public bool IsDead()
        {
            if (this.lifeLen < age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Beef : IForEat, IAnimal
    {
        private int lifeLen;
        private int age;
        private bool empty;

        private const int eatableMinAge = 20;

        public Beef()
        {
            this.lifeLen = 20 * 12;
            this.empty = false;
        }

        public bool IsEatable()
        {
            if (eatableMinAge <= age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsAte()
        {
            Console.WriteLine("ごちそうさまでした");
            this.empty = true;
        }

        public void GrowUp()
        {
            this.age++;
        }

        public bool IsDead()
        {
            if (this.lifeLen < age || this.empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Terminal
    {
        public static void Main(string[] args)
        {
            IAnimal[] alist = new IAnimal[] { new Cow(), new Beef(), new Cow() };

            Console.WriteLine("牛の一生シミュレーション");
            for(int i = 0; i < alist.Length; i++)
            {
                IAnimal a = alist[i];
                int month = 1;
                while (!a.IsDead())
                {
                    Console.WriteLine("生後{0}ヶ月", month);
                    if(a is IForMilk)
                    {
                        IForMilk c = (IForMilk)a;

                        c.GetMilk();
                    }
                    else if(a is IForEat)
                    {
                        IForEat e = (IForEat)a;
                        if (e.IsEatable())
                        {
                            e.IsAte();
                        }
                    }

                    a.GrowUp();
                    month++;
                }
                Console.WriteLine("お亡くなりになりました");
            }
            Console.ReadKey();
        }
    }
}
