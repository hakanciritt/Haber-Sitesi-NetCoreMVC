using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Models.Comment
{
    public class CommentAddViewModel
    {
        public string UserName { get; set; }
        public string UserComment { get; set; }
        public int NewsId { get; set; }
    }
}
