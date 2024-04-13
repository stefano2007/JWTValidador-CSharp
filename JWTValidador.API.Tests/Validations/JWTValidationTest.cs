using JWTValidador.API.Exceptions;
using JWTValidador.API.Tests.Fixtures;
using JWTValidador.API.Validations;

namespace JWTValidador.API.Tests.Validations;

public class JWTValidationTest
{
    private readonly string MensagemErroTokenInvalido = "Invalid JWT";
    private readonly string MensagemErroNomeContemNumero = "The Name claim cannot have a number character";
    private readonly string MensagemErroEstruturaInvalida = "Invalid token structure should contain only 3 claims(Name, Role and Seed)";
    private readonly string MensagemErroRoleInvalida = "The Role claim must contain only 1 of the three values (Admin, Member, and External)";
    private readonly string MensagemErroSeedNumeroNaoPrimo = "The Seed claim must be a prime number";
    private readonly string MensagemErroNameMaior256 = "The maximum length of the Name claim is 256 characters";

    //Verificar metodo Valid
    [Fact(DisplayName = "Verificar metodo Valid")]
    public void Verificar_Valid()
    {
        //Arrange
        var fnValid2 = () => JWTValidation.Valid(JWTFixtures.JTW_INVALIDO_CASO2);
        var fnValid3 = () => JWTValidation.Valid(JWTFixtures.JTW_INVALIDO_CASO3);
        var fnValid4 = () => JWTValidation.Valid(JWTFixtures.JTW_INVALIDO_CASO4);

        var fnJWTEstruturaInvalida = () => JWTValidation.Valid(JWTFixtures.JTW_INVALIDO_ESTRUTURA_JWT);
        var fnRoleInvalida = () => JWTValidation.Valid(JWTFixtures.JTW_INVALIDO_ROLE_INVALIDA);
        var fnSeedNaoPrimo = () => JWTValidation.Valid(JWTFixtures.JTW_INVALIDO_SEED_NAO_PRIMO);
        var fnNameMaior256 = () => JWTValidation.Valid(JWTFixtures.JTW_INVALIDO_NAME_MAIOR_256);

        //Act e Arrange
        var result = JWTValidation.Valid(JWTFixtures.JTW_VALIDO_CASO1);
        var exception2 = Assert.Throws<InvalidJWTException>(() => fnValid2());
        var exception3 = Assert.Throws<InvalidDomainException>(() => fnValid3());
        var exception4 = Assert.Throws<InvalidStructureException>(() => fnValid4());

        var exceptionJWTEstruturaInvalida = Assert.Throws<InvalidStructureException>(() => fnJWTEstruturaInvalida());
        var exceptionRoleInvalida = Assert.Throws<InvalidDomainException>(() => fnRoleInvalida());
        var exceptionSeedNaoPrimo = Assert.Throws<InvalidDomainException>(() => fnSeedNaoPrimo());
        var exceptionNameMaior256 = Assert.Throws<InvalidDomainException>(() => fnNameMaior256());

        //Assert
        Assert.Equal("verdadeiro", result);
        Assert.Equal(MensagemErroTokenInvalido, exception2.Message);
        Assert.Equal(MensagemErroNomeContemNumero, exception3.Message);
        Assert.Equal(MensagemErroEstruturaInvalida, exception4.Message);

        Assert.Equal(MensagemErroEstruturaInvalida, exceptionJWTEstruturaInvalida.Message);
        Assert.Equal(MensagemErroRoleInvalida, exceptionRoleInvalida.Message);
        Assert.Equal(MensagemErroSeedNumeroNaoPrimo, exceptionSeedNaoPrimo.Message);
        Assert.Equal(MensagemErroNameMaior256, exceptionNameMaior256.Message);
    }

    //Verificar metodo ValidateToken
    [Fact(DisplayName = "Verificar metodo ValidateToken")]
    public void Verificar_ValidateToken()
    {
        //Arrange
        var fnValidateToken = () => JWTValidation.ValidateToken(JWTFixtures.JTW_INVALIDO_CASO2);

        //Act e Arrange
        var jwtValido = JWTValidation.ValidateToken(JWTFixtures.JTW_VALIDO_CASO1);
        var exception = Assert.Throws<InvalidJWTException>(() => fnValidateToken());
        var jwt3 = JWTValidation.ValidateToken(JWTFixtures.JTW_INVALIDO_CASO3);
        var jwt4 = JWTValidation.ValidateToken(JWTFixtures.JTW_INVALIDO_CASO4);

        //Assert
        Assert.Equal("JWT invalido", exception.Message);

        Assert.Equal(3, jwtValido.Claims.Count());
        Assert.Equal(3, jwt3.Claims.Count());
        Assert.Equal(4, jwt4.Claims.Count());
    }

    //Verificar metodo ConvertToken
    [Fact(DisplayName = "Verificar metodo ConvertToken")]
    public void Verificar_ConvertToken()
    {
        //Act e Arrange
        var tokenModel1 = JWTValidation.ConvertToken(JWTFixtures.ClaimsCaso1());
        var tokenModel3 = JWTValidation.ConvertToken(JWTFixtures.ClaimsCaso3());
        var tokenModel4 = JWTValidation.ConvertToken(JWTFixtures.ClaimsCaso4());

        //Assert
        Assert.Equal("Admin", tokenModel1.Role);
        Assert.Equal("7841", tokenModel1.Seed);
        Assert.Equal("Toninho Araujo", tokenModel1.Name);

        Assert.Equal("External", tokenModel3.Role);
        Assert.Equal("88037", tokenModel3.Seed);
        Assert.Equal("M4ria Olivia", tokenModel3.Name);

        Assert.Equal("Member", tokenModel4.Role);
        Assert.Equal("14627", tokenModel4.Seed);
        Assert.Equal("Valdir Aranha", tokenModel4.Name);
    }

    //Verificar metodo VerificaNumeroPrimo
    [Fact(DisplayName = "Verificar metodo VerificaNumeroPrimo")]
    public void Verificar_VerificaNumeroPrimo()
    {
        //Act
        int[] numeroPrimos = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97];
        int[] numeroNaoPrimos = [1, 4, 6 ,8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27, 28, 30, 32, 33, 34, 35, 36];        

        //Arrange
        var todosPrimos = numeroPrimos.All(n => JWTValidation.VerificaNumeroPrimo(n));
        var todosNaoPrimos = numeroNaoPrimos.All(n => !JWTValidation.VerificaNumeroPrimo(n));

        //Assert
        Assert.True(todosPrimos);
        Assert.True(todosNaoPrimos);
    }
}
