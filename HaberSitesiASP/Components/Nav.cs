using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HaberSitesiASP.Components
{
    public class Nav : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
