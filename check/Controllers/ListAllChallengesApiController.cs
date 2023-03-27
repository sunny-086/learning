
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using check.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Newtonsoft.Json;
using System.Text.Json;

namespace check.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListAllChallengesApiController : ControllerBase
    {
        private readonly string hk= "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=Hackathon2;";



        [HttpGet]
public async Task<IActionResult> getAllChallenge(int in_user_id)
{
    try
    {
        using (var connection = new NpgsqlConnection(hk))
        {
            connection.Open();
            
           
           // var result = connection.Query("add_user", parameters, commandType: CommandType.StoredProcedure);
           var result = await connection.QueryAsync($"SELECT public.get_challenges_with_tags({in_user_id})");
        // 
        
            return Ok((result));
        }
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
    }
    }
}