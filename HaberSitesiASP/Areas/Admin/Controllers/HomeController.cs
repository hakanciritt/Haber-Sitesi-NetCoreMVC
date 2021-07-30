using AutoMapper;
using HaberSitesiASP.Areas.Admin.Models;
using HaberSitesiASP.Entities;
using HaberSitesiASP.EntityFramework;
using HaberSitesiASP.Helpers;
using HaberSitesiASP.Helpers.Exceptions;
using HaberSitesiASP.Validation;
using HaberSitesiASP.Validation.FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaberSitesiASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        IWebHostEnvironment _env;
        NewsRepository _newsRepo = new();
        CategoryRepository _categoryRepo = new();
        IMapper _mapper;
        public HomeController(IWebHostEnvironment environment, IMapper mapper)
        {
            _env = environment;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_newsRepo.GetAll());
        }
        [CustomExceptionFilter]
        public IActionResult Add()
        {
            ViewBag.list = (from x in _categoryRepo.GetAll()
                            select new SelectListItem
                            {
                                Text = x.Name.ToString(),
                                Value = x.Id.ToString()
                            }).ToList();
            return View(new NewsAddViewModel());
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Add(NewsAddViewModel newsAddViewModel, IFormFile file)
        {
            var result = Validator.Validate(new NewsValidator(), newsAddViewModel);
            if (result != null)
            {
                result.ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });

                return View(newsAddViewModel);
            }
            var news = _mapper.Map<New>(newsAddViewModel);
            string path = _env.WebRootPath + "\\Resimler\\" + file.FileName;
            var filePath = FileHelper.Save(path, file);
            news.ImagePath = filePath;
            _newsRepo.Add(news);
            return Redirect("/Admin/Home/Index");
        }

        public IActionResult Update(int id)
        {

            ViewBag.list = (from x in _categoryRepo.GetAll()
                            select new SelectListItem
                            {
                                Text = x.Name.ToString(),
                                Value = x.Id.ToString()
                            }).ToList();
            return View(_newsRepo.Get(x => x.Id == id));
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Update(New news, IFormFile file)
        {
            if (file != null)
            {
                string path = _env.WebRootPath + "\\Resimler\\" + file.FileName;
                var filePath = FileHelper.Save(path, file);
                news.ImagePath = filePath;
            }

            _newsRepo.Update(news);
            return Redirect("/Admin/Home/Index");
        }

        [HttpPost]
        [CustomExceptionFilter]
        public JsonResult Delete(int id)
        {
            string path = _env.WebRootPath + "\\Resimler\\";
            var findNews = _newsRepo.Get(x => x.Id == id);
            FileHelper.Delete(path + findNews.ImagePath);
            _newsRepo.Delete(findNews);
            return Json(new { message = "Haber başarılı bir şekilde silindi" });
        }
    }
}
