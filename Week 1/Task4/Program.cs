using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //read single number n and convert it

            string[,] arr = new string[n, n]; // new array of strings to n*n
        

            for (int i = 0; i < n; i++)

            {

                for (int j = 0; j <= i ; j++) arr[i, j] = "[*]";// put our symbol to 2D array
                
            }

            for (int i = 0; i < n; i++)

            {

                for (int j = 0; j < n; j++) Console.Write(arr[i, j]);

                Console.WriteLine(); // output our 2D array

            } 
        }
    }
}
