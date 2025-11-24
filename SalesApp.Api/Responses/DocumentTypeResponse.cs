namespace SalesApp.Api.Responses;

public class DocumentTypeResponse
{
    public required int Id { get; set; }
    public required string Code { get; set; } = string.Empty;
    public required string Name { get; set; } = string.Empty;
}