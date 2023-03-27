using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using check.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace check.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidateUserApiController : ControllerBase
    {
         private readonly string s;
        private readonly string hk= "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=Hackathon2;";
        public ValidateUserApiController (IConfiguration configuration)
        {
          this.s=configuration.GetConnectionString("str");
        }
[HttpPost]
public async Task<IActionResult> validateUser([FromBody] User user)
{
    try
    {
        using (var connection = new NpgsqlConnection(hk))
        {
            connection.Open();
          
           
           // var result = connection.Query("add_user", parameters, commandType: CommandType.StoredProcedure);
var result = await connection.QueryAsync($"SELECT  validate_login4({user.employee_id},'{user.name}')");
           
//  var command= new NpgsqlCommand($"SELECT  validate_login4({user.employee_id},'{user.name}')", connection);
//     var result = await command.ExecuteScalarAsync();
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