using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SisTarefa.Domain.Dto;
using SisTarefa.Domain.Entities;
using SisTarefa.Domain.Helpers;
using SisTarefa.Infra.Data.Data;
using SisTarefa.Infra.Data.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SisTarefa.Infra.Data.Repositories
{
    public class AutenticarRepositorio : IAutenticarRepositorio
    {
        protected readonly DataContext _db;

        private readonly IUsersRepository _usersRepository;
        public AutenticarRepositorio(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<TokensDto> GerarToKen(string Email)
        {
             List<Users> usuarios = await _usersRepository.WhereAsync(x => x.Email == Email);

             

            var _UserName = string.Empty;
            var _GuidI = string.Empty;

            foreach (var item in usuarios)
            {
                _UserName = item.UserName;
                _GuidI = item.GuidI;
            }
            
            var _Token = generateJwtToken(_UserName , _GuidI);
            var _TokenRefresh = generateJwtTokenRefresh(_GuidI);

            return new TokensDto()
            {
                Token = _Token,
                TokenRefresh = _TokenRefresh
            };
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
                 new Claim("Guid", guid), 
                 new Claim(ClaimTypes.Role, UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
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
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
    }
}
