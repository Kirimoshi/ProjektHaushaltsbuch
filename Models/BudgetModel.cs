namespace ProjektHaushaltsbuch.Models;

public class BudgetModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}