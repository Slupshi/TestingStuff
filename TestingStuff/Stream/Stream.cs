using System;

namespace TestingStuff
{
    partial class Program
    {
        partial class Stream
        {
            public static void ChooseStream()
            {
                Console.WriteLine("Press 1 for TestStream, 2 for FlobboFridge, 3 for JsonSerialization");
                Console.WriteLine("Press 4 for HexDump");
                Console.WriteLine("Any other key to quit");
                char streamKey = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (streamKey)
                {
                    case '1':
                        Console.Clear();
                        TestStream.TestStreamMain();
                        break;
                    case '2':
                        Console.Clear();
                        Flobbo.FlobboMain();
                        break;
                    case '3':
                        Console.Clear();
                        JsonSerialization.JsonSerializationMain();
                        break;
                    case '4':
                        Console.Clear();
                        //HexDump.HexDumpMain();
                        break;
                    default:
                        return;
                }
            }
        }
    }

}
