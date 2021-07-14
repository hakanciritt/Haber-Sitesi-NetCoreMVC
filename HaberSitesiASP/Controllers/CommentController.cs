using HaberSitesiASP.Entities;
using HaberSitesiASP.EntityFramework;
using HaberSitesiASP.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
