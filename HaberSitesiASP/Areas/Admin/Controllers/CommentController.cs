using HaberSitesiASP.Entities;
using HaberSitesiASP.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CommentController : Controller
    {
        CommentRepository _commentRepo = new();
        public ActionResult Index()
        {
            return View(_commentRepo.GetAll());
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var findComment = _commentRepo.Get(x => x.Id == id);
            _commentRepo.Delete(findComment);
            return Json(new { message = "Yorum başarılı bir şekilde silindi" });
        }
        public IActionResult Update(int id)
        {
            return View(_commentRepo.Get(x => x.Id == id));
        }
        [HttpPost]
        public IActionResult Update(Comment comment)
        {
            _commentRepo.Update(comment);
            return Redirect("/Admin/Comment/Index");
        }
    }
}
