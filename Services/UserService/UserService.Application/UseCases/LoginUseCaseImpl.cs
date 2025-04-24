using UserService.Application.Dtos;
using UserService.Application.Ports.Inbound;
using UserService.Application.Ports.Outbound;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;
using UserService.Domain.Services.Interfaces;
using UserService.Shared.Exceptions;

namespace UserService.Application.UseCases;

public class LoginUseCaseImpl : ILoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ICookieService _cookieService;
    private readonly string? _cookieKey;

    public LoginUseCaseImpl(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService,
        IPasswordHasher passwordHasher,
        ICookieService cookieService)
    {
        _cookieKey = Environment.GetEnvironmentVariable("COOKIE_KEY");
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
        _cookieService = cookieService;
    }
    
    public async Task Execute(LoginDto loginDto)
    {
        if (_cookieKey == null)
        {
            throw new EnvVariableEmptyException("Cookie key env is empty");
        }
        
        var user = await GetUserByEmail(loginDto.Email);
        if (user == null || !ValidateCredentials(loginDto.Password, user.Password.Value))
        {
            throw new InvalidCredentialException("Invalid credentials");
        }

        string token = GenerateJwtToken(user);
        _cookieService.SetCookie(_cookieKey, token, DateTime.Now.AddDays(7));
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _userRepository.FindUserByEmail(email);
    }

    public bool ValidateCredentials(string dtoPassword, string userPassword)
    {
        return _passwordHasher.Verify(dtoPassword, userPassword);
    }

    public string GenerateJwtToken(User user)
    {
        return _jwtTokenService.GenerateToken(user);
    }
}