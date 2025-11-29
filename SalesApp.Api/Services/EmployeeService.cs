using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Interfaces;
using SalesApp.Api.Mapper;
using SalesApp.Api.Requests;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Services;

public class EmployeeService(IUnitOfWork unitOfWork) : IEmployeeService
{
    public async Task<IEnumerable<EmployeeResponse>> GetAllAsync()
    {
        return await unitOfWork.Employees
            .AsQueryable()
            .Include(x => x.DocumentType)
            .Select(c => c.ToResponse())
            .ToListAsync();
    }

    public async Task<EmployeeResponse> CreateAsync(EmployeeRequest request)
    {
        var exists = unitOfWork.Employees
            .AsQueryable()
            .Any(c => c.Code == request.Code);
        if (exists)
            throw new InvalidOperationException("Employee code already exists");

        var employee = request.ToEntity();
        var created = await unitOfWork.Employees.AddAsync(employee);
        await unitOfWork.SaveChangesAsync();
        return created.ToResponse();
    }
}