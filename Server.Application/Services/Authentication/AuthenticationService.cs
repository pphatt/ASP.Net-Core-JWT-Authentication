namespace Server.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "FirstName", "LastName", Email, "Access Token");
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), FirstName, LastName, Email, "Access Token");
    }
}
