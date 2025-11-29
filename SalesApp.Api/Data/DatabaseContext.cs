using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Entities;

namespace SalesApp.Api.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<DocumentType> DocumentTypes { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentType>().HasQueryFilter(dt => dt.DeletedAt == null);
        modelBuilder.Entity<Client>().HasQueryFilter(c => c.DeletedAt == null);
        modelBuilder.Entity<Employee>().HasQueryFilter(e => e.DeletedAt == null);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                     .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
        {
            modelBuilder.Entity(entityType.ClrType)
                .Property("CreatedAt")
                .HasDefaultValueSql("GETUTCDATE()");
        }

        base.OnModelCreating(modelBuilder);
    }
}