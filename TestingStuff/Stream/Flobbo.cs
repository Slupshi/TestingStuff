using System.IO;

namespace TestingStuff
{
    partial class Program
    {
        partial class Stream
        {
            class Flobbo
            {
                public static void FlobboMain()
                {
                    Flobbo f = new Flobbo("blue yellow");
                    StreamWriter sw = f.Snobbo();
                    f.Blobbo(f.Blobbo(f.Blobbo(sw), sw), sw);
                }

                private string zap;
                public Flobbo(string zap)
                {
                    this.zap = zap;
                }

                public StreamWriter Snobbo()
                {
                    return new StreamWriter("macaw.txt");

                }

                public bool Blobbo(bool Already, StreamWriter sw)
                {
                    if (Already)
                    {
                        sw.WriteLine(zap);
                        sw.Close();
                        return false;
                    }
                    else
                    {
                        sw.WriteLine(zap);
                        zap = "red orange";
                        return true;
                    }
                }

                public bool Blobbo(StreamWriter sw)
                {
                    sw.WriteLine(zap);
                    zap = "green purple";
                    return false;
                }
            }
        }
    }
}


