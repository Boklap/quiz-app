using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> user)
    {
        user.HasKey(u => u.Id);

        user.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        
        user.OwnsOne(u => u.Username, username =>
        {
            username.Property(u => u.Value)
                .HasColumnName("Username")
                .HasMaxLength(255)
                .IsRequired();
        });
        
        user.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(255)
                .IsRequired();
        });

        user.OwnsOne(u => u.Password, password =>
        {
            password.Property(p => p.Value)
                .HasColumnName("Password")
                .IsRequired();
        });

        user.OwnsOne(u => u.Dob, dob =>
        {
            dob.Property(d => d.Value)
                .HasColumnName("DOB")
                .IsRequired();
        });

        user.OwnsOne(u => u.Description, description =>
        {
            description.Property(d => d.Value).
                HasColumnName("Description")
                .HasMaxLength(2000)
                .IsRequired();
        });
        
        user.Property(u => u.TotalTest).IsRequired();
        user.Property(u => u.TotalTestPassed).IsRequired();
        user.Property(u => u.TotalTestFailed).IsRequired();
        user.Property(u => u.IsDeleted).IsRequired();
        user.Property(u => u.LastLoginAt).IsRequired();
        user.Property(u => u.CreatedAt).IsRequired();
        user.Property(u => u.UpdatedAt).IsRequired();
        user.Property(u => u.DeletedAt).IsRequired(false);
    }
}