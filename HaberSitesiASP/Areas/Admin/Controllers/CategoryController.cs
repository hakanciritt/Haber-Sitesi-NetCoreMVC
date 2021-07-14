using AutoMapper;
using HaberSitesiASP.Areas.Admin.Models;
using HaberSitesiASP.Entities;
using HaberSitesiASP.EntityFramework;
using HaberSitesiASP.Helpers.Exceptions;
using HaberSitesiASP.Validation;
using HaberSitesiASP.Validation.FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        IMapper _mapper;
        CategoryRepository _categoryRepo = new();

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_categoryRepo.GetAll());
        }
        [CustomExceptionFilter]
        public IActionResult Update(int id)
        {
            var findCategory = _categoryRepo.Get(x => x.Id == id);
            var model = _mapper.Map<CategoryUpdateViewModel>(findCategory);
            return View(model);
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Update(CategoryUpdateViewModel categoryUpdateViewModel)
        {
            var result = Validator.Validate(new CategoryUpdateValidator(), categoryUpdateViewModel);
            if (result != null)
            {
                result.ForEach(item =>
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                });
                return View(categoryUpdateViewModel);
            }

            var category = _mapper.Map<Category>(categoryUpdateViewModel);
            _categoryRepo.Update(category);
            return Redirect("/Admin/Category/Index");
        }
        [HttpPost]
        [CustomExceptionFilter]
        public JsonResult Delete(int id)
        {
            var findCategory = _categoryRepo.Get(x => x.Id == id);
            _categoryRepo.Delete(findCategory);
            return Json(new { message = "Kategori başarılı bir şekilde silindi" });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Add(CategoryAddViewModel categoryAddViewModel)
        {
            var result = Validator.Validate(new CategoryValidator(), categoryAddViewModel);
            if (result != null)
            {
                result.ForEach(item =>
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                });
                return View(categoryAddViewModel);
            }

            var category = _mapper.Map<Category>(categoryAddViewModel);
            _categoryRepo.Add(category);
            return Redirect("/Admin/Category/Index");
        }
    }
}
