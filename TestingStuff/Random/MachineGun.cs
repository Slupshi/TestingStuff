using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                                Paintball Gun                                  //
        //===============================================================================//

        //Nouvelle class MachineGun 
        class MachineGun
        {

            public MachineGun(int balls, int magazineSize, bool loaded)
            {
                this.balls = balls;
                MagazineSize = magazineSize;
                if (!loaded) Reload();
            }

            public int MagazineSize { get; private set; } = 16;

            private int balls = 0;

            public int BallsLoaded { get; private set; }

            public bool IsEmpty() { return BallsLoaded == 0; }

            public int Balls
            {
                get { return balls; }
                set
                {
                    if (value > 0)
                        balls = value;
                    Reload();
                }
            }

            public void Reload()
            {
                BallsLoaded = balls > MagazineSize ? MagazineSize : balls;
            }

            public bool Shoot()
            {
                if (BallsLoaded == 0) return false;
                BallsLoaded--;
                balls--;
                return true;
            }

            private static int ReadInt(int lastUsedValueGun, string promptGun)
            {
                Console.Write(promptGun + " [" + lastUsedValueGun + "]: ");
                string promptGunRead = Console.ReadLine();
                if (promptGunRead == "")
                {
                    Console.WriteLine("using default value " + lastUsedValueGun);
                }
                else
                {
                    if (int.TryParse(promptGunRead, out lastUsedValueGun))
                    {
                        Console.WriteLine("using value " + lastUsedValueGun);
                    }
                    else
                    { Console.WriteLine("using default value " + lastUsedValueGun); }
                }
                return lastUsedValueGun;
            }

            public static void PaintballGun()
            {
                int numberOfBalls = ReadInt(20, "Number of balls");
                int magazineSize = ReadInt(16, "Magazine size");

                Console.Write($"Loaded [false]: ");
                bool.TryParse(Console.ReadLine(), out bool isLoaded);

                MachineGun gun = new MachineGun(numberOfBalls, magazineSize, isLoaded);

                while (true)
                {
                    Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
                    if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                    Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");
                    char key = Console.ReadKey(true).KeyChar;
                    if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                    else if (key == 'r') gun.Reload();
                    else if (key == '+') gun.Balls += gun.MagazineSize;
                    else if (key == 'q') return;
                }
            }
        } //Fin de la class MachineGun

    }}     //=====================================|| Fin du namespace ||======================================================//


