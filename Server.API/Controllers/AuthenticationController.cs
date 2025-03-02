﻿using Microsoft.AspNetCore.Mvc;
using Server.Application.Services.Authentication;
using Server.Contracts.Authentication;

namespace Server.API.Controllers;

[ApiController]
[Route("/authentication")]
public class AuthenticationController : ControllerBase
{
    IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authenticationResult = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            authenticationResult.user.Id, 
            authenticationResult.user.FirstName, 
            authenticationResult.user.LastName, 
            authenticationResult.user.Email, 
            authenticationResult.AccessToken
        );

        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authenticationResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var response = new AuthenticationResponse(
            authenticationResult.user.Id,
            authenticationResult.user.FirstName,
            authenticationResult.user.LastName,
            authenticationResult.user.Email,
            authenticationResult.AccessToken
        );

        return Ok(response);
    }
}
