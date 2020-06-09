using MyFirestoreApi.Models;
using System.Threading.Tasks;

namespace MyFirestoreApi.Abstractions
{
    interface IMyFirestoreClientService
    {
        Task<Client> GetClient(string id);
        Task<bool> CreateClient(Client client);
        string UpdateClient(Client client);
        bool DeleteClient(string id);
    }
}
