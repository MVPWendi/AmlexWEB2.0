using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AmlexWEB.Controllers
{
    public class AuthController : Controller
    {
      
        [HttpPost]
        public IActionResult SignIn(string provider)
        {
            if (string.IsNullOrEmpty(provider)) return BadRequest();

            return Challenge(new AuthenticationProperties { RedirectUri = "User/Check" }, provider);
        }
        [HttpGet, HttpPost]
        public IActionResult SignOutUser()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
