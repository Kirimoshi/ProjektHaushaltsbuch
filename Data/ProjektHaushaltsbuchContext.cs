using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Data
{
    public class ProjektHaushaltsbuchContext(DbContextOptions<ProjektHaushaltsbuchContext> options) : DbContext(options)
    {
        public DbSet<ExpenseModel> Expenses { get; set; }
        public DbSet<BudgetModel> Budgets { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignore DisplayFormatAttribute if it's being picked up
            // modelBuilder.Ignore<System.ComponentModel.DataAnnotations.DisplayFormatAttribute>();
            
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<ExpenseModel>()
                .HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<ExpenseModel>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BudgetModel>()
                .HasOne(b => b.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId);
            
            // Property configuration
            modelBuilder.Entity<UserModel>(entity =>
            {
                // Name: Required, MinLength(3), MaxLength(25)
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(25);
        
                entity.HasCheckConstraint("CK_UserModel_Name_MinLength", 
                    "LEN([Name]) >= 3");
        
                // Surname: MinLength(3), MaxLength(25), nullable
                entity.Property(u => u.Surname)
                    .HasMaxLength(25);
        
                entity.HasCheckConstraint("CK_UserModel_Surname_MinLength", 
                    "([Surname] IS NULL OR LEN([Surname]) >= 3)");
        
                // Email: Required
                entity.Property(u => u.Email)
                    .IsRequired();
            });



            modelBuilder.Entity<ExpenseModel>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<ExpenseModel>()
                .Property(e => e.Sum)
                .HasPrecision(19, 4);
            
            modelBuilder.Entity<BudgetModel>()
                .Property(b => b.Amount)
                .HasPrecision(19, 4);
            
            // Indexes for performance
            modelBuilder.Entity<ExpenseModel>()
                .HasIndex(e => e.CategoryId);
            modelBuilder.Entity<ExpenseModel>()
                .HasIndex(e => e.UserId);
            modelBuilder.Entity<ExpenseModel>()
                .HasIndex(e => e.Date);
            modelBuilder.Entity<ExpenseModel>()
                .HasIndex(e => e.BudgetId);
            
            // Composite indexes
            modelBuilder.Entity<ExpenseModel>()
                .HasIndex(e => new { e.UserId, e.Date });
            modelBuilder.Entity<ExpenseModel>()
                .HasIndex(e => new { e.UserId, e.Date, e.CategoryId });



        }
    }
}
