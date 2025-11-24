using SalesApp.Api.Responses;

namespace SalesApp.Api.Interfaces;

public interface IDocumentTypeService
{
    Task<IEnumerable<DocumentTypeResponse>> GetAllAsync();
}