namespace UserService.Domain.Entities;

public class UserRole
{
    public string UserId { get; set; }
    public string RoleId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
    
    public UserRole() {}

    public UserRole(string userId, string roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}