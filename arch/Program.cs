using arch.SendSpace;
using System;
using System.IO;

namespace arch
{
    class Program
    {



        private static string passwordFileName = @"password.txt";
        private static string outputFileName = "out.rar";
        private static string winrarPath = @"c:\Program Files\WinRAR\";
        private static string winrarExe = @"winrar.exe";
        [STAThread]
        static void Main(string[] args)
        {

            var s = new ProxySettings
            {
                ProxyHost = "127.0.0.1",
                ProxyPort = 9150
            };

            var api = new Api("88K9XFO3I6");
            var fstream = File.OpenRead("r:\\p1.py");
            api.Zoo(api.GetFileUploadInfo(null).UploadInfo, fstream);
            return;
            //var file = File.OpenRead("r:\\out.rar");




            return;


        }

        static void Error()
        {
            Console.WriteLine("wrong parameters");
            Environment.Exit(1);
        }

    }
}
