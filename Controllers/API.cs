using Microsoft.AspNetCore.Mvc;

namespace AmlexWEB.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
