using AmlexWEB.Models;
using AmlexWEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AmlexWEB.Controllers
{
    public class UserController : Controller
    {

        private UserModel _UserModel;
        public UserController(UserModel user)
        {
            _UserModel = user;
        }

        [HttpGet]
        public IActionResult Check()
        {
            _UserModel.CreateIfNotExist(User.Claims.ElementAt(0).Value);
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public IActionResult Account()
        {
            
            return View(_UserModel.GetUser(User.Claims.ElementAt(0).Value));
        }
    }
}
