using HaberSitesiASP.Entities;
using HaberSitesiASP.EntityFramework;
using HaberSitesiASP.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HaberSitesiASP.Controllers
{
    public class CommentController : Controller
    {
        
        CommentRepository _commentRepo = new();

        [HttpPost]
        [CustomExceptionFilter]
        public JsonResult Comment(Comment comment)
        {
            _commentRepo.Add(comment);
            return Json(comment);
        }
    }
}
