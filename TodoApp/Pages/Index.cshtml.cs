using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Pages;

public class IndexModel(AppDbContext db) : PageModel
{
    public List<TodoItem> TodoItems { get; set; } = [];

    [BindProperty]
    public TodoItem NewTodo { get; set; } = new();

    public async Task OnGetAsync()
    {
        TodoItems = await db.TodoItems
            .OrderBy(t => t.IsDone)
            .ThenByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!string.IsNullOrWhiteSpace(NewTodo.Title))
        {
            db.TodoItems.Add(NewTodo);
            await db.SaveChangesAsync();
        }

        TempData["Toast"] = "Задача додана";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostToggleAsync(int id)
    {
        var item = await db.TodoItems.FindAsync(id);
        if (item == null) return NotFound();

        item.IsDone = !item.IsDone;
        item.CompletedAt = item.IsDone ? DateTime.UtcNow : (DateTime?)null;

        await db.SaveChangesAsync();
        TempData["Toast"] = item.IsDone ? "Задача виконана" : "Задача відновлена";

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var todo = await db.TodoItems.FindAsync(id);
        if (todo != null)
        {
            db.TodoItems.Remove(todo);
            await db.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}