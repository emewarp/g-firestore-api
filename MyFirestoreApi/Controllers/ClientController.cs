using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirestoreApi;
using MyFirestoreApi.Abstractions;
using MyFirestoreApi.Models;
using System.Threading.Tasks;

namespace MyFirestoneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private IMyFirestoreClientService _service;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
            _service = new MyFirestoreClientService(new MyFirestoreDb()); //TODO DI
        }

        [HttpGet]
        public async Task<IActionResult> GetClient(string id)
        {
            var client = await _service.GetClientById(id);
            return client != null ? (IActionResult)Ok(client) : (IActionResult)BadRequest();    
        }



        [HttpPost]
        public async Task <IActionResult> PostClient(Client client)
        {
            bool created = await _service.CreateClient(client);

            return created ? (IActionResult)Ok(client) : (IActionResult)BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(string clientId)
        {
            bool deleted = await _service.DeleteClient(clientId);

            return deleted ? (IActionResult)Ok(clientId) : (IActionResult)BadRequest();
        }
    }
}
