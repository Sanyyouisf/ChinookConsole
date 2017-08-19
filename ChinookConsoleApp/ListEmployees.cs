using System;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    public class ListEmployees
    {
        public void List()
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
                    var reader = employeeListCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}.) {reader["FullName"]}");
                    }

                    Console.WriteLine("Press enter to return to the menu.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}