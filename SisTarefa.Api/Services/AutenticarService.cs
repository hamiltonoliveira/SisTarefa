using SisTarefa.Api.Interfaces;
using SisTarefa.Domain.Dto;
using SisTarefa.Infra.Data.Interfaces;

namespace SisTarefa.Api.Services
{
    public class AutenticarService : IAutenticarService
    {
        private readonly IAutenticarRepositorio _autenticarRepositorio;
        public AutenticarService(IAutenticarRepositorio autenticarRepositorio)
        {
            _autenticarRepositorio = autenticarRepositorio;
        }
     
        public async Task<TokensDto> GerarToKen(string Email)
        {
            TokensDto tokens = await _autenticarRepositorio.GerarToKen(Email);
            return tokens;
        }
    }
}
 
