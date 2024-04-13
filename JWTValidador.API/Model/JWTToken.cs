namespace JWTValidador.API.Model;
public class JWTToken
{
    public JWTToken(string jWT)
    {
        JWT = jWT;
        
    }
    public string JWT { get; private set; }
}
