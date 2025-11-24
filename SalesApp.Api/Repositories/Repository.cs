using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Data;
using SalesApp.Api.Entities;
using SalesApp.Api.Interfaces;

namespace SalesApp.Api.Repositories;

public class Repository<T>(DatabaseContext databaseContext) : IRepository<T>
    where T : BaseEntity
{
    public async Task<T> AddAsync(T entity)
    {
        var entry = await databaseContext.Set<T>().AddAsync(entity);
        return entry.Entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await databaseContext.Set<T>().ToListAsync();
    }

    public IQueryable<T> AsQueryable()
    {
        return databaseContext.Set<T>().AsNoTracking();
    }
}