using SisTarefa.Domain.Dto;
 
namespace SisTarefa.Infra.Data.Interfaces
{
    public interface IAutenticarRepositorio
    {
        Task<TokensDto> GerarToKen(string GuidId);
    }
}
