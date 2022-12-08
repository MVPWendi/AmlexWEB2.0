using Microsoft.AspNetCore.Mvc;

namespace AmlexWEB.Controllers
{
    public class WikiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
