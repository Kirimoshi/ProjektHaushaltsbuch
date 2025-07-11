using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektHaushaltsbuch.Models;
using ProjektHaushaltsbuch.Web.ViewModels;

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
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjektHaushaltsbuchContext).Assembly);
        }
        public DbSet<ProjektHaushaltsbuch.Web.ViewModels.ExpenseDisplayViewModel> ExpenseDisplayViewModel { get; set; } = default!;
    }
}
