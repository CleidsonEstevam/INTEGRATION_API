using IntegrationAPI.Excepitions;
using IntegrationAPI.Models.Validations;

namespace IntegrationAPI.Models
{
    public class Login : BaseEntity
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
        public Login(){}

        //auto validação
        public override bool Validate()
        {
            var validator = new UserValidator();

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
