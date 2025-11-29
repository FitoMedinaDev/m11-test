using SalesApp.Api.Entities;
using SalesApp.Api.Requests;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeResponse>> GetAllAsync();

    Task<EmployeeResponse> CreateAsync(EmployeeRequest request);
}