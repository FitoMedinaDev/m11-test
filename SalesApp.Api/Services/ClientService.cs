using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Interfaces;
using SalesApp.Api.Mapper;
using SalesApp.Api.Requests;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Services;

public class ClientService(IUnitOfWork unitOfWork) : IClientService
{
    public async Task<IEnumerable<ClientResponse>> GetAllAsync()
    {
        return await unitOfWork.Clients
            .AsQueryable()
            .Include(x => x.DocumentType)
            .Select(c => c.ToResponse())
            .ToListAsync();
    }

    public async Task<ClientResponse> CreateAsync(ClientRequest request)
    {
        var exists = unitOfWork.Clients
            .AsQueryable()
            .Any(c => c.Code == request.Code);
        if (exists)
            throw new InvalidOperationException("Client code already exists");

        var client = request.ToEntity();
        var created = await unitOfWork.Clients.AddAsync(client);
        await unitOfWork.SaveChangesAsync();
        return created.ToResponse();
    }
}