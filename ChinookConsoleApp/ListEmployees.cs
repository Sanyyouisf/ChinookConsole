using System;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class EmployeeListResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class ListEmployees
    {
        public int List(string prompt)
        {
            Console.Clear();
            //1- create connection
            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                //2- create command
                var employeeListCommand = connection.CreateCommand();
                //3- set the text of command
                employeeListCommand.CommandText = "select employeeid as Id, " +
                                                  "firstname + ' ' + lastname as fullname " +
                                                  "from Employee";
                try
                {
                    //4- open the connection
                    connection.Open();

                    //5- run the command 
                    //var reader = employeeListCommand.ExecuteReader();

                    var result = connection.Query<EmployeeListResult>("select employeeid as Id, " +
                                                                      "firstname + ' ' + lastname as fullname " +
                                                                      "from Employee");

                    foreach (var employee in result)
                    {
                        Console.WriteLine($"{employee.Id}.) {employee.FullName}");
                    }

                    Console.WriteLine(prompt);
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                return 0;
            }
        }
    }
}
