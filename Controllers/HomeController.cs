using AmlexWEB.Models;
using AmlexWEB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AmlexWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseUsers _DB;
        private readonly ServerMonitoring _monitoring;
        public HomeController(ILogger<HomeController> logger, DatabaseUsers db, ServerMonitoring monitoring)
        {
            _logger = logger;
            _DB = db;
            _monitoring = monitoring;
        }

        public IActionResult Index()
        {
            ViewBag.Server = _monitoring.Servers.ElementAt(0);
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}