using HVACManagement.Models.Domain;
using HVACManagement.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HVACManagement.Data.SeedData;

public static class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        await context.Database.MigrateAsync();

        var roles = new[] { "SuperAdmin", "Admin", "Manager", "Engineer", "Technician", "HR", "Accountant", "CEO", "Client" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        if (await userManager.FindByEmailAsync("superadmin@hvac.com") is null)
        {
            var user = new ApplicationUser
            {
                UserName = "superadmin@hvac.com",
                Email = "superadmin@hvac.com",
                FirstName = "Super",
                LastName = "Admin",
                EmailConfirmed = true,
                EmployeeCode = "HVAC-2026-0001",
                Department = "Operations"
            };
            await userManager.CreateAsync(user, "SuperAdmin@123!");
            await userManager.AddToRoleAsync(user, "SuperAdmin");
        }

        if (!await context.Departments.AnyAsync())
        {
            context.Departments.AddRange(
                new Department { DepartmentName = "HVAC Engineering", Description = "Core HVAC design and execution" },
                new Department { DepartmentName = "Project Management", Description = "Project planning and delivery" },
                new Department { DepartmentName = "Human Resources", Description = "People and compliance" });
        }

        if (!await context.Clients.AnyAsync())
        {
            context.Clients.AddRange(
                new Client { CompanyName = "Apex Towers", PrimaryContactName = "Leena Roy", PrimaryContactEmail = "leena@apex.com", PrimaryContactPhone = "+1-202-555-1001" },
                new Client { CompanyName = "Metro Hospitals", PrimaryContactName = "Zaid Khan", PrimaryContactEmail = "zaid@metrohosp.com", PrimaryContactPhone = "+1-202-555-1002" });
        }

        await context.SaveChangesAsync();

        if (!await context.Projects.AnyAsync())
        {
            var firstClient = await context.Clients.FirstAsync();
            context.Projects.AddRange(
                new Project
                {
                    ProjectCode = "HVAC-2026-0001",
                    ProjectName = "Apex Tower Chiller Retrofit",
                    Description = "Retrofitting central chilled water loop and AHUs.",
                    ClientId = firstClient.ClientId,
                    Budget = 750000,
                    StartDate = DateTime.UtcNow.Date,
                    DeadlineDate = DateTime.UtcNow.Date.AddMonths(6),
                    ProgressPercentage = 10,
                    Status = ProjectStatus.Ongoing
                });
        }

        await context.SaveChangesAsync();
    }
}
