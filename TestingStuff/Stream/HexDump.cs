namespace TestingStuff
{
    partial class Program
    {
        partial class Stream
        {
            class HexDump
            {
                public static void HexDumpMain(string[] args)
                {
                    /*Console.Clear();


                    var position = 0;
                    using Stream input = File.OpenRead(args[0]);

                    var buffer = new char[16];
                    using (var reader = new StreamReader("binarydata.dat"))
                        while (position < input.Lenght)
                        {
                            // Read up to the next 16 bytes from the file into a byte array

                            var bytesRead = reader.ReadBlock(buffer, 0, 16);
                            // Write the position (or offset) in hex, followed by a colon and space
                            Console.Write("{0:x4}: ", position);
                            position += bytesRead;
                            // Write the hex value of each character in the byte array
                            for (var i = 0; i < 16; i++)
                            {
                                if (i < bytesRead)
                                    Console.Write("{0:x2} ", (byte)buffer[i]);
                                else
                                    Console.Write(" ");
                                if (i == 7) Console.Write("-- ");
                            }
                            // Write the actual characters in the byte array
                            var bufferContents = Encoding.UTF8.GetString(buffer);
                            Console.WriteLine(" {0}", bufferContents.Substring(0, bytesRead));
                        }*/





                }


            }
        }
    }

}
