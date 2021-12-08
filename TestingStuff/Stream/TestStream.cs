using System;
using System.IO;

namespace TestingStuff
{
    partial class Program
    {
        partial class Stream
        {
            class TestStream
            {
                public static void TestStreamMain()
                {
                    Console.WriteLine("Press 1 to Write, 2 to Read");
                    Console.WriteLine("Any other key to quit");
                    char streamKey = Char.ToUpper(Console.ReadKey().KeyChar);
                    switch (streamKey)
                    {
                        case '1':
                            Console.Clear();
                            StreamVilainWrite();
                            break;
                        case '2':
                            Console.Clear();
                            StreamVilainRead();
                            break;
                        default:
                            return;
                    }
                }

                static void StreamVilainWrite()
                {
                    StreamWriter sw = new StreamWriter("secret_plan.txt");
                    sw.WriteLine("How I'll defeat Captain Amazing");
                    sw.WriteLine("Another genius secret plan by The Swindler");
                    sw.WriteLine("I'll unleash my army of clones upon the citizens of Objectville.");
                    string location = "the mall";
                    for (int number = 1; number <= 5; number++)
                    {
                        sw.WriteLine("Clone #{0} attacks {1}", number, location);
                        location = (location == "the mall") ? "downtown" : "the mall";
                    }
                    sw.Close();
                }

                static void StreamVilainRead()
                {
                    string c = $"{Path.DirectorySeparatorChar}";
                    var folder = $"D:{c}Training_Perso{c}TestingStuff{c}TestingStuff{c}bin{c}Debug{c}net5.0";
                    var reader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}secret_plan.txt");
                    var writer = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}emailToCaptainA.txt");
                    writer.WriteLine("To: CaptainAmazing@objectville.net");
                    writer.WriteLine("From: Commissioner@objectville.net");
                    writer.WriteLine("Subject: Can you save the day... again?");
                    writer.WriteLine();
                    writer.WriteLine("We’ve discovered the Swindler’s terrible plan:");
                    while (!reader.EndOfStream)
                    {
                        var lineFromThePlan = reader.ReadLine();
                        writer.WriteLine($"The plan -> {lineFromThePlan}");
                    }
                    writer.WriteLine();
                    writer.WriteLine("Can you help us?");
                    writer.Close();
                    reader.Close();
                }
            }
        }

    }

}
