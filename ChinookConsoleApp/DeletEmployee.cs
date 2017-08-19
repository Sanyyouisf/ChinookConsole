using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class DeleteEmployee
    {
        public void Delete()
        {
            var employeeList = new ListEmployees();
            var firedEmployee = employeeList.List("Pick an employee to Delete:");

            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                connection.Open();
                //var cmd = connection.CreateCommand();
                //cmd.CommandText = "Delete From Employee where EmployeeId = @EmployeeId";

                //var employeeIdParameter = cmd.Parameters.Add("@EmployeeId", SqlDbType.Int);
                //employeeIdParameter.Value = firedEmployee;

                try
                {
                    //run the command- we donot need this when using Dapper 
                    //var affectedRows = cmd.ExecuteNonQuery();
                    var deletedName = connection.Execute("Delete From Employee where EmployeeId = @EmployeeId" ,new { EmployeeId = firedEmployee });


                    //if (affectedRows == 1)
                    if (deletedName == 1)
                    {
                        Console.WriteLine(" deleted Successfully");
                    }
                    //else if (affectedRows > 1)
                    else if (deletedName >1)
                    {
                        Console.WriteLine("AAAAHHHHHH");
                    }
                    else
                    {
                        Console.WriteLine("Failed to find a matching Id");
                    }

                    Console.WriteLine("Press enter to return to the menu");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
