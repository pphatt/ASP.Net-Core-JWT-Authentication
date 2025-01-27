using Server.Application.Common.Interfaces.Authentication;
using Server.Application.Common.Interfaces.Repositories;
using Server.Domain.Entity.Identity;

namespace Server.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);

        if (user is null)
        {
            throw new Exception("User with given email is not exists.");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("Email is already taken.");
        }

        var user = new AppUsers 
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };


        _userRepository.AddUser(user);

        var accessToken = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, accessToken);
    }
}
