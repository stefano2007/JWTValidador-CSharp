using JWTValidador.API.Enumerators;

namespace JWTValidador.API.Exceptions;
public class InvalidStructureException : BaseException
{
    public InvalidStructureException(string error)
        : base(error, tipoExcecao: TipoExcecao.INVALID_STRUCTURE)
    { }
}
