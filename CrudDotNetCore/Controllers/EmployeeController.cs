using CrudDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
namespace CrudDotNetCore.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class EmployeeController : ControllerBase
   {
      private readonly IConfiguration _configuration;
      public EmployeeController(IConfiguration configuration)
      {
         this._configuration = configuration;
      }
      [HttpGet]
      [Route("GetAllEmployees")]
      public Response GetAllEmployees()
      {
         SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
         Response response = new Response(); 
         DAL dal = new DAL();
         response = dal.GetAllEmployee(connection);
         return response;  
      }
      [HttpGet]
      [Route("GetAllEmployeeById/{id}")]
      public Response GetAllEmployeeById(int id)
      {
         SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
         Response response = new Response();
         DAL dal = new DAL();
         response = dal.GetAllEmployeeById(connection,id);
         return response;
      }
      [HttpPost]
      [Route("AddEmployee")]
      public Response AddEmployee(Employee employee)
      {
         SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
         Response response = new Response();
         DAL dal = new DAL();
         response = dal.AddEmployee(connection, employee);
         return response;  
      }
      [HttpPut]
      [Route("UpdateEmployee")]
      public Response UpdateEmployee(Employee employee)
      {
         SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
         Response response = new Response();
         DAL dal = new DAL();
         response = dal.UpdateEmployee(connection, employee);
         return response;
      }
      [HttpDelete]
      [Route("DelteEmployee/{id}")]
      public Response DeleteEmployee(int id)
      {
         SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
         Response response = new Response();
         DAL dal = new DAL();
         response = dal.DeleteEmployee(connection, id);  
         return response;  
      }
   }
}
