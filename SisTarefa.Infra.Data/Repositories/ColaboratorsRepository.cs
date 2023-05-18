
using SisTarefa.Infra.Data.Interfaces;
using SisTarefa.Domain.Entities;
using SisTarefa.Infra.Data.Data;

namespace SisTarefa.Infra.Data.Repositories
{
    public class ColaboratorsRepository : IColaboratorsRepository, IDisposable
    {
        protected readonly DataContext _db;

        public ColaboratorsRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Colaborators> InsertAsync(Colaborators entity)
        {
            try
            {
                _db.Colaborators.Add(entity);
                 await _db.CommitAsync();
                return entity;
            }
            finally
            {
                //Dispose();
            }
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
