using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static bool F(int n) // bool function that checks for prime; if the number prime f returns true, else returns false
        {
            if (n <= 1) return false;
            else
            {
            bool k = true;

            for (int i = 2; i < n; i++)
            {
              if (n % i == 0)
            {
              k = false;
              break;
            }
      }
           return k;
    }
}

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read);//reading file

            StreamReader s = new StreamReader(fs);

            string l = s.ReadLine(); //saving file into string l

            string[] str = l.Split(); // spliting string into substrings without space and saving them into array

            int[] b = new int[str.Length];

            for (int i = 0; i < str.Length; i++)

            {
               b[i] = int.Parse(str[i]); // converting string into integers
            }

            string path = "output.txt";

            FileStream fs1 = File.Create(path);

            fs1.Close();

            FileStream fs2 = new FileStream(path, FileMode.Append, FileAccess.Write); // file for writing

            StreamWriter w = new StreamWriter(fs2);

            for (int i = 0; i < b.Length; i++)
            {
            if (F(b[i]) == true)
            {
            w.Write(b[i] + " "); // writing actually
            }
  }
            w.Close();

            fs.Close();

            s.Close();
        }
    }
}