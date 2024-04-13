using JWTValidador.API.Enumerators;

namespace JWTValidador.API.Exceptions;

public class InvalidJWTException : BaseException
{
    public InvalidJWTException(string error) 
        : base(error, tipoExcecao: TipoExcecao.INVALID_JWT)
    { }
}
