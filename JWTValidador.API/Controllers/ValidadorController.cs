using JWTValidador.API.Exceptions;
using JWTValidador.API.Validations;
using Microsoft.AspNetCore.Mvc;

namespace JWTValidador.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidadorController : ControllerBase
{
    [HttpGet("JWT")]
    public async Task<ActionResult> Get([FromHeader] string jwt)
    {
		try
		{
            return Ok(JWTValidation.Valid(jwt));
        }
        catch (BaseException except)
        {
            Response.Headers.Append("Exception-Message", except.Message);
            Response.Headers.Append("Exception-Type", except.TipoExcecao.ToString());
        }

        return BadRequest("falso");
    }
}
