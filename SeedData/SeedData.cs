using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektHaushaltsbuch.Data;
using System;
using System.Linq;
using ProjektHaushaltsbuch.Enums;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.SeedData;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ProjektHaushaltsbuchContext(
            serviceProvider.GetRequiredService<DbContextOptions<ProjektHaushaltsbuchContext>>());
        // Check if already seeded
        if (context.Users.Any() || context.Categories.Any() || context.Budgets.Any() || context.Expenses.Any())
        {
            return;
        }

// Dummy-User anlegen
        var user = new UserModel
        {
            Id = Guid.NewGuid(),
            Name = "Max",
            Surname = "Mustermann",
            Email = "max@example.com"
        };

// Kategorie anlegen
        var category = new CategoryModel
        {
            Id = Guid.NewGuid(),
            Name = "Lebensmittel",
            Icon = "🛒",
            Color = "#4CAF50",
            UserId = user.Id
        };

// Budget anlegen
        var budget = new BudgetModel
        {
            Id = Guid.NewGuid(),
            Name = "Juli Lebensmittelbudget",
            Amount = 300.00M,
            StartDate = new DateTime(2024, 7, 1),
            EndDate = new DateTime(2024, 7, 31),
            CategoryId = category.Id,
            UserId = user.Id
        };

// Zwei Beispiel-Ausgaben
        var expense1 = new ExpenseModel
        {
            Id = Guid.NewGuid(),
            Sum = 25.99M,
            Currency = CurrencyType.EUR,
            Date = new DateTime(2024, 7, 2),
            Description = "Einkauf bei Aldi",
            Notes = "Gemüse, Nudeln, Saft",
            UserId = user.Id,
            CategoryId = category.Id,
            Subcategory = "Supermarkt",
            Tags = new List<string> { "Lebensmittel", "Haushalt" },
            PaymentMethod = PaymentMethod.DebitCard,
            PaymentAccount = "Visa ***4321",
            IsBusinessExpense = false,
            IsRecurring = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            AttachmentUrls = new List<string> { "https://example.com/receipt-aldi.jpg" },
            BudgetId = budget.Id,
            IsPlanned = false
        };

        var expense2 = new ExpenseModel
        {
            Id = Guid.NewGuid(),
            Sum = 14.50M,
            Currency = CurrencyType.EUR,
            Date = new DateTime(2024, 7, 5),
            Description = "Snacks beim Bahnhof",
            Notes = "Reiseproviant",
            UserId = user.Id,
            CategoryId = category.Id,
            Subcategory = "Snacks",
            Tags = new List<string> { "Lebensmittel", "Reise" },
            PaymentMethod = PaymentMethod.Cash,
            PaymentAccount = "Bargeld",
            IsBusinessExpense = false,
            IsRecurring = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            BudgetId = budget.Id,
            IsPlanned = false
        };

// Alles hinzufügen
        context.Users.Add(user);
        context.Categories.Add(category);
        context.Budgets.Add(budget);
        context.Expenses.AddRange(expense1, expense2);

// Speichern
        context.SaveChanges();
    }
}