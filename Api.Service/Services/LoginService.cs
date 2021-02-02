using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        public SigningConfigurations _signingConfigurations;
        public TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration;

        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindBy(LoginDto dto)
        {
            if (dto != null && !string.IsNullOrWhiteSpace(dto.Email))
            {
                var user = await _repository.FindByLogin(dto.Email);
                if (user == null)
                    return new { authenticated = false, message = "Falha na autenticação" };
                else
                {
                    var identity = new ClaimsIdentity(new GenericIdentity(user.Email),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.Email)
                    });

                    var createDate = DateTime.UtcNow;
                    var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    var token = CreateToken(identity, createDate, expirationDate, handler);
                    return SucessObject(createDate, expirationDate, token, user);
                }
            }
            else
                return new { authenticated = false, message = "Falha na autenticação" };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }

        private object SucessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity entity)
        {
            const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
            return new
            {
                authenticated = true,
                created = createDate.ToString(DATE_FORMAT),
                expiration = expirationDate.ToString(DATE_FORMAT),
                acessToken = token,
                userName = entity.Email,
                message = "Login realizado com sucesso"
            };
        }
    }
}
