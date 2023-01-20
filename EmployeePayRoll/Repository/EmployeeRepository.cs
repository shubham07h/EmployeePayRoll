﻿using System.Data.SqlClient;
using EmployeePayroll.Model;

namespace EmployeePayroll.Repository
{
    public class EmployeeRepository
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial catalog=EmployeePayroll;
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

            SqlCommand cmd = new SqlCommand("Create table Employee(id int primary key identity(1,1),name varchar(200)," +
                "PhoneNumber bigint,Address varchar(200),Gender char,Basic_Pay bigint,Deduction bigint,Taxable_Pay bigint," +
                "Tax bigint,Net_Pay bigint,start_date date);", connection);
            connection.Open();
            cmd.ExecuteNonQuery();

        }
        public static void GetAllEmployee()
        {
            EmployeeModel empmodel = new EmployeeModel();
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial catalog=EmployeePayroll;
                                  Integrated Security=true");

                using (connection)
                {
                    string Query = @"Select * from Employee";
                    SqlCommand cmd = new SqlCommand(Query, connection);
                    connection.Open();

                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            empmodel.Id = datareader.GetInt32(0);
                            empmodel.name = datareader.GetString(1);
                            empmodel.PhoneNumber = datareader.GetInt64(2);
                            empmodel.Address = datareader.GetString(3);
                            empmodel.Gender = datareader.GetString(4);
                            empmodel.Basic_Pay = datareader.GetInt64(5);
                            empmodel.Deduction = datareader.GetInt64(6);
                            empmodel.TaxablePay = datareader.GetInt64(7);
                            empmodel.Tax = datareader.GetInt64(8);
                            empmodel.Net_Pay = datareader.GetInt64(9);
                            Console.WriteLine(empmodel.Id + " " + empmodel.name + " " + empmodel.PhoneNumber + " " +
                            empmodel.Address + " " + empmodel.Gender + " " + empmodel.Basic_Pay + " " + empmodel.Deduction + " "
                            + empmodel.TaxablePay + " " + empmodel.Tax + " " + empmodel.Net_Pay);

                        }
                        Console.WriteLine("Connection Established with database");
                    }
                    else
                    {
                        Console.WriteLine("Connection is not established with database");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }


}
