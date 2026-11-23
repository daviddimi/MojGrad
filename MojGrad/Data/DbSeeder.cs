using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MojGrad.Models.Entities;

namespace MojGrad.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            if (!await db.Categories.AnyAsync())
            {
                db.Categories.AddRange(
                    new Category { Name = "Патишта" },
                    new Category { Name = "Водовод" },
                    new Category { Name = "Струја" },
                    new Category { Name = "Канализација" },
                    new Category { Name = "Улично осветлување" });
            }

            if (!await db.Municipalities.AnyAsync())
            {
                var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "municipalities.json");
                var names = JsonSerializer.Deserialize<string[]>(await File.ReadAllTextAsync(path))!;
                db.Municipalities.AddRange(names.Select(n => new Municipality { Name = n }));
            }

            await db.SaveChangesAsync();
        }
    }
}