using HaberSitesiASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public CategoryUpdateViewModel CategoryUpdateViewModel { get; set; }
    }
}
