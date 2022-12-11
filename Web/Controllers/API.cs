using AmlexWEB.Models;
using AmlexWEB.Models.User;
using AmlexWEB.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AmlexWEB.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class APIController : Controller
    {

        private readonly ServerMonitoring _monitoring;
        private readonly ILogger<APIController> _logger;
        public APIController(ServerMonitoring monitor, ILogger<APIController> logger)
        {
            _monitoring = monitor;
            _logger = logger;
        }
        [NonAction]       
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("update")]
        public IActionResult UpdateInfo([FromBody]Server server)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(server));
            if (server == null) return BadRequest();
            _monitoring.UpdateServerInfo(server);
            return Ok();
        }

        [HttpPost]
        [ActionName("connect")]
        public IActionResult ConnectPlayer([FromBody] UserMonitoring player)
        {
            if (player == null) return BadRequest();
            _monitoring.UpdateServerPlayer(player);
            return Ok();
        }
    }
}
