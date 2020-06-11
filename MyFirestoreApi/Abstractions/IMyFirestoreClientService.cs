using MyFirestoreApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirestoreApi.Abstractions
{
    interface IMyFirestoreClientService
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(string id);
        Task<bool> CreateClient(Client client);
        Task<Client> UpdateClient(string id, ClientPutDto clientDto);
        Task<bool> DeleteClient(string id);
    }
}
