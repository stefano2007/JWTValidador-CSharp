namespace JWTValidador.API.Model;
public class JWTTokenModel
{
    public JWTTokenModel(string name, string role, string seed)
    {
        Name = name;
        Role = role;
        Seed = seed;
    }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Seed { get; set; }
}
