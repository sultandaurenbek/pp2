using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int n = int.Parse(Console.ReadLine()); // read single number n and convert it
                string s = Console.ReadLine(); //read line of numbers 
                string[] array_str = new string[n]; // new array of strings
                array_str = s.Split(); // save characters between " " (space) to array of strings
                int[] array_int = new int[n]; // new array of integers
                for (int i = 0; i < n; i++) array_int[i] = int.Parse(array_str[i]); // converting each characters to integers and save in array
                List<int> ls = new List<int>(); // new list
                for (int i = 0; i < n; i++)
                {
                    if (array_int[i] <= 1) continue; // zero and one are not prime numbers (exceptions in our code)
                    if (array_int[i] == 2) // two is also exception and it is prime
                    {
                        ls.Add(array_int[i]); // add to list 
                        continue; //test next number

                    }
                    for (int j = 2; i < array_int[i]; j++)
                    {
                        if (array_int[i] % j == 0) break; // search for number that will not divided by number between 2 and this number
                        if (j == array_int[i] - 1) ls.Add(array_int[i]); // if our divider reaches from 2 to our testing number this number is prime
                    }
                }
                Console.WriteLine(ls.Count); //size of our list
                for (int i = 0; i < ls.Count; i++) Console.Write(ls[i] + " "); // print all numbers added to our list
            }
        }
    }
}