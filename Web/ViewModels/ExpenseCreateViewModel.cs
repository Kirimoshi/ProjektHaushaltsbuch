using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektHaushaltsbuch.Enums;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Web.ViewModels;

public class ExpenseCreateViewModel
{
    public Guid Id { get; set; }
    // Basis-Identifikation
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Sum must be greater than 0.01")]
    public decimal Sum { get; set; }
    [Required(ErrorMessage = "Please choose a currency")]
    public CurrencyType Currency { get; set; } = CurrencyType.EUR;
    public DateTime Date { get; set; } = DateTime.Today;
    
    // Basis-Erweiterungen
    [Required]
    [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    public string Description { get; set; }
    [MaxLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
    public string? Notes { get; set; }
    
    // Erweiterte Kategorisierung
    [Required]
    public Guid CategoryId { get; set; }
    public List<CategoryModel> AvailableCategories { get; set; } = CategoryDefaults.GetDefaultCategories();
    public List<SelectListItem> CategorySelectList => AvailableCategories.Select(c => new SelectListItem
    {
        Value = c.Id.ToString(),
        Text = $"{c.Icon} {c.Name}",
        Selected = c.Id == CategoryId
    }).ToList();
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