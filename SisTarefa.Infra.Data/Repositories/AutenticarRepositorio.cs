using Microsoft.IdentityModel.Tokens;
using SisTarefa.Domain.Entities;
using SisTarefa.Domain.Helpers;
using SisTarefa.Infra.Data.Data;
using SisTarefa.Infra.Data.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SisTarefa.Infra.Data.Repositories
{
    public class AutenticarRepositorio : IAutenticarRepositorio
    {

        protected readonly DataContext _db;
        public string GerarToKen(string UserName)
        {
            var user = _db.Set<Users>().Where(x => (x.UserName == UserName));
            string token = string.Empty;
            foreach (var item in user)
            {
                token = generateJwtToken(item.UserName, item.GuidI);
            }
            return token;
        }

        private string generateJwtToken(string UserName, string guid)
        {
            string oculto = CodigoCripto.Cripto();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(oculto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                  new Claim("UserName", UserName),
                  new Claim("Guid", guid) 
                }),
                Expires = DateTime.UtcNow.AddMonths(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
