namespace SalesApp.Api.Responses;

public class ClientResponse
{
    public required int Id { get; set; }
    public required string Code { get; set; } = string.Empty;
    public required string Name { get; set; } = string.Empty;
    public required string Email { get; set; }
    public required int DocumentNumber { get; set; }
    public DocumentTypeResponse? DocumentType { get; set; }
    public DateTime CreatedAt { get; set; }
}