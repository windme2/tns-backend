using Microsoft.EntityFrameworkCore;
using TNSBackend.Models;

namespace TNSBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Services" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Sales" },
            new Department { Id = 4, Name = "HR" },
            new Department { Id = 5, Name = "Accounting" },
            new Department { Id = 6, Name = "Finance" },
            new Department { Id = 7, Name = "IT" },
            new Department { Id = 8, Name = "Admin" },
            new Department { Id = 9, Name = "Operations" },
            new Department { Id = 10, Name = "Customer Support" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FullName = "Alice Johnson", DepartmentId = 1 },
            new User { Id = 2, FullName = "Benjamin Smith", DepartmentId = 2 },
            new User { Id = 3, FullName = "Charlotte Brown", DepartmentId = 3 },
            new User { Id = 4, FullName = "Daniel Garcia", DepartmentId = 4 },
            new User { Id = 5, FullName = "Emma Martinez", DepartmentId = 5 },
            new User { Id = 6, FullName = "Felix Wilson", DepartmentId = 6 },
            new User { Id = 7, FullName = "Grace Hernandez", DepartmentId = 7 },
            new User { Id = 8, FullName = "Henry Lopez", DepartmentId = 8 },
            new User { Id = 9, FullName = "Isabella King", DepartmentId = 9 },
            new User { Id = 10, FullName = "Jack White", DepartmentId = 10 },
            new User { Id = 11, FullName = "Katherine Moore", DepartmentId = 1 },
            new User { Id = 12, FullName = "Liam Walker", DepartmentId = 2 },
            new User { Id = 13, FullName = "Mia Robinson", DepartmentId = 3 },
            new User { Id = 14, FullName = "Noah Scott", DepartmentId = 4 },
            new User { Id = 15, FullName = "Olivia Hall", DepartmentId = 5 },
            new User { Id = 16, FullName = "Peter Adams", DepartmentId = 6 },
            new User { Id = 17, FullName = "Quinn Cooper", DepartmentId = 7 },
            new User { Id = 18, FullName = "Rachel Evans", DepartmentId = 8 },
            new User { Id = 19, FullName = "Samuel Carter", DepartmentId = 9 },
            new User { Id = 20, FullName = "Taylor Reed", DepartmentId = 10 }
        );
    }
}