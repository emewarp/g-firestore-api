using Microsoft.AspNetCore.Mvc;
using MyFirestoreDomain.Contracts;
using MyFirestoreModels.Dto;
using MyFirestoreModels.Models;
using System.Threading.Tasks;

namespace MyFirestoneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {        
        private IMyFirestoreClientService _service;

        public ClientController(IMyFirestoreClientService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllClients()
        {            
            var clients = await _service.GetAllClients();
            return clients != null ? (IActionResult)Ok(clients) : (IActionResult)BadRequest();
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetClientById(string id)
        {
            var client = await _service.GetClientById(id);
            return client != null ? (IActionResult)Ok(client) : (IActionResult)BadRequest();
        }

        [HttpPost("create")]
        public async Task <IActionResult> PostClient(Client client)
        {
            bool created = await _service.CreateClient(client);

            return created ? (IActionResult)Ok(client) : (IActionResult)BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClient(string id, ClientPutDto clientDto)
        {
            var updatedClient = await _service.UpdateClient(id, clientDto);
            return updatedClient != null ? (IActionResult)Ok(updatedClient) : (IActionResult)BadRequest();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteClient(string clientId)
        {
            bool deleted = await _service.DeleteClient(clientId);

            return deleted ? (IActionResult)Ok(clientId) : (IActionResult)BadRequest();
        }
    }
}
