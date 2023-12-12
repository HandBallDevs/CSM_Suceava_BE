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
    public class ValidarePremiiResponse : AbstractValidator<IstoricPremiiResponseDto>
    {
        public ValidarePremiiResponse()
        {

            RuleFor(entity => entity.NumePremiu)
                .MinimumLength(1).WithMessage("Adauga Nume Premiu")
                .WithMessage("Casuta Trebuie Completata");

            RuleFor(entity => entity.DataPrimire)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Data Invalida");


        }
    }
}

