using System;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    class UpdateLastName
    {
    
        public void Update()
        {
            Console.Clear();
            //1-create connection
            //using (var connection = new SqlConnection("Server = (Local)\\sqlexpress; Database = Chinook; Trusted_Connection = True;"))
            using (var Connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {   
                //2-create command to display the list of employee
                var DisplayEmployeeList =Connection.CreateCommand();
                //3-set the text of the command
                DisplayEmployeeList.CommandText = "Select EmployeeId as Id,FirstName + ' ' + LastName as FullName from Employee";
                try
                {   
                    //4-open the connection
                    Connection.Open();
                    //5- run the command
                    var reader = DisplayEmployeeList.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}.) {reader["FullName"]}");
                    }

                    //creat the other command to update the last name
                    var UpdateEmployeeLastNameCommand = Connection.CreateCommand();

                    Console.WriteLine("> choose theEmployee number to update");
                    var EmpId = Console.ReadLine();
                    //UPDATE Employee SET LastName = 'NewLastName' WHERE EmployeeId = 10
                    Console.WriteLine("Enter the new last Name");
                    var NewLastName = Console.ReadLine();
                    
                    //set the text of the update command
                    UpdateEmployeeLastNameCommand.CommandText = "UPDATE Employee SET LastName = '@NewLastName' WHERE EmployeeId = @EmpId";


                   // var updatedLastNameParameter = UpdateEmployeeLastNameCommand.Parameters.Add("@NewLastName", SqlDbType.VarChar);
                   // updatedLastNameParameter.Value = NewLastName;

                    //var updatedLastNameParameterId = UpdateEmployeeLastNameCommand.Parameters.Add("@NewLastName", SqlDbType.VarChar);
                    //updatedLastNameParameter.Value = NewLastName;

                    try
                    {
                        //set the text of update command
                        //var rowsAffected = UpdateEmployeeLastName.ExecuteNonQuery();
                       // Console.WriteLine(rowsAffected != 1 ? "Add Failed" : "Success!");
                        Console.WriteLine("Press enter to return to the menu.");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
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
