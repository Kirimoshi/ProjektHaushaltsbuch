using System.ComponentModel.DataAnnotations;
using ProjektHaushaltsbuch.Enums;

namespace ProjektHaushaltsbuch.Web.ViewModels;

public class ExpenseCreateViewModel
{
    public Guid Id { get; set; }
    // Basis-Identifikation
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Sum must be greater than 0.01")]
    public decimal Sum { get; set; }
    public CurrencyType Currency { get; set; } = CurrencyType.EUR;
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;
    
    // Basis-Erweiterungen
    [Required]
    [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    public string Description { get; set; }
    [MaxLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
    public string? Notes { get; set; }
    
    // Erweiterte Kategorisierung
    [Required]
    public Guid CategoryId { get; set; }
    [MaxLength(100, ErrorMessage = "Subcategory cannot exceed 100 characters")]
    public string? Subcategory { get; set; }
    public List<string>? Tags { get; set; }
    
    // Zahlungsdetails
    public PaymentMethod PaymentMethod { get; set; }
    [MaxLength(100)]
    public string? PaymentAccount { get; set; }  // "Visa ***1234", "Cash", etc.
    
    // Geschäftsausgaben
    public bool IsBusinessExpense { get; set; }
    [MaxLength(50, ErrorMessage = "Receipt number cannot exceed 50 characters")]
    public string? ReceiptNumber { get; set; }
    [MaxLength(100, ErrorMessage = "Vendor cannot exceed 100 characters")]
    public string? Vendor { get; set; }
    [MaxLength(100, ErrorMessage = "Location cannot exceed 100 characters")]
    public string? Location { get; set; }
    
    // Recurring Expenses
    public bool IsRecurring { get; set; }
    public RecurrencePattern? RecurrencePattern { get; set; }
    
    // Attachments
    public List<string>? AttachmentUrls { get; set; }  // Receipts, photos
    
    // Budgeting
    public Guid? BudgetId { get; set; }
    public bool IsPlanned { get; set; }  // Geplant vs. tatsächlich ausgegeben
}