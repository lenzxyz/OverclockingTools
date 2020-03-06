using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.IO.Compression;

namespace OverclockTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("- Welcome to OverclockTools -");
            Console.WriteLine("=============================");
            Console.WriteLine("Please select Tool to Launch (q to quit");
            Console.WriteLine("1. CoreTemp");
            Console.WriteLine("2. HW Monitor");
            Console.WriteLine("3. Prime95");
            Console.WriteLine("4. Cinebench");
            int count = 0;
            while (count == 0)
            {
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();
                if (input == "q")
                {
                    count++;
                }
                else
                {
                    launch(input);
                }
            }
            Console.WriteLine("===============");
            Console.WriteLine("Goodbye");
            Console.WriteLine("Closing in 3sec");
            System.Threading.Thread.Sleep(3000);
        }

        static void launch(string toolname)
        {
            string path = Directory.GetCurrentDirectory();
            if (toolname == "cinebench")
            {
                try
                {
                    Process.Start($@"{path}\tools\{toolname}.exe");
                }
                catch
                {
                    Console.WriteLine("This tool counts as additional content and needs to be downloaded first");
                    Console.WriteLine("Go forwad? (y for yes/n for no)");
                    Console.Write("> ");
                    string input = Console.ReadLine().ToLower();
                    if (input == "y" || input == "yes")
                    {
                        Console.WriteLine("This could take up some time");
                        using (var client = new WebClient())
                        {
                            client.DownloadFile("http://http.maxon.net/pub/cinebench/CinebenchR20.zip", "CinebenchR20.zip");
                        }
                        Console.WriteLine("Finished file download. Extracting file and make it ready to boot");
                        ZipFile.ExtractToDirectory($@"{path}\CinebenchR20.zip", $@"{path}\tools");
                        File.Delete($@"{path}\CinebenchR20.zip");
                        Process.Start($@"{path}\tools\{toolname}.exe");
                    }
                }
            }
            else
            {
                try
                {
                    Process.Start($@"{path}\tools\{toolname}.exe");
                }
                catch
                {
                    Console.WriteLine($"The tool '{toolname}' could not be found");
                }
            }

        }
    }
}
