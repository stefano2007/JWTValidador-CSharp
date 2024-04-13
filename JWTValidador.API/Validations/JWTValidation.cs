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
            throw new InvalidJWTException("Estrutura do token invalido deve conter apenas 3 claims(Name, Role e Seed)");
        }

        var jwtTokenModel = jwtToken.Claims.ConvertToken();
        var hasNumber = new Regex(@"[0-9]");
        if (hasNumber.IsMatch(jwtTokenModel.Name))
        {
            throw new InvalidDomainException("A claim Name nao pode ter caracter de numeros");
        }

        if (!RolesValidas.Any(r => jwtTokenModel.Role.Equals(r)))
        {
            throw new InvalidDomainException("A claim Role deve conter apenas 1 dos três valores (Admin, Member e External)");
        }

        bool isPrimo = int.TryParse(jwtTokenModel.Seed, out int seed)
                && VerificaNumeroPrimo(seed);

        if (!isPrimo)
        {
            throw new InvalidDomainException("A claim Seed deve ser um numero primo");
        }

        if (jwtTokenModel.Name.Length > 256)
        {
            throw new InvalidDomainException("O tamanho maximo da claim Name e de 256 caracteres");
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
            throw new InvalidJWTException("JWT invalido");
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
