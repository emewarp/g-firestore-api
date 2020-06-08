using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirestoneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string id)
        {


            //DocumentReference docRef = db.Collection("users").Document("alovelace");
            //Dictionary<string, object> user = new Dictionary<string, object>
            //{
            //    { "name", "Marta Warp" },
            //    { "mail", "martawarp@gmail.com" },
            //    { "phone", "123456789" },
            //    { "card", "blahblahbalh" }
            //};
            //var result = docRef.SetAsync(user).Result;


            return "heyyyyy";
        }
    }
}
