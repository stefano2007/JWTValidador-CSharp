using JWTValidador.API.Exceptions;
using JWTValidador.API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace JWTValidador.API.Validations;
public static class JWTValidation
{
    /*
    Construa uma aplicação que exponha uma api web que recebe por parâmetros um JWT (string) e verifica se é válida, conforme regras abaixo:
    • Deve ser um JWT válido
    • Deve conter apenas 3 claims(Name, Role e Seed)
    • A claim Name não pode ter carácter de números
    • A claim Role deve conter apenas 1 dos três valores (Admin, Member e External)
    • A claim Seed deve ser um número primo.
    • O tamanho máximo da claim Name é de 256 caracteres.
    */
    private static readonly string[] ClaimsValidas = ["Name", "Role", "Seed"];
    private static readonly string[] RolesValidas = ["Admin", "Member", "External"];
    public static string Valid(string jwt)
    {
        var jwtToken = ValidateToken(jwt);

        

        return "verdadeiro";
    }
    public static JwtSecurityToken ValidateToken(string token)
    {
        try
        {
            return new JwtSecurityToken(token);
        }
        catch (Exception)
        {
            throw new InvalidJWTException("JWT invalido");
        }
    }
    public static JWTTokenModel ConvertToken(this IEnumerable<Claim> claims)
    {
        var name = claims.FirstOrDefault(x => x.Type.Equals( "Name"))?.Value ?? "";
        var role = claims.FirstOrDefault(x => x.Type.Equals("Role"))?.Value ?? "";
        var seed = claims.FirstOrDefault(x => x.Type.Equals("Seed"))?.Value ?? "";

        return new (name: name, role: role, seed: seed);
    } 
}
