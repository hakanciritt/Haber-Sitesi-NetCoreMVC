using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.Validation
{
    public static class Validator
    {
        public static List<ValidationFailure> Validate(IValidator validator, object obje)
        {
            var context = new ValidationContext<object>(obje);
            var result = validator.Validate(context);

            return !result.IsValid
                ? new List<ValidationFailure>(result.Errors)
                : null;
        }
    }
}
