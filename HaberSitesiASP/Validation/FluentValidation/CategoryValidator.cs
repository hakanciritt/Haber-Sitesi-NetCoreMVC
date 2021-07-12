using FluentValidation;
using HaberSitesiASP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Validation.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryAddViewModel>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı minimum 2 karakter uzunluğunda olabilir");
        }
    }
}
