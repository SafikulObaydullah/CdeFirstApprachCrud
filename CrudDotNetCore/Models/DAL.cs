using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CrudDotNetCore.Models
{
   public class DAL
   {
      public Response GetAllEmployee(SqlConnection connection)
      {
         Response response = new Response();
         SqlDataAdapter da = new SqlDataAdapter("Select * from tblCrudNetCore",connection);
         DataTable dt = new DataTable();
         List<Employee> lstemployees = new List<Employee>();
         da.Fill(dt);
         if(dt.Rows.Count > 0)
         {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               Employee employee = new Employee();
               employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
               employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
               employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
               employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
               lstemployees.Add(employee);
            }
         }
         if(lstemployees.Count > 0)
         {
            response.StatusCode = 200;
            response.StatusMessage = "Data found";
            response.listEmployee = lstemployees;  
         }
         else
         {
            response.StatusCode = 100;
            response.StatusMessage = "No data found";
            response.listEmployee = null;
         }
         return response;  
      }
      public Response GetAllEmployeeById(SqlConnection connection,int id)
      {
         Response response = new Response();
         SqlDataAdapter da = new SqlDataAdapter("Select * from tblCrudNetCore where ID = '"+id+"' AND IsActive = 1", connection);
         DataTable dt = new DataTable();
         Employee lstemployees = new Employee();
         da.Fill(dt);
         if (dt.Rows.Count > 0)
         {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               Employee employee = new Employee();
               employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
               employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
               employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
               employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
               response.StatusCode = 200;
               response.StatusMessage = "Data found";
               response.Employee = employee;
            }
         }
         else
         {
            response.StatusCode = 100;
            response.StatusMessage = "No data found";
            response.Employee = null;
         }
         return response;
      }
      public Response AddEmployee(SqlConnection connection, Employee employee)
      {
         Response response = new Response();
         SqlCommand cmd = new SqlCommand("Insert into tblCrudNetCore(name,Email,IsActive,Creation) Values('"+employee.Name+"','"+employee.Email+"','"+employee.IsActive+"',GetDate())", connection);
         DataTable dt = new DataTable();
         Employee lstemployees = new Employee();
         connection.Open();
         int i = cmd.ExecuteNonQuery();
         connection.Close();
         if(i>0)
         {
            response.StatusCode=200;
            response.StatusMessage = "Employee added.";
         }
         else
         {
            response.StatusCode = 100;
            response.StatusMessage = "No data inserted";
         }
         return response;
      }
      public Response UpdateEmployee(SqlConnection connection, Employee employee)
      {
         Response response = new Response();
         SqlCommand cmd = new SqlCommand("Update tblCrudNetCore Set Name = '" + employee.Name + "',Email = '" + employee.Email + "',Where ID = '"+employee.Id +"'", connection);
         DataTable dt = new DataTable();
         Employee lstemployees = new Employee();
         connection.Open();
         int i = cmd.ExecuteNonQuery();
         connection.Close();
         if (i > 0)
         {
            response.StatusCode = 200;
            response.StatusMessage = "Employee added.";
         }
         else
         {
            response.StatusCode = 100;
            response.StatusMessage = "No data inserted";
         }
         return response;
      }
      public Response DeleteEmployee(SqlConnection connection,int id)
      {
         Response response=new Response();   
         SqlCommand cmd = new SqlCommand("delete from tblCrudNetCore Where ID= '" + id +"'",connection);
         connection.Open();
         int i = cmd.ExecuteNonQuery();
         connection.Close();
         if(i > 0)
         {
            response.StatusCode=200;
            response.StatusMessage = "Employee deleted";
         }
         else
         {
            response.StatusCode=100;
            response.StatusMessage = "No employee deleted";
         }
         return response;
      }
   }
}
