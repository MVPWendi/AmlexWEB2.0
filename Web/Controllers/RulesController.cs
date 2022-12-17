using AmlexWEB.Models.Rules;
using Microsoft.AspNetCore.Mvc;

namespace AmlexWEB.Controllers
{
    public class RulesController : Controller
    {
        private readonly ILogger<RulesController> _logger;
        public RulesController(ILogger<RulesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new RulesModel();
            _logger.LogInformation("RULE: " + model.RuleSections.Count());
            return View(model);
        }
    }
}
