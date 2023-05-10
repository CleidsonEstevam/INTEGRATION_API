using IntegrationAPI.Excepitions;
using IntegrationAPI.Models.Validations.ValidationsRev;

namespace IntegrationAPI.Models.RevModels
{
    public class TokenRev : BaseEntity
    {
      
            public string AccessToken { get; private set; }
            public string TokenType { get; private set; }
            public int ExpiresIn { get; private set; }

            public TokenRev(string accessToken, string tokenType, int expiresIn)
            {
                AccessToken = accessToken;
                TokenType = tokenType;
                ExpiresIn = expiresIn;
            }

            public void ChangeAccessToken(string accessToken)
            {
                AccessToken = accessToken;
                Validate();
            }

            public void ChangeTokenType(string tokenType)
            {
                TokenType = tokenType;
                Validate();
            }

            public void ChangeExpiresIn(int expiresIn)
            {
                ExpiresIn = expiresIn;
                Validate();
            }


        public override bool Validate()
        {
            var validator = new TokenRevValidator();

            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Alguns campos inválidos", _errors);
                }
            }

            return true;
        }

    }
}
