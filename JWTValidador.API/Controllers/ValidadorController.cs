using JWTValidador.API.Exceptions;
using JWTValidador.API.Model;
using JWTValidador.API.Validations;
using Microsoft.AspNetCore.Mvc;

namespace JWTValidador.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidadorController : ControllerBase
{
    [HttpGet(Name = "JTW")]
    public async Task<ActionResult> Get([FromHeader] string jwt)
    {
		try
		{
            var jwtToken = new JWTToken(jwt);
            return Ok(JWTValidation.Valid(jwtToken));
        }
        catch (BaseException except)
        {
            Response.Headers.Append("Exeption-Menssage", except.Message);
            Response.Headers.Append("Exeption-Type", nameof(except.TipoExcecao));
        }

        return BadRequest("falso");
    }
}
