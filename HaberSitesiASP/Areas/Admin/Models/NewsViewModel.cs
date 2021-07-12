using HaberSitesiASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Areas.Admin.Models
{
    public class NewsViewModel
    {
        public List<Category> Categories { get; set; }
        public NewsAddViewModel NewsAddViewModel { get; set; }
    }
}
