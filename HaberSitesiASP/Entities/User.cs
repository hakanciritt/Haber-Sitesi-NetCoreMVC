using HaberSitesiASP.Abstract;
using System;

namespace HaberSitesiASP.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
