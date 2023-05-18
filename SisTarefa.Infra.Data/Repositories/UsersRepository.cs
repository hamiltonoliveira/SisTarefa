using Microsoft.EntityFrameworkCore;
using SisTarefa.Domain.Entities;
using SisTarefa.Infra.Data.Data;
using SisTarefa.Infra.Data.Interfaces;
using System.Linq.Expressions;

namespace SisTarefa.Infra.Data.Repositories
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        protected readonly DataContext _db;
        public UsersRepository(DataContext db)
        {
            _db = db;
        }
        public async Task DeleteAsync(int Id)
        {
            try
            {
                var user = await _db.Users.FindAsync(Id);

                if (user != null)
                {
                    user.SetDeletar();
                    _db.Users.Update(user);
                    await _db.CommitAsync();
                }
            }
            finally
            {
                Dispose();
            }
        }

        public async Task<List<Users>> GetAllAsync(int Page, int PageSize)
        {
            if (Page == 0)
                Page = 1;
            var retorna = (from cust in _db.Users orderby cust.UserName select cust).Where(x => x.DeletedAt != null)
            .Skip(Page - 1).Take(PageSize).ToListAsync();
            return retorna.Result;
        }

        public async Task<Users> GetGuidAsync(string guid)
        {
            return await _db.Users.FindAsync(guid);
        }

        public async Task<Users> GetIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<Users> InsertAsync(Users entity)
        {
            try
            {
                var verificaUsers = _db.Users.SingleOrDefault(x => x.UserName == entity.UserName);

                if (verificaUsers == null)
                {
                    _db.Users.Add(entity);
                     await _db.CommitAsync();
                }
                return entity;
            }
            finally
            {
                //Dispose();
            }
        }
        public async Task UpdateAsync(Users entity)
        {
            try
            {
                var recebe = _db.Users.FindAsync(entity.Id);
                if (recebe != null)
                {
                    _db.Update(entity);
                    _db.Entry(entity).State = EntityState.Modified;
                    await _db.CommitAsync();
                }
            }
            finally { Dispose(); }
        }

        public async Task<List<Users>> WhereAsync(Expression<Func<Users, bool>> expression)
        {
            return await _db.Set<Users>().Where(expression).ToListAsync();
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
