namespace SalesApp.Api.Entities;

public class Employee : BaseEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required int DocumentNumber { get; set; }
    public required int DocumentTypeId { get; set; }
    public required double Salary { get; set; }
    public required string Role { get; set; }
    public DocumentType? DocumentType { get; set; }
}