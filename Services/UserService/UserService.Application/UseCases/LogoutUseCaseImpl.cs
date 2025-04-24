using System.Security.Claims;
using UserService.Application.Ports.Inbound;
using UserService.Application.Ports.Outbound;
using UserService.Domain.Repositories;
using UserService.Shared.Exceptions;

namespace UserService.Application.UseCases;

public class LogoutUseCaseImpl : ILogoutUseCase
{
    private readonly ICookieService _cookieService;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public LogoutUseCaseImpl(ICookieService cookieService, IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _cookieService = cookieService;
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task Execute(string token)
    {
        string? userId = _jwtTokenService.GetUserId(token);

        if (userId == null)
        {
            throw new InvalidJwtTokenException("Invalid token");
        }
        
        await _userRepository.UpdateUserLastLogin(userId);
        _cookieService.DeleteCookie(token);
    }
}