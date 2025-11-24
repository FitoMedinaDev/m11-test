using SalesApp.Api.Entities;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Mapper;

public static class DocumentTypeMappingExtensions
{
    public static DocumentTypeResponse ToResponse(this DocumentType entity)
    {
        return new DocumentTypeResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Code = entity.Code
        };
    }

    // public static DocumentType ToEntity(this DocumentTypeRequest request)
    // {
    //     return new DocumentType
    //     {
    //         Name = request.Name,
    //         Email = request.Email,
    //         Code = request.Code,
    //         DocumentNumber = request.DocumentNumber,
    //         DocumentTypeId = request.DocumentTypeId
    //     };
    // }
}