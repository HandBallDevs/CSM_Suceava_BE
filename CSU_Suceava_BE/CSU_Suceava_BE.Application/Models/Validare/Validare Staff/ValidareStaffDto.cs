using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CSU_Suceava_BE.Application.Models.IstoricRoluri;
using System.Text.RegularExpressions;
using CSU_Suceava_BE.Application.Models.Staff;
namespace CSU_Suceava_BE.Application.Models.Validare.Staff
{
    public class ValidareStaffDto : AbstractValidator<StaffDto>
    {
        public ValidareStaffDto()
        {

            RuleFor(entity => entity.Nume)
                .MinimumLength(1).WithMessage("Adauga Numele")
                 .Matches(new Regex(
                @"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$"))
                .WithMessage("Nu adaugati Cifre");

            RuleFor(entity => entity.Prenume)
               .MinimumLength(1).WithMessage("Adauga PreNumele")
                .Matches(new Regex(
               @"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$"))
               .WithMessage("Nu adaugati Cifre");

            RuleFor(entity => entity.Nationalitate)
               .MinimumLength(1).WithMessage("Adauga Nationalitatea")
                .Matches(new Regex(
               @"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$"))
               .WithMessage("Nu adaugati Cifre");

            RuleFor(entity => entity.Post)
               .MinimumLength(1).WithMessage("Adauga Postul")
                .Matches(new Regex(
               @"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$"))
               .WithMessage("Nu adaugati Cifre");

            RuleFor(entity => entity.Descriere)
               .MinimumLength(0).WithMessage("Adauga Descrierea")
               .MaximumLength(2000).WithMessage("Maxim caractere");

        }
    }
}

