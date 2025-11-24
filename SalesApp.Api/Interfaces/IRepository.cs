using SalesApp.Api.Entities;

namespace SalesApp.Api.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> AsQueryable();
}