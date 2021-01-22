using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI_React_Client.Models;
using System.Data.Common;
using System.Data.SqlClient;


namespace WebAPI_React_Client.Controllers
{
    [EnableCors("*","*","*")] //need to add enable cors here
    public class EmployeeController : ApiController
    {
        public List<Employee> GetAll()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{Id=1,FirstName="Abhinav",LastName="Bangalore"},

                new Employee{Id=2,FirstName="Abhishek",LastName="Chennai"},

                new Employee{Id=3,FirstName="Akshay",LastName="Bangalore"},

                new Employee{Id=4,FirstName="Akash",LastName="Chennai"},

                new Employee{Id=5,FirstName="Anil",LastName="Bangalore"}
            };
            return empList;
        }
        //post method
        public bool Post(Employee employee)
        {
            SqlConnection cnn;
            string server = "localhost";
            string database = "test";
            string uid = "root";
            string password = "";   //im using xampp
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);


            SqlConnection conn = new SqlConnection(@"server=localhost;database=ReactAppDB;integrated security=true");            
            string query = "insert into EmployeeInfo values(@Id,@FirstName,@LastName)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", employee.Id));
            cmd.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", employee.LastName));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected > 0 ? true : false;
        }
    }
}
