using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CSU_Suceava_BE.Application.Models.IstoricRoluri;
using System.Text.RegularExpressions;
namespace CSU_Suceava_BE.Application.Models.Validare.Validare_Premii
{
    public class ValidareIstoricRoluriCreateDto : AbstractValidator<IstoricRoluriResponseDto>
    {
        public ValidareIstoricRoluriCreateDto()
        {

            RuleFor(entity => entity.NumeRol)
                .MinimumLength(1).WithMessage("Adauga Nume Premiu")
                .WithMessage("Casuta Trebuie Completata");

           
                


        }
    }
}

