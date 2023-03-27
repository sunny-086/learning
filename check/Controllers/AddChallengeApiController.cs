using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using check.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Dapper;

namespace check.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddChallengeApiController : ControllerBase
    {
        private readonly string hk= "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=Hackathon2;";

        [HttpPost]
public async Task<IActionResult> addChallenge([FromBody] Challenge challenge)
{
    try
    {
        using (var connection = new NpgsqlConnection(hk))
        {
            connection.Open();
            var arr=challenge.p_tags;
            var tmp="{";
             for(int i=0;i<arr.Length;i++){
             if(i!=arr.Length-1){
                 tmp=tmp+arr[i]+",";
             }
             else{
                 tmp=tmp+arr[i];
             }
         }
         tmp=tmp+'}';
      
            
           
           // var result = connection.Query("add_user", parameters, commandType: CommandType.StoredProcedure);
           string qur=$"SELECT public.add_challenge3('{challenge.p_title}','{challenge.p_description}',{challenge.p_user_id},'{tmp}')";
           var result = await connection.QueryAsync(qur);
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