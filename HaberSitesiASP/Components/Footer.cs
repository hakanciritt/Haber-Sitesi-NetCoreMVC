using HaberSitesiASP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Components
{
    public class Footer : ViewComponent
    {
        CategoryRepository _categoryRepo = new();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _categoryRepo.GetAll();
            return View(model);
        }
    }
}
