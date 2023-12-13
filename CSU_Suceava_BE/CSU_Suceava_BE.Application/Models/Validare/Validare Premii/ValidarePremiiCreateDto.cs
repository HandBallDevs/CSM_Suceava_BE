using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CSU_Suceava_BE.Application.Models.IstoricPremii;
using System.Text.RegularExpressions;
namespace CSU_Suceava_BE.Application.Models.Validare.Validare_Premii
{
   public class ValidarePremiiCreateDto : AbstractValidator<IstoricPremiiCreateDto>
    {
        public ValidarePremiiCreateDto()
        {
            RuleFor(entity => entity.NumePremiu)
                .MinimumLength(5).WithMessage("Numele Premiului trebuie să conțină cel puțin 5 caractere.")
                .MaximumLength(100).WithMessage("Numele Premiului nu poate depăși 100 de caractere.");
        }
    }
}

