using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Role_Management_System.Models;
using System.Data.SqlClient;
using System.Configuration;


namespace Role_Management_System.DataServices.EmployeeServices
{
    public class EmployeeViewModel
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Management"].ConnectionString);
        public List<Employee> GetEmployee()
        {
           List<Employee> list = new List<Employee>();
            using(conn)
            {
                SqlCommand cmd = new SqlCommand("GetEmployee", conn);
                using (cmd)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = Convert.ToInt32(reader["Id"]);
                        emp.Name = reader["Name"].ToString();
                        emp.Department = reader["Department"].ToString();
                        emp.Email = reader["Email"].ToString();
                        emp.Salary = reader["Salary"].ToString();
                        list.Add(emp);
                        
                    }
                }
            }
            return list;
        }

        public Employee GetEmployeeById(int Id)
        {
            Employee emp = new Employee();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("GetEmployeeById", conn);
                using (cmd)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("Id", Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            emp.Name = reader["Name"].ToString();
                            emp.Department = reader["Department"].ToString();
                            emp.Email = reader["Email"].ToString();
                            emp.Salary = reader["Salary"].ToString();
                        }
                    }
                }
            }
            return emp;
        }

        public void CreateEmployee(Employee employee)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("CreateEmployee", conn);
                using (cmd)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    float Salary = 23;
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", conn);
                using (cmd)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    float Salary = float.Parse(employee.Salary);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int Id)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", conn);
                using (cmd)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}