using FluentValidation;
using IntegrationAPI.Models.RevModels;

namespace IntegrationAPI.Models.Validations.ValidationsRev
{
    public class TokenRevValidator : AbstractValidator<TokenRev>
    {

        public TokenRevValidator()
        {
            RuleFor(x => x)
              .NotEmpty()
              .WithMessage("A entidade não pode ser vazia.")

              .NotNull()
              .WithMessage("A Entidade não pode ser nula.");
        }
    }
}
