using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SisTarefa.Domain.Dto;
using SisTarefa.Domain.Entities;
using SisTarefa.Domain.Helpers;
using SisTarefa.Domain.ViewModels;
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
        public async Task<TokensDto> GerarToKen(string UserName)
        {
            var user = await _db.Set<Users>().FirstOrDefaultAsync(x => x.UserName == UserName);
            var Token = new TokensDto();

            if (user == null)
            { return null; }
            
            Token.Token = generateJwtToken(user.UserName, user.GuidI);
            Token.TokenRefresh = generateJwtTokenRefresh(user.GuidI);
            return Token;
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
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string generateJwtTokenRefresh(string guid)
        {
            string oculto = CodigoCripto.Cripto();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(oculto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                   new Claim("Guid", guid)
                }),
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
