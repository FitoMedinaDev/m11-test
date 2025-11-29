using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Data;
using SalesApp.Api.Entities;
using SalesApp.Api.Repositories;
using SalesApp.Api.Requests;
using SalesApp.Api.Services;

namespace SalesApp.Api.UnitTests;

[TestFixture]
public class EmployeeServiceTests
{
    private UnitOfWork _unitOfWork;
    private DatabaseContext _databaseContext;
    private EmployeeService _employeeService = null!;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _databaseContext = new DatabaseContext(options);
        _unitOfWork = new UnitOfWork(_databaseContext);
        _employeeService = new EmployeeService(_unitOfWork);

        SeedData();
    }

    [TearDown]
    public void Teardown()
    {
        _databaseContext.Dispose();
    }

    private void SeedData()
    {
        _databaseContext.DocumentTypes.Add(new DocumentType
        {
            Id = 2,
            Name = "Número de identificación tributaria",
            Code = "NIT"
        });

        _databaseContext.Employees.Add(new Employee
        {
            Id = 1,
            Code = "E001",
            Name = "Luis Arce",
            Email = "luis.arce@example.com",
            DocumentNumber = 123456,
            DocumentTypeId = 2,
            Salary = 25000,
            Role = "Gerente"
        });

        _databaseContext.SaveChanges();
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnEmployees()
    {
        var result = await _employeeService.GetAllAsync();

        var employees = result.ToList();
        Assert.That(employees, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task CreateAsync_ShouldAddNewEmployee()
    {
        var newEmployee = new EmployeeRequest
        {
            Code = "E002",
            Name = "Edman Lara",
            Email = "edman.lara@example.com",
            DocumentNumber = 654321,
            DocumentTypeId = 2,
            Salary = 25000,
            Role = "Asistente"
        };

        await _employeeService.CreateAsync(newEmployee);
        var result = await _employeeService.GetAllAsync();

        var employees = result.ToList();
        Assert.That(employees, Has.Count.EqualTo(2));
        Assert.That(employees.Any(e => e.Name == "Edman Lara"), Is.True);
    }

    [Test]
    public Task CreateAsync_ShouldThrowWhenCodeAlreadyExists()
    {
        var newEmployee = new EmployeeRequest
        {
            Code = "E001",
            Name = "Jhonny Fernandez",
            Email = "jhonny.fernandez@example.com",
            DocumentNumber = 987654,
            DocumentTypeId = 2,
            Salary = 25000,
            Role = "Secretario"
        };

        Assert.That(async () => await _employeeService.CreateAsync(newEmployee), Throws.InvalidOperationException);
        return Task.CompletedTask;
    }
}