using SalesApp.Api.Requests;
using SalesApp.Api.Responses;

namespace SalesApp.Api.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientResponse>> GetAllAsync();

    Task<ClientResponse> CreateAsync(ClientRequest request);
}