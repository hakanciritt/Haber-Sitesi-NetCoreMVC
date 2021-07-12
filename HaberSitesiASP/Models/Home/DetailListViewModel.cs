using HaberSitesiASP.Entities;
using HaberSitesiASP.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Models.Home
{
    public class DetailListViewModel
    {
        public DetailListViewModel()
        {
            Categories = new List<NewsListDto>();
            Comments = new List<HaberSitesiASP.Entities.Comment>();
        }
        public NewsListDto NewsDetail { get; set; }
        public List<NewsListDto> Categories { get; set; }
        public HaberSitesiASP.Entities.Comment  Comment { get; set; } 
        public List<HaberSitesiASP.Entities.Comment> Comments { get; set; }
    }
}
