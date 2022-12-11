using Microsoft.AspNetCore.Mvc;

namespace AmlexWEB.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
