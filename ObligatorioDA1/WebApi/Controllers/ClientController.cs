using Microsoft.AspNetCore.Mvc;
using Logic;
using APIDataModels;



namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        
        [HttpPost]
        public IActionResult CreateClient([FromBody]CreateClientRequest newClient)
        {
            if (newClient == null)
            {
                return BadRequest();
            }

            ClientLogic clientLogic = ClientLogic.Instance;
            try
            {
                clientLogic.CreateClient(newClient.Username, newClient.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
    }

}
