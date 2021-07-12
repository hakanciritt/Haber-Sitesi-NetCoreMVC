using FluentValidation;
using HaberSitesiASP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Validation.FluentValidation
{
    public class NewsValidator : AbstractValidator<NewsAddViewModel>
    {
        public NewsValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori alanı boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık minimum 5 karakter uzunluğunda olabilir");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık maximum 100 karakter uzunluğunda olabilir");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez");
            RuleFor(x => x.Body).NotEmpty().WithMessage("İçerik alanı boş geçilemez");
            RuleFor(x => x.Body).MinimumLength(200).WithMessage("İçerik minimum 200 karakter uzunluğunda olabilir");
        }
    }
}
