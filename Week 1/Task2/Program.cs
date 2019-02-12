using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    class Student

    {

        public string name;

        public string id;

        public string year;



        public Student()

        {

            name = Console.ReadLine();

            id = Console.ReadLine();

            year = Console.ReadLine();

        }



        public void PrintInfo()

        {

            int Year = int.Parse(year);

            Console.WriteLine($"Name: {name} ID: {id} Year: {Year}");

            Year++;

            Console.WriteLine($"Name: {name} ID: {id} Year: {Year}");

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
