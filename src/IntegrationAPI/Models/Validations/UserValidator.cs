using FluentValidation;

namespace IntegrationAPI.Models.Validations
{
    public class UserValidator : AbstractValidator<Login>
    {
        public UserValidator()
        {
            RuleFor(x => x)
              .NotEmpty()
              .WithMessage("A entidade não pode ser vazia.")

              .NotNull()
              .WithMessage("A Entidade não pode ser nula.");
        }
    }
}
