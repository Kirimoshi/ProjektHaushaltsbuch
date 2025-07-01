using System.ComponentModel.DataAnnotations;

namespace ProjektHaushaltsbuch.Models;

public class UserModel
{
    public required Guid Id { get; init; }
    public required string Name { get; set; }
    public string? Surname { get; set; }
    // [EmailAddress]
    // public EmailAddressAttribute Email { get; set; }

    public string Email { get; set; }
    public List<ExpenseModel> Expenses { get; set; } = new();
    public List<BudgetModel> Budgets { get; set; } = new();
    
}