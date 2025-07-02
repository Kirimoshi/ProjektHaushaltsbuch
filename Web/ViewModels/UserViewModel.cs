using System.ComponentModel.DataAnnotations;

namespace ProjektHaushaltsbuch.Web.ViewModels;

public class UserViewModel
{
    public Guid Id { get; init; }
        
    [Required(ErrorMessage = "Name is required")]
    [StringLength(25, ErrorMessage = "Name cannot exceed 25 characters")]
    //TODO Add minimal length handling
    public string Name { get; set; }
        
    [StringLength(25, ErrorMessage = "Surname cannot exceed 25 characters")]
    //TODO Add minimal length handling
    public string? Surname { get; set; }
        
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters")]
    public string Email { get; set; }
        
    [Display(Name = "Full Name")]
    public string FullName => $"{Name} {Surname}".Trim();
        
    public int TotalExpenses { get; set; }
    public int TotalBudgets { get; set; }
}