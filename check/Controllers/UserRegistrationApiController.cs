using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using check.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace check.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistrationApiController : ControllerBase
    {
        private readonly string s;
        private readonly string hk= "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=Hackathon2;";
        public UserRegistrationApiController(IConfiguration configuration)
        {
          this.s=configuration.GetConnectionString("str");
        }
[HttpPost]
public async Task<IActionResult> Register([FromBody] User user)
{
    try
    {
        using (var connection = new NpgsqlConnection(hk))
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("employee_id", user.employee_id);
            parameters.Add("name", user.name);
           
           // var result = connection.Query("add_user", parameters, commandType: CommandType.StoredProcedure);
           var result = await connection.QueryAsync($"SELECT  add_user({user.employee_id},'{user.name}')");
            return Ok(result);
        }
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
    }


    

    }
}
