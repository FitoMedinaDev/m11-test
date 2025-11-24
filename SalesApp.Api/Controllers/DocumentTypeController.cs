using Microsoft.AspNetCore.Mvc;
using SalesApp.Api.Interfaces;

namespace SalesApp.Api.Controllers;

[ApiController]
[Route("api/v1/document-types")]
public class DocumentTypeController(IDocumentTypeService documentTypeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var documentTypes = await documentTypeService.GetAllAsync();
        return Ok(documentTypes);
    }
}