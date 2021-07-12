using AutoMapper;
using HaberSitesiASP.Areas.Admin.Models;
using HaberSitesiASP.Entities;
using HaberSitesiASP.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommentAddViewModel, Comment>();
            CreateMap<CategoryAddViewModel, Category>();
            CreateMap<Category, CategoryAddViewModel>();
            CreateMap<NewsAddViewModel, New>();
            CreateMap<New, NewsAddViewModel>();
            CreateMap<CategoryUpdateViewModel, Category>();
            CreateMap<Category, CategoryUpdateViewModel>();
        }
    }
}
