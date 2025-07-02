using System.ComponentModel.DataAnnotations;

namespace ProjektHaushaltsbuch.Models;

public class UserModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Surname { get; set; }
    public required string Email { get; set; }
        
    // Navigation properties
    public List<ExpenseModel> Expenses { get; set; } = new();
    public List<BudgetModel> Budgets { get; set; } = new();
        
    // Business logic
    public string FullName => $"{Name} {Surname}".Trim();
    public string NormalizedEmail => Email.ToUpperInvariant();
    
}