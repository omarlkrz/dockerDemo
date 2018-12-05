using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi10.Models;

namespace WebApi10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string idUser, string password)
        {
            User user = new User();
            bool found = false;
            if (string.IsNullOrEmpty(idUser) || (string.IsNullOrEmpty(password)))
            {

                return RedirectToAction(nameof(Index));
            }

            using (db_inventaireContext entities = new db_inventaireContext())
            {
                found = entities.User.Any(u => u.Password.Equals(password) && u.IdUser.Equals(idUser));
                if (found == true)
                {
                    user = entities.User.FirstOrDefault(u => u.Password.Equals(password) && u.IdUser.Equals(idUser));
                }
            }

            if (found == false)
            {
                return RedirectToAction(nameof(Index));
            }

            ClaimsIdentity identity = null;
            if (user.IdUserType == 2)
            {

                identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.IdUser),
                


            }, CookieAuthenticationDefaults.AuthenticationScheme);

            }
            else if (user.IdUserType == 1)
            {
                identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.IdUser),
               

                new Claim(ClaimTypes.Role, "admin"),
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            }


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);
            return RedirectToAction("index", "Home");
        }


        [Authorize(Policy = "MustBeAdmin")]
        public IActionResult Manage() => View();

        [HttpPost]
        public async Task<IActionResult> Logout(string idUser)
        {


            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "Home");
        }

        public IActionResult ErrorNotLogedIn() => View();
        public IActionResult ErrorForbidden() => View();
  
        
    }
}
