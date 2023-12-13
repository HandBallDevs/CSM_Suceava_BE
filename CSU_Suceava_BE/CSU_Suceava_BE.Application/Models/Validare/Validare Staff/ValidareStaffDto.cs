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
                .MinimumLength(3).WithMessage("Numele trebuie să conțină cel puțin 3 caractere.")
                .MaximumLength(100).WithMessage("Numele nu poate depăși 100 de caractere.")
                .Matches(new Regex(@"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$")).WithMessage("Numele nu poate conține cifre sau caractere speciale.");

            RuleFor(entity => entity.Prenume)
                .MinimumLength(3).WithMessage("Prenumele trebuie să conțină cel puțin 3 caractere.")
                .MaximumLength(100).WithMessage("Prenumele nu poate depăși 100 de caractere.")
                .Matches(new Regex(@"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$")).WithMessage("Prenumele nu poate conține cifre sau caractere speciale.");

            RuleFor(entity => entity.Nationalitate)
                .MinimumLength(3).WithMessage("Naționalitatea trebuie să conțină cel puțin 3 caractere.")
                .MaximumLength(100).WithMessage("Naționalitatea nu poate depăși 100 de caractere.")
                .Matches(new Regex(@"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$")).WithMessage("Naționalitatea nu poate conține cifre sau caractere speciale.");

            RuleFor(entity => entity.Post)
                .MinimumLength(5).WithMessage("Postul trebuie să conțină cel puțin 5 caractere.")
                .MaximumLength(100).WithMessage("Postul nu poate depăși 100 de caractere.")
                .Matches(new Regex(@"^([a-zA-ZȘȚĂÎșțăî'-]+\s?)+$")).WithMessage("Postul nu poate conține cifre sau caractere speciale.");

            RuleFor(entity => entity.Descriere)
                .MinimumLength(1).WithMessage("Introduceți cel puțin 1 caracter pentru descriere.")
                .MaximumLength(2000).WithMessage("Descrierea nu poate depăși 2000 de caractere.");

        }
    }
}

