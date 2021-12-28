using System;
using System.IO;

namespace TestingStuff
{
    partial class Program
    {
        class KangarooPuzzle
        {
            public static void KangarooMain()
            {
                Kangaroo joey = new Kangaroo();
                int koala = joey.Wombat(joey.Wombat(joey.Wombat(1)));
                try
                {
                    Console.WriteLine((15 / koala) + " eggs per round");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("G'Day Mate!");
                }
            }

            class Kangaroo
            {
                FileStream fs;
                int croc;
                int dingo = 0;
                public int Wombat(int wallaby)
                {
                    dingo++;
                    try
                    {
                        if (wallaby > 0)
                        {
                            fs = File.OpenWrite("wobbiegong");
                            croc = 0;
                        }
                        else if (wallaby < 0)
                        {
                            croc = 3;
                        }
                        else
                        {
                            fs = File.OpenRead("wobbiegong");
                            croc = 1;
                        }
                    }
                    catch (IOException)
                    {
                        croc = -3;
                    }
                    catch
                    {
                        croc = 4;
                    }
                    finally
                    {
                        if (croc > 2)
                        {
                            croc -= dingo;
                        }
                    }
                    return croc;
                }

            }

        }
    }

}
