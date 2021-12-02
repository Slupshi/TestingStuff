using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                              TallGuy / Interface                              //
        //===============================================================================//

        class TallGuy : IClown
        {
            public string FunnyThingIHave => "big shoes"; // same as || get { return "big shoes"; } ||
            public void Honk() => Console.WriteLine("Honk honk!");

            public static void TallGuyMethod()
            {
                TallGuy tallGuy = new TallGuy() { Height = 76, Name = "Jimmy" };
                tallGuy.TalkAboutYourself();
                Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}");
                tallGuy.Honk();
            }

            public string Name;
            public int Height;
            public void TalkAboutYourself()
            {
                Console.WriteLine($"My name is {Name} and I'm {Height} inches tall.");
            }
        }//Fin de la class TallGuy

    }}     //=====================================|| Fin du namespace ||======================================================//


