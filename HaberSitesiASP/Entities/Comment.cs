using HaberSitesiASP.Abstract;
using System;

namespace HaberSitesiASP.Entities
{
    public class Comment: IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }
        public int NewsId { get; set; }
    }
}
