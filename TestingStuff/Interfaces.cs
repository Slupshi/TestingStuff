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
