using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace check.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeAllChallengeApiController : ControllerBase
    {
          private readonly string hk= "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=Hackathon2;";



        [HttpGet]
public async Task<IActionResult> getAllChallengeOfEmployee(int emp_id)
{
    try
    {
        using (var connection = new NpgsqlConnection(hk))
        {
            connection.Open();
            
           
           // var result = connection.Query("add_user", parameters, commandType: CommandType.StoredProcedure);
           var result = await connection.QueryAsync($"SELECT public.get_user_challenges({emp_id})");
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