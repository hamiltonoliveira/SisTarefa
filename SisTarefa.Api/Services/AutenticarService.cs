using SisTarefa.Api.Interfaces;
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
        public string GerarToKen(string UserName)
        {
            return _autenticarRepositorio.GerarToKen(UserName);
        }
    }
}
