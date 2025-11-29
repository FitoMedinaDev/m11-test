using SalesApp.Api.Data;
using SalesApp.Api.Entities;
using SalesApp.Api.Interfaces;

namespace SalesApp.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    public IRepository<Client> Clients { get; }
    public IRepository<DocumentType> DocumentTypes { get; }
    public IRepository<Employee> Employees { get; }

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        Clients = new Repository<Client>(context);
        DocumentTypes = new Repository<DocumentType>(context);
        Employees = new Repository<Employee>(context);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}