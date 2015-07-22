using System;
using System.IO;

namespace ICCProfReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Work wrk;//main work class
            if (args.Length != 0 && File.Exists(args[0]))
            {
                wrk = new Work();
                wrk.GetProfile(args[0]);
                wrk.GetData();
                wrk.PrintToConsole();
                if (args.Length>1)
                {
                    switch (args[1])
                    {
                        case "xml":wrk.PrintToXML();
                            break;
                        case "json":wrk.PrintToJSON();
                            break;
                        default: break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong parameters");
                return;
            }
        }
    }
}
