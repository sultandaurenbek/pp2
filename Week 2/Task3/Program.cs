using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static string s = "   ";

        static void F(DirectoryInfo dir, int k)//recursive function that prints info about directory
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;//folders are yellow

            for (int i = 0; i < k; i++)
            {
                Console.Write(s);
            }
            Console.Write(dir.Name);//function prints the name of directory first

            Console.WriteLine();

            var x = dir.GetFileSystemInfos();

            foreach (var t in x)

            {

                if (t.GetType() == typeof(DirectoryInfo))//if its directory we call function with more spaces
                {
                    DirectoryInfo y = t as DirectoryInfo;

                    F(y, k + 1);
                 }
                if (t.GetType() == typeof(FileInfo))//if its file its just print the name of file

                {
                   Console.ForegroundColor = ConsoleColor.White;

                    for (int i = 0; i < k + 1; i++)

                    {

                        Console.Write(s);

                    }

                    Console.Write(t);

                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)

        {
            DirectoryInfo dirinfo = new DirectoryInfo(@"C:\Users\Sultan\Desktop\Intel");

            F(dirinfo, 0);//calling function
        }
    }
}