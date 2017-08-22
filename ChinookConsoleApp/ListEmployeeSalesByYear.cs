using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    class ListEmployeeSalesByYear
    {
        public class EmployeeSalesListByYear
        {
            public int Id { get; set; }
            public string FullName { get; set;}
            public DateTime Year { get; set; }
            public int TotalSales { get; set; }
        }

        public int List(string prompt)
        {
            Console.WriteLine("Enter the year to display the list of employees and their total sales ");
            var SalesYear = Console.ReadLine();

            using (var Connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                try
                {
                    Connection.Open();

                    var result = Connection.Query<EmployeeSalesListByYear>
                        ("select  Employee.FirstName+' '+ Employee.LastName as FullName" +
                         //"sum(Invoice.Total) as TotalSales" +
                         "from Employee join Customer" +
                         "on Employee.EmployeeId = Customer.SupportRepId" +
                         "join Invoice" +
                         "on Invoice.CustomerId = Customer.CustomerId" +
                         "where year(Invoice.InvoiceDate) = @SelectedYear" +
                         "Group by Employee.FirstName,Employee.LastName" , new { SelectedYear = SalesYear });

                    foreach (var Emp in result)
                    {
                        Console.WriteLine($"{Emp.Id}.) {Emp.FullName} Total sales in {SalesYear} is {Emp.TotalSales }");
                    }
                    Console.WriteLine(prompt);
                    return int.Parse(Console.ReadLine());   
                }
                catch(Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.WriteLine(Ex.StackTrace);
                }
                return 0;
            }
        }
    }
}
