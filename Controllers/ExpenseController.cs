using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektHaushaltsbuch.Data;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Controllers
{
    public class ExpenseController(ProjektHaushaltsbuchContext context) : Controller
    {
        // GET: Expense
        public async Task<IActionResult> Index()
        {
            var projektHaushaltsbuchContext = context.Expenses.Include(e => e.Category);
            return View(await projektHaushaltsbuchContext.ToListAsync());
        }

        // GET: Expense/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseModel = await context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            return View(expenseModel);
        }

        // GET: Expense/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(context.Set<CategoryModel>(), "Id", "Id");
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sum,Currency,Date,Description,Notes,UserId,CategoryId,Subcategory,Tags,PaymentMethod,PaymentAccount,IsBusinessExpense,ReceiptNumber,Vendor,Location,IsRecurring,RecurrencePattern,ParentRecurringExpenseId,CreatedAt,UpdatedAt,IsDeleted,AttachmentUrls,BudgetId,IsPlanned")] ExpenseModel expenseModel)
        {
            if (ModelState.IsValid)
            {
                expenseModel.Id = Guid.NewGuid();
                context.Add(expenseModel);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(context.Set<CategoryModel>(), "Id", "Id", expenseModel.CategoryId);
            return View(expenseModel);
        }

        // GET: Expense/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseModel = await context.Expenses.FindAsync(id);
            if (expenseModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(context.Set<CategoryModel>(), "Id", "Id", expenseModel.CategoryId);
            return View(expenseModel);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Sum,Currency,Date,Description,Notes,UserId,CategoryId,Subcategory,Tags,PaymentMethod,PaymentAccount,IsBusinessExpense,ReceiptNumber,Vendor,Location,IsRecurring,RecurrencePattern,ParentRecurringExpenseId,CreatedAt,UpdatedAt,IsDeleted,AttachmentUrls,BudgetId,IsPlanned")] ExpenseModel expenseModel)
        {
            if (id != expenseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(expenseModel);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseModelExists(expenseModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(context.Set<CategoryModel>(), "Id", "Id", expenseModel.CategoryId);
            return View(expenseModel);
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseModel = await context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            return View(expenseModel);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var expenseModel = await context.Expenses.FindAsync(id);
            if (expenseModel != null)
            {
                context.Expenses.Remove(expenseModel);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseModelExists(Guid id)
        {
            return context.Expenses.Any(e => e.Id == id);
        }
    }
}
