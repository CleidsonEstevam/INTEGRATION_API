using IntegrationAPI.Excepitions;
using IntegrationAPI.Models.Validations.ValidationsRev;
using System.IdentityModel.Tokens.Jwt;

namespace IntegrationAPI.Models.RevModels
{
    public class TokenRev : BaseEntity
    {

        public string? AccessToken { get; private set; }
        public string? TokenType { get; private set; }
        public int ExpiresIn { get; private set; }

        public void ChangeAccessToken(string? accessToken)
        {
            AccessToken = accessToken;
            Validate();
        }

        public void ChangeTokenType(string? tokenType)
        {
            TokenType = tokenType;
            Validate();
        }

        public void ChangeExpiresIn(int expiresIn)
        {
            ExpiresIn = expiresIn;
            Validate();
        }

        public void TokenHandler(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var accessToken = jwtToken.Claims.FirstOrDefault(c => c.Type == "access_token")?.Value;
            var tokenType = jwtToken.Claims.FirstOrDefault(c => c.Type == "token_type")?.Value;
            var expiresIn = jwtToken.Claims.FirstOrDefault(c => c.Type == "expires_in")?.Value;

            ChangeAccessToken(accessToken);
            ChangeTokenType(tokenType);
            ChangeExpiresIn(Convert.ToInt32(expiresIn));

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
