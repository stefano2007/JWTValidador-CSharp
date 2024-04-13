using System.Security.Claims;

namespace JWTValidador.API.Tests.Fixtures;
public class JWTFixtures
{
    public static readonly string JTW_VALIDO_CASO1 = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg";
    public static readonly string JTW_INVALIDO_CASO2 = "eyJhbGciOiJzI1NiJ9.dfsdfsfryJSr2xrIjoiQWRtaW4iLCJTZrkIjoiNzg0MSIsIk5hbrUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05fsdfsIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg";
    public static readonly string JTW_INVALIDO_CASO3 = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiRXh0ZXJuYWwiLCJTZWVkIjoiODgwMzciLCJOYW1lIjoiTTRyaWEgT2xpdmlhIn0.6YD73XWZYQSSMDf6H0i3-kylz1-TY_Yt6h1cV2Ku-Qs";
    public static readonly string JTW_INVALIDO_CASO4 = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWVtYmVyIiwiT3JnIjoiQlIiLCJTZWVkIjoiMTQ2MjciLCJOYW1lIjoiVmFsZGlyIEFyYW5oYSJ9.cmrXV_Flm5mfdpfNUVopY_I2zeJUy4EZ4i3Fea98zvY";

    public static IEnumerable<Claim> ClaimsCaso1()
    {
        return [
            new Claim(type: "Role", value: "Admin"),
            new Claim(type: "Seed", value: "7841"),
            new Claim(type: "Name", value: "Toninho Araujo")
        ];
    }
    public static IEnumerable<Claim> ClaimsCaso3()
    {
        return [
            new Claim(type: "Role", value: "External"),
            new Claim(type: "Seed", value: "88037"),
            new Claim(type: "Name", value: "M4ria Olivia")
        ];
    }
    public static IEnumerable<Claim> ClaimsCaso4()
    {
        return [
            new Claim(type: "Role", value: "Member"),
            new Claim(type: "Org", value: "88037"),
            new Claim(type: "Seed", value: "14627"),
            new Claim(type: "Name", value: "Valdir Aranha")
        ];
    }
}
