using FluentValidation;
using IntegrationAPI.Models.RevModels;

namespace IntegrationAPI.Models.Validations.ValidationsRev
{
    public class UserRevValidator : AbstractValidator<LoginRev>
    {
        public UserRevValidator()
        {
            RuleFor(x => x)
              .NotEmpty()
              .WithMessage("A entidade não pode ser vazia.")

              .NotNull()
              .WithMessage("A Entidade não pode ser nula.");
        }
    }
}
