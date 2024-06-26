﻿using System.Security.Claims;

namespace JWTValidador.API.Tests.Fixtures;
public class JWTFixtures
{
    public static readonly string JTW_VALIDO_CASO1 = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg";
    public static readonly string JTW_INVALIDO_CASO2 = "eyJhbGciOiJzI1NiJ9.dfsdfsfryJSr2xrIjoiQWRtaW4iLCJTZrkIjoiNzg0MSIsIk5hbrUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05fsdfsIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg";
    public static readonly string JTW_INVALIDO_CASO3 = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiRXh0ZXJuYWwiLCJTZWVkIjoiODgwMzciLCJOYW1lIjoiTTRyaWEgT2xpdmlhIn0.6YD73XWZYQSSMDf6H0i3-kylz1-TY_Yt6h1cV2Ku-Qs";
    public static readonly string JTW_INVALIDO_CASO4 = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWVtYmVyIiwiT3JnIjoiQlIiLCJTZWVkIjoiMTQ2MjciLCJOYW1lIjoiVmFsZGlyIEFyYW5oYSJ9.cmrXV_Flm5mfdpfNUVopY_I2zeJUy4EZ4i3Fea98zvY";

    public static readonly string JTW_INVALIDO_ESTRUTURA_JWT  = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWVtYmVyIiwiT3JnIjoiQlIiLCJOYW1lIjoiVmFsZGlyIEFyYW5oYSJ9.lwz1zXZfBeQNTfewDvx5Q2gcoqh6zty6as1SIWGt1Uo";
    public static readonly string JTW_INVALIDO_ROLE_INVALIDA = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWFzdGVyIiwiU2VlZCI6Ijc4NDEiLCJOYW1lIjoiVG9uaW5obyBBcmF1am8ifQ.XlAe6TsA-zV_Pt0pwltqvjYM_IHQjbxTEsO9BYn5Udw";
    public static readonly string JTW_INVALIDO_SEED_NAO_PRIMO = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiOTkyIiwiTmFtZSI6IlRvbmluaG8gQXJhdWpvIn0.-fp2vopahPuAf3muHeOvB_bpD-qF06-ZYHjf6k9ZIvs";
    public static readonly string JTW_INVALIDO_NAME_MAIOR_256 = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJMb3JlbSBJcHN1bSDDqSBzaW1wbGVzbWVudGUgdW1hIHNpbXVsYcOnw6NvIGRlIHRleHRvIGRhIGluZMO6c3RyaWEgdGlwb2dyw6FmaWNhIGUgZGUgaW1wcmVzc29zLCBlIHZlbSBzZW5kbyB1dGlsaXphZG8gZGVzZGUgbyBzw6ljdWxvIFhWSSwgcXVhbmRvIHVtIGltcHJlc3NvciBkZXNjb25oZWNpZG8gcGVnb3UgdW1hIGJhbmRlamEgZGUgdGlwb3MgZSBvcyBlbWJhcmFsaG91IHBhcmEgZmF6ZXIgdW0gbGl2cm8gZGUgbW9kZWxvcyBkZSB0aXBvcy4gTG9yZW0gSXBzdW0gc29icmV2aXZldSBuw6NvIHPDsyBhIGNpbmNvIHPDqWN1bG9zLi4uIn0.uMN-V_gbaj7u3js5aVLCvKKP1opfv0Q8fFktgJGk2Zk";

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
            new Claim(type: "Org", value: "BR"),
            new Claim(type: "Seed", value: "14627"),
            new Claim(type: "Name", value: "Valdir Aranha")
        ];
    }
    public static IEnumerable<Claim> ClaimsJWTEstruturaInvalida()
    {
        return [
            new Claim(type: "Role", value: "Member"),
            new Claim(type: "Org", value: "BR"),
            new Claim(type: "Name", value: "Valdir Aranha")
        ];
    }

    public static IEnumerable<Claim> ClaimsRoleInvalida()
    {
        return [
            new Claim(type: "Role", value: "Master"),
            new Claim(type: "Seed", value: "7841"),
            new Claim(type: "Name", value: "Toninho Araujo")
        ];
    }

    public static IEnumerable<Claim> ClaimsSeedNaoPrimo()
    {
        return [
            new Claim(type: "Role", value: "Admin"),
            new Claim(type: "Seed", value: "992"),
            new Claim(type: "Name", value: "Toninho Araujo")
        ];
    }
    public static IEnumerable<Claim> ClaimsNameMaior256()
    {
        return [
            new Claim(type: "Role", value: "Admin"),
            new Claim(type: "Seed", value: "7841"),
            new Claim(type: "Name", value: "Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja de tipos e os embaralhou para fazer um livro de modelos de tipos. Lorem Ipsum sobreviveu não só a cinco séculos...")
        ];
    }
}