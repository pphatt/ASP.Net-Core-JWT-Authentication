using Server.Application.Common.Interfaces.Authentication;

namespace Server.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "FirstName", "LastName", Email, "Access Token");
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        Guid userId = Guid.NewGuid();

        var accessToken = _jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);

        return new AuthenticationResult(userId, FirstName, LastName, Email, accessToken);
    }
}
