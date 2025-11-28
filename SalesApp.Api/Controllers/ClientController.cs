using Microsoft.AspNetCore.Mvc;
using SalesApp.Api.Interfaces;
using SalesApp.Api.Requests;

namespace SalesApp.Api.Controllers;

[ApiController]
[Route("api/v1/clients")]
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clients = await clientService.GetAllAsync();
        System.Console.WriteLine("Retrieved clients 6: " + clients.Count());
        return Ok(clients);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClientRequest request)
    {
        var client = await clientService.CreateAsync(request);
        return Ok(client);
    }
}