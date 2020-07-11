using MyFirestoreModels.Dto;
using MyFirestoreModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirestoreDomain.Contracts
{
    public interface IMyFirestoreClientService
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(string id);
        Task<bool> CreateClient(ClientDto client);
        Task<Client> UpdateClient(string id, ClientDto clientDto);
        Task<bool> DeleteClient(string id);
    }
}
