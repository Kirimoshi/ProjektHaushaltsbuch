using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        // Primary Key
        builder.HasKey(u => u.Id);
        // Name: Required, MinLength(3), MaxLength(25)
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(25);

        builder.HasCheckConstraint("CK_UserModel_Name_MinLength", 
            "LEN([Name]) >= 3");

        // Surname: MinLength(3), MaxLength(25), nullable
        builder.Property(u => u.Surname)
            .HasMaxLength(25);

        builder.HasCheckConstraint("CK_UserModel_Surname_MinLength", 
            "([Surname] IS NULL OR LEN([Surname]) >= 3)");

        // Email: Required, Unique
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);
                   
        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_Users_Email");
    }
}