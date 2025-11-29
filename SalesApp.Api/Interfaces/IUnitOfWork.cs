using SalesApp.Api.Entities;

namespace SalesApp.Api.Interfaces;

public interface IUnitOfWork
{
    IRepository<Client> Clients { get; }
    IRepository<DocumentType> DocumentTypes { get; }
    IRepository<Employee> Employees { get; }

    Task<int> SaveChangesAsync();
}