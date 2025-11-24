using SalesApp.Api.Entities;

namespace SalesApp.Api.Interfaces;

public interface IUnitOfWork
{
    IRepository<Client> Clients { get; }
    IRepository<DocumentType> DocumentTypes { get; }
    
    Task<int> SaveChangesAsync();
}