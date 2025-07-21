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

public static class CategoryDefaults
{
    public static List<CategoryModel> GetDefaultCategories()
    {
        return new List<CategoryModel>
        {
            new CategoryModel { Id = Guid.NewGuid(), Name = "Lebensmittel", Icon = "🛒", Color = "#4CAF50" },
            new CategoryModel { Id = Guid.NewGuid(), Name = "Transport", Icon = "🚗", Color = "#2196F3" },
            new CategoryModel { Id = Guid.NewGuid(), Name = "Wohnen", Icon = "🏠", Color = "#FF9800" },
            new CategoryModel { Id = Guid.NewGuid(), Name = "Gesundheit", Icon = "⚕️", Color = "#F44336" },
            new CategoryModel { Id = Guid.NewGuid(), Name = "Unterhaltung", Icon = "🎮", Color = "#9C27B0" },
            new CategoryModel { Id = Guid.NewGuid(), Name = "Bildung", Icon = "📚", Color = "#607D8B" },
            new CategoryModel { Id = Guid.NewGuid(), Name = "Kleidung", Icon = "👕", Color = "#E91E63" },
            new CategoryModel { Id = Guid.NewGuid(), Name = "Sonstiges", Icon = "📋", Color = "#795548" }
        };
    }

    public static CategoryModel GetDefaultCategory()
    {
        return GetDefaultCategories().First();
    }
}