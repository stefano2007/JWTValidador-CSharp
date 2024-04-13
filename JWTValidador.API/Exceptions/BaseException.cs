using JWTValidador.API.Enumerators;

namespace JWTValidador.API.Exceptions;

public abstract class BaseException : Exception
{
    public BaseException(string error, TipoExcecao tipoExcecao) : base(error)
    {
        TipoExcecao = tipoExcecao;
    }
    public TipoExcecao TipoExcecao { get; private set; }
}
