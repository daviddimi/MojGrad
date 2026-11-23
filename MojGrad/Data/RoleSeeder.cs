using Microsoft.AspNetCore.Identity;

namespace MojGrad.Data
{
    public static class RoleSeeder
    {
        public static readonly string[] Roles = { "Citizen", "Official", "Admin" };

        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var role in Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}