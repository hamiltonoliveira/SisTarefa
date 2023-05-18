
using SisTarefa.Domain.Entities;

namespace SisTarefa.Infra.Data.Interfaces
{
    public interface IColaboratorsRepository  
    {
        Task<Colaborators> InsertAsync(Colaborators entity);
    }
}
