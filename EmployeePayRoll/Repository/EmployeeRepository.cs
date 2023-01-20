using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace EmployeePayroll.Repository
{
    internal class EmployeeRepository
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial catalog=master;
                                  Integrated Security=true");
        public void CreateDatabase()
        {

            SqlCommand cmd = new SqlCommand("Create database EmployeePayroll", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Database created successfully");
        }
        public void CreateTable()
        {
            SqlCommand cmd = new SqlCommand("Create Table EmployeeTable(id int primary key identity(1,1),Name varchar(200),Salary bigint,Startdate date,phone bigint," +
                    "Emp_Address varchar(200),Department varchar(200),Gender varchar(10), Basic_Pay bigint," +
                    "Deductions bigint,Taxable_Pay bigint,Income_Tax bigint,Net_Pay bigint )", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table Created Successfully");
        }
    }
}