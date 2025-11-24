namespace SalesApp.Api.Entities;

public class DocumentType : BaseEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
}