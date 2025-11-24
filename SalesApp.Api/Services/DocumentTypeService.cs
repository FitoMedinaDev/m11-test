using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Interfaces;
using SalesApp.Api.Mapper;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Services;

public class DocumentTypeService(IUnitOfWork unitOfWork) : IDocumentTypeService
{
    public async Task<IEnumerable<DocumentTypeResponse>> GetAllAsync()
    {
        return await unitOfWork.DocumentTypes
            .AsQueryable()
            .Select(dt => dt.ToResponse())
            .ToListAsync();
    }
}