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
            StreamReader s = new StreamReader(@"C:\input.txt");
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
            
            s.Close();
        }
    }
}