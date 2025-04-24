using UserService.Domain.ValueObjects.User;

namespace UserService.Domain.Entities;

public class User
{
    public string Id { get; set; }
    public Username Username { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    public Dob Dob { get; set; }
    public Description Description { get; set; }
    public int TotalTest { get; set; }
    public int TotalTestPassed { get; set; }
    public int TotalTestFailed { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime LastLoginAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public DateTime? DeletedAt { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    
    public User() {}
    
    public User(
        string id,
        Username username,
        Email email,
        Password password,
        Dob dob,
        Description? description = null,
        int totalTest = 0,
        int totalTestPassed = 0,
        int totalTestFailed = 0,
        bool isDeleted = false,
        DateTime? lastLoginAt = null,
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        DateTime? deletedAt = null)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        Dob = dob;
        Description = description ?? new Description(string.Empty);
        TotalTest = totalTest;
        TotalTestPassed = totalTestPassed;
        TotalTestFailed = totalTestFailed;
        IsDeleted = isDeleted;
        LastLoginAt = lastLoginAt ?? DateTime.MinValue;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
        DeletedAt = deletedAt ?? DateTime.MinValue;
    }
}