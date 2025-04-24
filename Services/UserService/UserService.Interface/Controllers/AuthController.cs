using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using UserService.Application.Dtos;
using UserService.Application.Ports.Inbound;

namespace UserService.Interface.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IRegisterUseCase _registerUseCase;
    private readonly ILoginUseCase _loginUseCase;
    private readonly ILogoutUseCase _logoutUseCase;

    public AuthController(
        IRegisterUseCase registerUseCase, 
        ILoginUseCase loginUseCase, 
        ILogoutUseCase logoutUseCase)
    {
        _registerUseCase = registerUseCase;
        _loginUseCase = loginUseCase;
        _logoutUseCase = logoutUseCase;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        await _registerUseCase.Execute(registerDto);
        return Ok(new { messsage = "User registered" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        await _loginUseCase.Execute(loginDto);
        return Ok(new { messsage = "User logged in" });
    }

    [HttpPost("logout")]
    public IActionResult Logout(string token)
    {
        _logoutUseCase.Execute(token);
        return Ok(new { messsage = "User logged out" });
    }
    
    
}