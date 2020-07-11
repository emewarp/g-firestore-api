using Microsoft.AspNetCore.Mvc;
using MyFirestoreDomain.Contracts;
using MyFirestoreModels.Dto;
using MyFirestoreModels.Models;
using System.Threading.Tasks;

namespace MyFirestoneApi.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {        
        private IMyFirestoreClientService _service;

        public ClientController(IMyFirestoreClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {            
            var clients = await _service.GetAllClients();
            return clients != null ? Ok(clients) : (IActionResult)BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(string id)
        {
            var client = await _service.GetClientById(id);
            return client != null ? Ok(client) : (IActionResult)NotFound();
        }

        [HttpPost]
        public async Task <IActionResult> PostClient(ClientDto clientDto)
        {
            bool created = await _service.CreateClient(clientDto);

            return created ? StatusCode(201, clientDto) : (IActionResult)BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(string id, ClientDto clientDto)
        {
            var updatedClient = await _service.UpdateClient(id, clientDto);
            return updatedClient != null ? Ok(updatedClient) : (IActionResult)BadRequest();
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(string clientId)
        {
            bool deleted = await _service.DeleteClient(clientId);

            return deleted ? Ok(clientId) : (IActionResult)NotFound();
        }
    }
}
