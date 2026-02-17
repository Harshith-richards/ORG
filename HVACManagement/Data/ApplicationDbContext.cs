using HVACManagement.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HVACManagement.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectAssignment> ProjectAssignments => Set<ProjectAssignment>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Department>().HasIndex(d => d.DepartmentName).IsUnique();
        builder.Entity<Employee>().HasIndex(e => e.EmployeeCode).IsUnique();
        builder.Entity<Project>().HasIndex(p => p.ProjectCode).IsUnique();

        builder.Entity<Employee>()
            .HasOne(e => e.ApplicationUser)
            .WithMany()
            .HasForeignKey(e => e.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ProjectAssignment>()
            .HasOne(pa => pa.Project)
            .WithMany(p => p.ProjectAssignments)
            .HasForeignKey(pa => pa.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProjectAssignment>()
            .HasOne(pa => pa.Employee)
            .WithMany(e => e.ProjectAssignments)
            .HasForeignKey(pa => pa.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Attendance>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Attendances)
            .HasForeignKey(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Attendance>()
            .HasOne(a => a.Project)
            .WithMany(p => p.Attendances)
            .HasForeignKey(a => a.ProjectId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Department>().HasQueryFilter(x => x.IsActive);
        builder.Entity<Employee>().HasQueryFilter(x => x.IsActive);
        builder.Entity<Client>().HasQueryFilter(x => x.IsActive);
        builder.Entity<Project>().HasQueryFilter(x => x.IsActive);
        builder.Entity<ProjectAssignment>().HasQueryFilter(x => x.IsActive);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
