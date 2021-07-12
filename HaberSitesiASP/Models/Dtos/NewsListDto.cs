using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Models.Dtos
{
    public class NewsListDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}
