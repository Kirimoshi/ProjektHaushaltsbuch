using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Data.Configurations;

public class ExpenseConfiguration: IEntityTypeConfiguration<ExpenseModel>
{
    public void Configure(EntityTypeBuilder<ExpenseModel> builder)
    {
        builder
            .HasOne(e => e.User)
            .WithMany(u => u.Expenses)
            .HasForeignKey(e => e.UserId);

        builder
            .HasOne(e => e.Category)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        // Property configuration
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");
        builder
            .Property(e => e.Sum)
            .HasPrecision(19, 4);
        // Indexes for performance
        builder
            .HasIndex(e => e.CategoryId);
        builder
            .HasIndex(e => e.UserId);
        builder
            .HasIndex(e => e.Date);
        builder
            .HasIndex(e => e.BudgetId);
        // Composite indexes
        builder
            .HasIndex(e => new { e.UserId, e.Date });
        builder
            .HasIndex(e => new { e.UserId, e.Date, e.CategoryId });
    }
}