using HaberSitesiASP.Entities;
using HaberSitesiASP.Models.Dtos;
using HaberSitesiASP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HaberSitesiASP.EntityFramework
{
    public class NewsRepository : Repository<New>
    {
        public List<NewsListDto> NewsDetails(Expression<Func<NewsListDto, bool>> filter = null)
        {
            var result = (from x in _context.News
                          join category in _context.Categories
                          on x.CategoryId equals category.Id
                          select new NewsListDto
                          {
                              Id = x.Id,
                              Title = x.Title,
                              CategoryId = category.Id,
                              CategoryName = category.Name,
                              ImagePath = x.ImagePath,
                              Body = x.Body,
                              Date = x.Date

                          });
            return filter == null ? result.ToList() : result.Where(filter).ToList();

        }
        public NewsListDto NewsDetail(Expression<Func<NewsListDto, bool>> filter)
        {
            var result = (from x in _context.News
                          join category in _context.Categories
                          on x.CategoryId equals category.Id
                          select new NewsListDto
                          {
                              Id = x.Id,
                              Title = x.Title,
                              CategoryId = category.Id,
                              CategoryName = category.Name,
                              ImagePath = x.ImagePath,
                              Body = x.Body,
                              Date = x.Date

                          });
            return result.SingleOrDefault(filter);

        }
    }
}
