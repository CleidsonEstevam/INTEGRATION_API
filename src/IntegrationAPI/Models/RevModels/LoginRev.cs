using IntegrationAPI.Excepitions;
using IntegrationAPI.Models.Validations;
using IntegrationAPI.Models.Validations.ValidationsRev;

namespace IntegrationAPI.Models.RevModels
{
    public class LoginRev : BaseEntity
    {
        public string? User { get; private set; }
        public string? Password { get; private set; }


        public void ChangeUser(string user)
        {
            User = user;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }


        //EF
        public LoginRev() { }

        public LoginRev(string? user, string? password)
        {
            User = user;
            Password = password;
        }

        //auto validação
        public override bool Validate()
        {
            var validator = new UserRevValidator();

            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Alguns campos inválidos", _errors);
                }
            }
            //Se a entidade tiver ok ele retorna true, se não retorna a exeção
            return true;
        }


    }
}
