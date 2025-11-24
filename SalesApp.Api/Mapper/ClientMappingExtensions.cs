using SalesApp.Api.Entities;
using SalesApp.Api.Requests;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Mapper;

public static class ClientMappingExtensions
{
    public static ClientResponse ToResponse(this Client entity)
    {
        return new ClientResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            Code = entity.Code,
            CreatedAt = entity.CreatedAt,
            DocumentNumber = entity.DocumentNumber,
            DocumentType = entity.DocumentType?.ToResponse()
        };
    }

    public static Client ToEntity(this ClientRequest request)
    {
        return new Client
        {
            Name = request.Name,
            Email = request.Email,
            Code = request.Code,
            DocumentNumber = request.DocumentNumber,
            DocumentTypeId = request.DocumentTypeId
        };
    }
}