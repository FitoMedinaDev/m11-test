using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Data;
using SalesApp.Api.Entities;
using SalesApp.Api.Repositories;
using SalesApp.Api.Requests;
using SalesApp.Api.Services;

namespace SalesApp.Api.UnitTests;

[TestFixture]
public class ClientServiceTests
{
    private UnitOfWork _unitOfWork;
    private DatabaseContext _databaseContext;
    private ClientService _clientService = null!;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _databaseContext = new DatabaseContext(options);
        _unitOfWork = new UnitOfWork(_databaseContext);
        _clientService = new ClientService(_unitOfWork);

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
            Id = 1,
            Name = "Carnet de identidad",
            Code = "CI"
        });

        _databaseContext.Clients.Add(new Client
        {
            Id = 1,
            Code = "C001",
            Name = "Joaquin Chumacero",
            Email = "john@example.com",
            DocumentNumber = 123456,
            DocumentTypeId = 1
        });

        _databaseContext.SaveChanges();
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnClients()
    {
        var result = await _clientService.GetAllAsync();

        var clients = result.ToList();
        Assert.That(clients, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task CreateAsync_ShouldAddNewClient()
    {
        var newClient = new ClientRequest
        {
            Code = "C002",
            Name = "Saturnino Mamani",
            Email = "j.chumacero@example.com",
            DocumentNumber = 654321,
            DocumentTypeId = 1
        };

        await _clientService.CreateAsync(newClient);
        var result = await _clientService.GetAllAsync();

        var clients = result.ToList();
        Assert.That(clients, Has.Count.EqualTo(2));
        Assert.That(clients.Any(c => c.Name == "Saturnino Mamani"), Is.True);
    }


    [Test]
    public Task CreateAsync_ShouldThrowWhenCodeAlreadyExists()
    {
        var newClient = new ClientRequest
        {
            Code = "C001",
            Name = "Saturnino Mamani",
            Email = "j.chumacero@example.com",
            DocumentNumber = 654321,
            DocumentTypeId = 1
        };

        Assert.That(async () => await _clientService.CreateAsync(newClient), Throws.InvalidOperationException);
        return Task.CompletedTask;
    }
}