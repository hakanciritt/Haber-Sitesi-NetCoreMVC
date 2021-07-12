using HaberSitesiASP.Entities;
using HaberSitesiASP.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Models.Home
{
    public class NewsListViewModel
    {
        public List<NewsListDto> News { get; set; }
        public List<Category> Categories { get; set; }
    }
}
