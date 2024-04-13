using JWTValidador.API.Enumerators;

namespace JWTValidador.API.Exceptions;

public class InvalidDomainException : BaseException
{
    public InvalidDomainException(string error)
        : base(error, tipoExcecao: TipoExcecao.INVALID_DOMAIN)
    { }
}
