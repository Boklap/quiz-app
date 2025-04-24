using UserService.Application.Dtos;
using UserService.Application.Ports.Inbound;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;
using UserService.Domain.Services;
using UserService.Domain.Services.Interfaces;
using UserService.Shared.Exceptions;

namespace UserService.Application.UseCases;

public class RegisterUseCaseImpl : IRegisterUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly UserFactory _userFactory;
    private readonly IUserUniqueChecker _userUniqueChecker;
    
    public RegisterUseCaseImpl(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        UserFactory userFactory, 
        IUserUniqueChecker userUniqueChecker)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userFactory = userFactory;
        _userUniqueChecker = userUniqueChecker;
    }

    public async Task Execute(RegisterDto registerDto)
    {
        if (!await IsUserUnique(registerDto.Email))
        {
            throw new UserExistException("User already exist");
        }
        
        User user = await CreateUser(registerDto);

        await RegisterUser(user);
    }

    public async Task<bool> IsUserUnique(string email)
    {
        return await _userUniqueChecker.IsUserUnique(email);
    }

    public async Task<User> CreateUser(RegisterDto registerDto)
    {
        User user = _userFactory.CreateUser(
            registerDto.Username,
            registerDto.Email,
            registerDto.Password,
            registerDto.Dob
        );

        Role? role = await _roleRepository.FindRoleById("7");

        if (role == null)
        {
            throw new InvalidAttributeException("Role is not found");
        }
        
        UserRole userRole = new UserRole(user.Id,  role.Id);
        
        userRole.Role = role;
        user.UserRoles.Add(userRole);
        
        return user;
    }

    public async Task RegisterUser(User user)
    {
        await _userRepository.InsertUser(user);
    }
}