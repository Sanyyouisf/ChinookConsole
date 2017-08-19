using System;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    class UpdateLastName
    {
    
        public void Update()
        {
            //the input data
            var employeeList = new ListEmployees();
            var EmpIdToUpdate = employeeList.List("Choose an employee to update the last Name :");
            Console.WriteLine("enter the new Last Name :");
            var UpdatedLastName = Console.ReadLine();
                
            //1-create connection
            //using (var connection = new SqlConnection("Server = (Local)\\sqlexpress; Database = Chinook; Trusted_Connection = True;"))
            using (var Connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                //2-create command to display the list of employee -- we donot need this when using Dapper 
                //var DisplayEmployeeList =Connection.CreateCommand();

                //3-set the text of the command - we donot need this when using Dapper 
                //DisplayEmployeeList.CommandText = "Select EmployeeId as Id,FirstName + ' ' + LastName as FullName from Employee";
                try
                {
                    //4-open the connection
                    Connection.Open();
                    //5- run the command - we donot need this when using Dapper
                    //var reader = DisplayEmployeeList.ExecuteReader();
                    var updatedRows = Connection.Execute("UPDATE Employee SET LastName = @NewLastName WHERE EmployeeId = @EmpId", new { NewLastName = UpdatedLastName, EmpId = EmpIdToUpdate});
                    var FirstName = Connection.ExecuteScalar("select FirstName from Employee where EmployeeId = @EmpId" ,new { EmpId = EmpIdToUpdate});
                    if (updatedRows == 1)
                    {
                        Console.WriteLine($"you upated {FirstName} Last Name Successfully to be {UpdatedLastName}");
                    }
                    else if (updatedRows > 1)
                    {
                        Console.WriteLine("oopp some thing wrong you updated more than 1 line ");
                    }
                    else
                    {
                        Console.WriteLine("Failed to find a matching Id");
                    }
                    Console.WriteLine("Press enter to return to the menu");
                    Console.ReadLine();
                }


                //while (reader.Read())
                //{
                //  Console.WriteLine($"{reader["Id"]}.) {reader["FullName"]}");
                //}

                //creat the other command to update the last name
                //var UpdateEmployeeLastNameCommand = Connection.CreateCommand();

                //Console.WriteLine("> choose theEmployee number to update");
                //var EmpId = Console.ReadLine();
                //UPDATE Employee SET LastName = 'NewLastName' WHERE EmployeeId = 10
                //Console.WriteLine("Enter the new last Name");
                //var NewLastName = Console.ReadLine();

                //set the text of the update command
                //UpdateEmployeeLastNameCommand.CommandText = "UPDATE Employee SET LastName = '@NewLastName' WHERE EmployeeId = @EmpId";


                // var updatedLastNameParameter = UpdateEmployeeLastNameCommand.Parameters.Add("@NewLastName", SqlDbType.VarChar);
                // updatedLastNameParameter.Value = NewLastName;

                //var updatedLastNameParameterId = UpdateEmployeeLastNameCommand.Parameters.Add("@NewLastName", SqlDbType.VarChar);
                //updatedLastNameParameter.Value = NewLastName;

                //try
                //{
                //set the text of update command
                //var rowsAffected = UpdateEmployeeLastName.ExecuteNonQuery();
                // Console.WriteLine(rowsAffected != 1 ? "Add Failed" : "Success!");
                //  Console.WriteLine("Press enter to return to the menu.");
                //Console.ReadLine();
                //}
                //catch (Exception ex)
                //{
                //  Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
                //}
                //}
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }


            }
        }
    }
}
