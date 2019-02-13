using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //to read text from files
            FileStream fs = new FileStream(@"C:\input.txt", FileMode.Open, FileAccess.Read); // указываем путь к файлу
            StreamReader s = new StreamReader(fs);
            string l = s.ReadLine(); // saving read files to string l;
            bool k = true;
            for (int i = 0; i < l.Length; i++) // checking for polindrome
            {
                if (l[l.Length - 1 - i] != l[i])
                {
                    k = false;
                    break;
                }
            }
            if (k == true) Console.WriteLine("YES");
            else Console.WriteLine("NO");
            fs.Close();
            s.Close();
        }
    }
}