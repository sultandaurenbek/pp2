using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void F(int n, int[] arr1, int[] arr2) // a function to write from one array to second array
        {
            for (int i = 0; i < n; i++)
        {
            arr2[2 * i] = arr1[i]; // double i element in first array to the second array
            arr2[(2 * i) + 1] = arr1[i];
        }
            for (int i = 0; i < arr2.Length; i++)
        {
            Console.Write(arr2[i] + " "); // output the second array 
        }
    }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // input integer

            string s = Console.ReadLine(); // input the variables to array

            string[] ar_str = s.Split(); // delete the spaces and put to the string array

            int[] arr1 = new int[n]; // new array with size n

            int[] arr2 = new int[2 * n]; // second array with size 2*n

            for (int i = 0; i < n; i++)
        {
            arr1[i] = int.Parse(ar_str[i]); // write variables from string array to the integer array
        }
            F(n, arr1, arr2); // call the funcrion
        }
    }

}