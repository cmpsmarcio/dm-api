using dm_api.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dm_api.Application.Validations
{
    public class ClientRequestValidator: AbstractValidator<ClientRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                .MaximumLength(150)
                .MinimumLength(3);
            RuleFor(c => c.Email)
                .EmailAddress();
            RuleFor(c => c.MobilePhone)
                .Must(OnlyNumbersAndLength11)
                .WithMessage("'Mobile Phone' não atende a condição definida. Somente números e com 13 posições. Colocar o 55 antes do DDD");
            RuleFor(c => c.BirthDate)
                .InclusiveBetween(new DateTime(1920, 1, 1), DateTime.Today);
        }

        private bool OnlyNumbersAndLength11(string? arg) => arg == null || Regex.IsMatch(arg, "^[0-9]+$") && arg.Length == 11;
    }
}
