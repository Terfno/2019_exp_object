using System;

namespace chapter7_4
{
    abstract class Car
    {
        private string carName;
        public int maxSpeed;

        public Car(string carName, int maxSpeed)
        {
            this.carName = carName;
            this.maxSpeed = maxSpeed;
        }

        public virtual string GetInfo()
        {
            return carName;
        }

        public abstract string GetSpeed();
    }

    class BrandCar : Car
    {
        private string brand; //e.g. Lamborghini, Ferrari

        public BrandCar(string brand, string carName, int maxSpeed) : base(carName, maxSpeed)
        {
            this.brand = brand;
        }

        public override string GetInfo()
        {
            return this.brand + " | " + base.GetInfo();
        }

        public override string GetSpeed()
        {
            return maxSpeed.ToString() + "km/h";
        }
    }

    class Track : Car
    {
        private int maxLC; //Maximum loading capacity

        public Track(int maxLC, string carName, int maxSpeed) : base(carName, maxSpeed)
        {
            this.maxLC = maxLC;
        }

        public override string GetInfo()
        {
            return "Maximum loading capacity:" + maxLC + " | " + base.GetInfo();
        }

        public override string GetSpeed()
        {
            return maxSpeed.ToString() + "km/h";
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            BrandCar b = new BrandCar("Lamborghini", "huracan-evo", 325);
            Track t = new Track(2000, "dutro", 180);
            Car c1 = b;
            Car c2 = t;

            Console.WriteLine(c1.GetInfo() + ":" + b.GetSpeed());
            Console.WriteLine(c2.GetInfo() + ":" + t.GetSpeed());

            Console.ReadKey();
        }
    }
}
