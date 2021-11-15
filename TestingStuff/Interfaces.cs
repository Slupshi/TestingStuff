using System;

namespace TestingStuff
{
    interface IClown
    {
        void Honk();
        string FunnyThingIHave { get; }

        protected static Random random = new Random();
        private static int carCapacity = 12;
        public static int CarCapacity
        {
            get { return carCapacity; }
            set
            {
                if (value > 10) carCapacity = value;
                else Console.Error.WriteLine($"Warning: Car capacity {value} is too small");
            }
        }
        public static string ClownCarDescription()
        {
            return $"A clown car with {random.Next(CarCapacity / 2, CarCapacity)} clowns";
        }
    }
    interface IScaryClown : IClown
    {
        string ScaryThingIHave { get; }
        void ScareLittleChildren();

        void ScareAdults()
        {
            Console.WriteLine($@"I am an ancient evil that will haunt your dreams.
            Behold my terrifying necklace with {random.Next(4, 10)} of my last victim's fingers.
            Oh, also, before I forget...");
            ScareLittleChildren();
        }
    }
    interface INose
    {
        string Face { get; }
        int Ear();
    }
    interface ISwimmer
    {
        void Swim();
    }
    interface IPackHunter
    {
        void HuntInPack();
    }
}
