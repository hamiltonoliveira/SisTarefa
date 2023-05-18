
using SisTarefa.Api.Interfaces;
using SisTarefa.Domain.Entities;
using SisTarefa.Infra.Data.Interfaces;

namespace SisTarefa.Api.Services
{
    public class ColaboratorsService : IColaboratorsService
    {
        private readonly IColaboratorsRepository _colaboratorsRepository;

        public ColaboratorsService(IColaboratorsRepository colaboratorsRepository)
        {
            _colaboratorsRepository = colaboratorsRepository;
        }

        public async Task<Colaborators> InsertAsync(Colaborators entity)
        {
             return await _colaboratorsRepository.InsertAsync(entity);
        }
    }
}
