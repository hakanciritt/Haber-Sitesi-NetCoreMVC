using FluentValidation;
using HaberSitesiASP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Validation.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateViewModel>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı minimum 2 karakter uzunluğunda olabilir");
        }
    }
}
