namespace MemeSafe.Authentication.AspNetCore;

public class JwtOptions
{
    public string Issuer { get; } = null!;
    public string Audience { get; } = null!;
    public string Key { get; } = null!;
}
