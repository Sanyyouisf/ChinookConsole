﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();

                Console.WriteLine("----------------------Welcome to Chinook---------------------");
                Console.WriteLine("------------Please select from the following options---------");
                Console.WriteLine("1. List Employees");
                Console.WriteLine("2. Add an Employee");
                Console.WriteLine("3. Update Employee Last Name");
                Console.WriteLine("4. delete Employee ");
                Console.WriteLine("5. List Employee Sales in certain year");
                Console.WriteLine("9. Exit");
                Console.WriteLine("");
                Console.Write(">");
                var selection = Console.ReadLine();


                if (selection == "1") new ListEmployees().List("press enter to return ");
                if (selection == "2") new AddEmployee().Add();
                if (selection == "4") new DeleteEmployee().Delete();
                if (selection == "3") new UpdateLastName().Update();
                if (selection == "5") new ListEmployeeSalesByYear().List("Press Enter 2 return");
                if (selection == "9") break;

            }
        }
    }
}
