using HaberSitesiASP.Entities;
using HaberSitesiASP.EntityFramework;
using HaberSitesiASP.Helpers.Exceptions;
using HaberSitesiASP.Validation;
using HaberSitesiASP.Validation.FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HaberSitesiASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        UserRepository _userRepo = new();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [CustomExceptionFilter]
        public async Task<IActionResult> Login(User user)
        {
            var result = Validator.Validate(new UserValidator(), user);
            if (result != null)
            {
                result.ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });
                return View(user);
            }
            var findUser = _userRepo.Get(x => x.UserName == user.UserName && x.Password == user.Password);

            if (findUser != null)
            {
                var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.NameIdentifier,user.UserName),
                   new Claim("password",user.Password),
               };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect("/Admin/Home/Index");
            }
            else
            {
                ModelState.AddModelError("kontrol", "Böyle bir kullanıcı bulunamadı");
                return Redirect("/Admin/Auth/Login");
            }
        }
    }
}
