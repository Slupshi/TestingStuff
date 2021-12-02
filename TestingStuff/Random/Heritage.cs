using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                                 Heritage                                      //
        //===============================================================================//

        //Nouvelles class |Test Héritage|
        class Heritage
        {


            public static void TestBird()
            {
                while (true)
                {
                    Bird bird;
                    Console.Write("Press P for pigeon, O for ostrich: ");
                    char key = Char.ToUpper(Console.ReadKey().KeyChar);
                    if (key == 'P') bird = new Pigeon();
                    else if (key == 'O') bird = new Ostrich();
                    else return;
                    Console.Write("\nHow many eggs should it lay? ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
                    Egg[] eggs = bird.LayEggs(numberOfEggs);
                    foreach (Egg egg in eggs)
                    {
                        Console.WriteLine(egg.Description);
                    }
                }
            }

            class Egg
            {
                public double Size { get; private set; }
                public string Color { get; private set; }
                public Egg(double size, string color)
                {
                    Size = size;
                    Color = color;
                }
                public string Description
                {
                    get { return $"A {Size:0.0}cm {Color} egg"; }
                }
            }
            class BrokenEgg : Egg
            {
                public BrokenEgg(string color) : base(0, $"broken {color}")
                {
                    Console.WriteLine("A bird laid a broken egg");
                }
            }
            abstract class Bird
            {
                public static Random Randomizer = new Random();
                public abstract Egg[] LayEggs(int numberOfEggs);

            }
            class Pigeon : Bird
            {
                public override Egg[] LayEggs(int numberOfEggs)
                {
                    Egg[] eggs = new Egg[numberOfEggs];
                    for (int z = 0; z < numberOfEggs; z++)
                    {
                        if (Bird.Randomizer.Next(4) == 0)
                            eggs[z] = new BrokenEgg("white");
                        else
                            eggs[z] = new Egg(Bird.Randomizer.NextDouble() * 2 + 1, "white");
                    }
                    return eggs;
                }
            }
            class Ostrich : Bird
            {
                public override Egg[] LayEggs(int numberOfEggs)
                {
                    Egg[] eggs = new Egg[numberOfEggs];
                    for (int i = 0; i < numberOfEggs; i++)
                    {
                        eggs[i] = new Egg(Bird.Randomizer.NextDouble() + 12, "speckled");
                    }
                    return eggs;
                }
            }

        }//Fin de la class Heritage

    }}     //=====================================|| Fin du namespace ||======================================================//


