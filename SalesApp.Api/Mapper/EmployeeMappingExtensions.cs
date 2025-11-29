using SalesApp.Api.Entities;
using SalesApp.Api.Requests;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Mapper;

public static class EmployeeMappingExtensions
{
    public static EmployeeResponse ToResponse(this Employee entity)
    {
        return new EmployeeResponse
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Code = entity.Code,
            Name = entity.Name,
            Email = entity.Email,
            DocumentNumber = entity.DocumentNumber,
            Salary = entity.Salary,
            Role = entity.Role,
            DocumentType = entity.DocumentType?.ToResponse()
        };
    }

    public static Employee ToEntity(this EmployeeRequest request)
    {
        return new Employee
        {
            Code = request.Code,
            Name = request.Name,
            Email = request.Email,
            DocumentNumber = request.DocumentNumber,
            DocumentTypeId = request.DocumentTypeId,
            Salary = request.Salary,
            Role = request.Role
        };
    }
}