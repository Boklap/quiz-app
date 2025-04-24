using UserService.Domain.Repositories;
using UserService.Domain.Services.Interfaces;

namespace UserService.Domain.Services.Impl;

public class UserUniqueCheckerImpl : IUserUniqueChecker
{
    private readonly IUserRepository _userRepository;

    public UserUniqueCheckerImpl(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> IsUserUnique(string email)
    {
        var user = await _userRepository.FindUserByEmail(email);
        return user == null;
    }
}