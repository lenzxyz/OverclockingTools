using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace OverclockTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("- Welcome to OverclockTools -");
            Console.WriteLine("=============================");
            Console.WriteLine("Please select Tool to Launch ");
            Console.WriteLine("1. CoreTemp");
            Console.WriteLine("2. HW Monitor");
            Console.WriteLine("3. Prime95");
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
            Process.Start($@"{path}\tools\{toolname}.exe");
        }
    }
}
