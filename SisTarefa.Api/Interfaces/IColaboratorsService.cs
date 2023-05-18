
using SisTarefa.Domain.Entities;

namespace SisTarefa.Api.Interfaces
{
    public interface IColaboratorsService
    {
        Task<Colaborators> InsertAsync(Colaborators entity);
    }
}
