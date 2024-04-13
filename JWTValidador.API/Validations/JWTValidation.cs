using JWTValidador.API.Exceptions;
using JWTValidador.API.Model;
using System.IdentityModel.Tokens.Jwt;
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

        bool isJWTValido = jwtToken.Claims.Count() == 3
                && ClaimsValidas.All(cl => jwtToken.Claims.Any(x => x.Type.Equals(cl)));

        if (!isJWTValido)
        {
            throw new InvalidStructureException("Invalid token structure should contain only 3 claims(Name, Role and Seed)");
        }
        var jwtTokenModel = jwtToken.Claims.ConvertToken();

        var hasNumber = new Regex(@"[0-9]");
        if (hasNumber.IsMatch(jwtTokenModel.Name))
        {
            throw new InvalidDomainException("The Name claim cannot have a number character");
        }

        if (!RolesValidas.Any(r => jwtTokenModel.Role.Equals(r)))
        {
            throw new InvalidDomainException("The Role claim must contain only 1 of the three values (Admin, Member, and External)");
        }

        bool isPrimo = int.TryParse(jwtTokenModel.Seed, out int seed)
                && VerificaNumeroPrimo(seed);

        if (!isPrimo)
        {
            throw new InvalidDomainException("The Seed claim must be a prime number");
        }

        if (jwtTokenModel.Name.Length > 256)
        {
            throw new InvalidDomainException("The maximum length of the Name claim is 256 characters");
        }

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
            throw new InvalidJWTException("Invalid JWT");
        }
    }
    public static JWTTokenModel ConvertToken(this IEnumerable<Claim> claims)
    {
        var name = claims.FirstOrDefault(x => x.Type.Equals("Name"))?.Value ?? "";
        var role = claims.FirstOrDefault(x => x.Type.Equals("Role"))?.Value ?? "";
        var seed = claims.FirstOrDefault(x => x.Type.Equals("Seed"))?.Value ?? "";

        return new (name: name, role: role, seed: seed);
    }

    // referencia: https://www.macoratti.net/22/05/c_nprimos1.htm
    public static bool VerificaNumeroPrimo(int numero)
     => Enumerable.Range(2, (int)Math.Sqrt(numero) - 1)
         .All(divisor => numero % divisor != 0) && numero > 1;

}
