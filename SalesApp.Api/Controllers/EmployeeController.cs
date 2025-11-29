using Microsoft.AspNetCore.Mvc;
using SalesApp.Api.Interfaces;
using SalesApp.Api.Requests;

namespace SalesApp.Api.Controllers;

[ApiController]
[Route("api/v1/employees")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var employees = await employeeService.GetAllAsync();
        return Ok(employees);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeRequest request)
    {
        var employee = await employeeService.CreateAsync(request);
        return StatusCode(StatusCodes.Status201Created, employee);
    }
}