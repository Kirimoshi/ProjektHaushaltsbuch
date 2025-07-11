namespace ProjektHaushaltsbuch.Web.ViewModels;


public class ExpenseDisplayViewModel
    {
        // Basis-Identifikation
        public Guid Id { get; set; }
    
        // Formatierte Anzeige-Werte
        public string FormattedSum { get; set; }        // "19,99 €"
        public string FormattedDate { get; set; }       // "15. März 2024"
        public string Description { get; set; }
        public string? Notes { get; set; }
    
        // Kategorisierung (anzeigefertig)
        public string CategoryName { get; set; }        // Name statt ID
        public string? Subcategory { get; set; }
        public List<string>? Tags { get; set; }
    
        // Zahlungsdetails (anzeigefertig)
        public string PaymentMethodDisplay { get; set; }  // "Kreditkarte", "Bargeld", etc.
        public string? PaymentAccount { get; set; }       // "Visa ***1234"
    
        // Geschäftsausgaben
        public bool IsBusinessExpense { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? Vendor { get; set; }
        public string? Location { get; set; }
    
        // Recurring Status
        public bool IsRecurring { get; set; }
        public string? RecurrenceDisplay { get; set; }    // "Monatlich", "Wöchentlich", etc.
    
        // Attachments
        public bool HasAttachments { get; set; }
        public int AttachmentCount { get; set; }
        public List<string>? AttachmentUrls { get; set; }
    
        // Status
        public bool IsPlanned { get; set; }
        public string StatusDisplay { get; set; }         // "Geplant", "Ausgegeben", etc.
    
        // UI-Flags
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool IsOverdue { get; set; }               // Für geplante Ausgaben
    
        // Zusätzliche Anzeige-Informationen
        public string TimeAgo { get; set; }               // "vor 3 Tagen"
        public string ColorClass { get; set; }            // CSS-Klasse für Kategoriefarbe
        public string IconClass { get; set; }             // CSS-Klasse für Kategorie-Icon
    }