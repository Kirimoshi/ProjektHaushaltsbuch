using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Data.Configurations;

public class BudgetConfiguration: IEntityTypeConfiguration<BudgetModel>
{
    public void Configure(EntityTypeBuilder<BudgetModel> builder)
    {
        builder
            .HasOne(b => b.User)
            .WithMany(u => u.Budgets)
            .HasForeignKey(b => b.UserId);
        builder
            .Property(b => b.Amount)
            .HasPrecision(19, 4);
    }
}