using HaberSitesiASP.Abstract;
using System;

namespace HaberSitesiASP.Entities
{
    public class New : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Body { get; set; }
    }
}
