using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    class Student

    {

        public string name; // variables in the class student

        public string id;

        public string year;



        public Student()

        {

            name = Console.ReadLine(); //input name

            id = Console.ReadLine(); //input id

            year = Console.ReadLine(); // input year

        }



        public void PrintInfo()

        {

            int Year = int.Parse(year); // convert to int

            Console.WriteLine($"Name: {name} ID: {id} Year: {Year}"); // output example (Name: Sultan ID: 18BD110366 Year:18 )

            Year++; // increment

            Console.WriteLine($"Name: {name} ID: {id} Year: {Year}"); // output example (Name: Sultan ID: 18BD110366 Year:19 )

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            Student s = new Student();

            s.PrintInfo();

        }

    }

}
