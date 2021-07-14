using HaberSitesiASP.Entities;
using HaberSitesiASP.EntityFramework;
using HaberSitesiASP.Helpers.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        UserRepository _userRepo = new();

        public IActionResult Index()
        {
            return View(_userRepo.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Add(User user)
        {
            _userRepo.Add(user);
            return Redirect("/Admin/User/Index");
        }
        [CustomExceptionFilter]
        public IActionResult Update(int id)
        {
            return View(_userRepo.Get(x => x.Id == id));
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Update(User user)
        {
            _userRepo.Update(user);
            return Redirect("/Admin/User/Index");
        }
        [CustomExceptionFilter]
        public IActionResult Delete(int id)
        {
            var findUser = _userRepo.Get(x => x.Id == id);
            _userRepo.Delete(findUser);
            return Redirect("/Admin/User/Index");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Admin/Auth/Login");
        }

    }
}
