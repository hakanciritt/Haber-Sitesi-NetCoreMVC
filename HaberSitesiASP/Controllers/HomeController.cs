using HaberSitesiASP.EntityFramework;
using HaberSitesiASP.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HaberSitesiASP.Controllers
{
    public class HomeController : Controller
    {
        NewsRepository _newsRepo = new();
        CategoryRepository _categoryRepo = new();
        CommentRepository _commentRepo = new();
        public IActionResult Index()
        {
            NewsListViewModel model = new NewsListViewModel()
            {
                News = _newsRepo.NewsDetails(),
                Categories = _categoryRepo.GetAll(),
            };

            return View(model);
        }
        public IActionResult Detail(int id)
        {
            DetailListViewModel model = new DetailListViewModel();
            model.NewsDetail = _newsRepo.NewsDetail(x => x.Id == id);
            model.Categories = _newsRepo.NewsDetails(x => x.CategoryId == model.NewsDetail.CategoryId);
            model.Comments = _commentRepo.GetAll(x => x.NewsId == model.NewsDetail.Id);
            return View(model);
        }
        public IActionResult Category(int id)
        {
            var model = new DetailListViewModel
            {
                Categories = _newsRepo.NewsDetails(x => x.CategoryId == id)
            };

            return View(model);

        }
    }
}
