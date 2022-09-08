using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SqlDBLayer : IEmployeeRepository
    {
        public IConfiguration Configuration { get; }
        public SqlDBLayer(IConfiguration configuration) //dependency injection via constructor

        {
            Configuration = configuration;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using(SqlConnection con=new SqlConnection(Configuration.GetConnectionString("EmployeeContext")))
            {
                string query = "select id,Name,Salary,Emp.department,Dept.DeptName from Employees Emp left join Departments Dept on Dept.deptid=Emp.Department";
                using(SqlCommand cmd =new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while(sdr.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                Name = sdr["Name"].ToString(),
                                Salary=Convert.ToInt32(sdr["Salary"]),
                                Department=Convert.ToInt32(sdr["Department"])
                            }) ;
                        }
                    }
                        con.Close();
                }
            }
            return employees;
        }
    }
}
