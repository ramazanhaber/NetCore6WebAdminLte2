using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NetCore6WebAdminLte2.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace NetCore6WebAdminLte2.Controllers
{
    public class LoginController : Controller
    {
        private readonly OgrenciContext _context;

        public LoginController(OgrenciContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Login(Users model)
        {

            try
            {

                var data = await _context.Users.Where(a => a.username == model.username && a.password == model.password).SingleOrDefaultAsync();

                if (ModelState.IsValid)
                {
                    if (data != null)
                    {

                        var claims = new List<Claim>
                    {
                      new Claim(ClaimTypes.Name, model.username),
                      new Claim(ClaimTypes.Role,data.role)

                    };

                        var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authprop = new AuthenticationProperties();

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), authprop);

                        return RedirectToAction("Index", "Home");
                    }
                }
                return View(model);

            }
            catch (Exception)
            {

                throw;
            }


        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
