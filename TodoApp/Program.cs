using Microsoft.EntityFrameworkCore;
using TodoApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Додаємо Razor Pages
builder.Services.AddRazorPages();

// Підключаємо SQLite з рядком підключення
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=todo.db"));

var app = builder.Build();

// Обробка помилок та HSTS для не Development середовища
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();
app.MapRazorPages();

app.Run();