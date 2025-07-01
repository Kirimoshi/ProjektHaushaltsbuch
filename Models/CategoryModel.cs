namespace ProjektHaushaltsbuch.Models;

public class CategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public Guid UserId { get; set; }
    
    public List<ExpenseModel> Expenses { get; set; } = new();
}