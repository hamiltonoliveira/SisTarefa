using SisTarefa.Domain.Dto;

namespace SisTarefa.Api.Interfaces
{
    public interface IAutenticarService
    {
        Task<TokensDto> GerarToKen(string UserName);
    }
}
