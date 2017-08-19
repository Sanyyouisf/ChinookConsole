using System;
using System.Data;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    public class AddEmployee
    {
        public void Add()
        {
            Console.WriteLine("Enter first name:");
            var x = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var y = Console.ReadLine();
            //1-create the connection
            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                //2-create the command
                var employeeAdd = connection.CreateCommand();
                //3-set the text of the command
                employeeAdd.CommandText = "Insert into Employee(FirstName, LastName) " +
                                          "Values(@firstName, @lastName)";
                //adding a variable parameter
                var firstNameParameter = employeeAdd.Parameters.Add("@firstName", SqlDbType.VarChar);
                firstNameParameter.Value = x;

                var lastNameParameter = employeeAdd.Parameters.Add("@lastName", SqlDbType.VarChar);
                lastNameParameter.Value = y;

                try
                {   
                    //oppen the connection
                    connection.Open();
                    //run the command 
                    var rowsAffected = employeeAdd.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected != 1 ? "Add Failed" : "Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}