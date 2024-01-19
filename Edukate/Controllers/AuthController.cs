using Edukate.Models;
using Edukate.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Edukate.Controllers
{
    public class AuthController : Controller
    {
        UserManager<AppUser> _um { get; set; }
        SignInManager<AppUser> _sm { get; set; }
        public AuthController(UserManager<AppUser> um, SignInManager<AppUser> sm)
        {
            _um = um;
            _sm = sm;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVm login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            AppUser appUser;
            if (login.UserNameOrEmail.Contains("@"))
            {
                appUser = _um.FindByEmailAsync(login.UserNameOrEmail).Result;
            }
            else
            {
                appUser = _um.FindByNameAsync(login.UserNameOrEmail).Result;
            }

            if(appUser== null)
            {
                ModelState.AddModelError(" ", "UserNameOrEmail or Password InCorrected");
                return View(login);
            }
            
            var result = _sm.PasswordSignInAsync(appUser, login.Password, login.Remember, true).Result;
            if (!result.Succeeded)
            {
                ModelState.AddModelError(" ", "UserNameOrEmail or Password InCorrected");
                return View(login);
            }


            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVm register)
        {
            if(!ModelState.IsValid) 
            {
                return View(register);
            }

           var result = _um.CreateAsync(new AppUser
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.UserName,
            },register.Password).Result;

            if(!result.Succeeded)
            {
                foreach (var item in result.Errors) 
                {
                    ModelState.AddModelError(" ",item.Description);
                }
                return View(register);
            }
            return RedirectToAction(nameof(Login));
        }
    }
}
