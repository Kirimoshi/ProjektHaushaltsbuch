using System.ComponentModel.DataAnnotations;
using ProjektHaushaltsbuch.Enums;

namespace ProjektHaushaltsbuch.Models;

public class ExpenseModel
{
    public Guid Id { get; set; }
    public decimal Sum { get; set; }
    public CurrencyType Currency { get; set; }
    public DateTime Date { get; set; }
    
    // Basis-Erweiterungen
    public string Description { get; set; }
    public string? Notes { get; set; }
    
    // Benutzer-Zuordnung
    public Guid UserId { get; set; }
    
    // Erweiterte Kategorisierung
    // Foreign Key
    public Guid CategoryId { get; set; }
    public string? Subcategory { get; set; }
    public List<string>? Tags { get; set; }
    
    // Navigation Property
    public CategoryModel Category { get; set; }
    
    // Zahlungsdetails
    public PaymentMethod PaymentMethod { get; set; }
    public string? PaymentAccount { get; set; }  // "Visa ***1234", "Cash", etc.
    
    // Geschäftsausgaben
    public bool IsBusinessExpense { get; set; }
    public string? ReceiptNumber { get; set; }
    public string? Vendor { get; set; }
    public string? Location { get; set; }
    
    // Recurring Expenses
    public bool IsRecurring { get; set; }
    public RecurrencePattern? RecurrencePattern { get; set; }
    public Guid? ParentRecurringExpenseId { get; set; } // original such an expense that preceded all others
    
    // Metadaten
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }  // Soft delete
    
    // Attachments
    public List<string>? AttachmentUrls { get; set; }  // Receipts, photos
    
    // Budgeting
    public Guid? BudgetId { get; set; }
    public bool IsPlanned { get; set; }  // Geplant vs. tatsächlich ausgegeben
}