using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Areas.Admin.Models
{
    public class NewsAddViewModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Body { get; set; }
    }
}
