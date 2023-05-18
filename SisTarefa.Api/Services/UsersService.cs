
using SisTarefa.Api.Interfaces;
using SisTarefa.Domain.Entities;
using SisTarefa.Infra.Data.Interfaces;
using System.Linq.Expressions;

namespace SisTarefa.Api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepositorio;
       
        public UsersService(IUsersRepository usersRepositorio)
        {
          _usersRepositorio = usersRepositorio;
         }
        public async Task DeleteAsync(int Id)
        {
            await _usersRepositorio.DeleteAsync(Id);
        }

        public async Task<List<Users>> GetAllAsync(int Page, int PageSize)
        {
            return await _usersRepositorio.GetAllAsync(Page, PageSize);
        }
 
        public async Task<Users> GetGuidAsync(string guid)
        {
            return await _usersRepositorio.GetGuidAsync(guid);
        }

        public async Task<Users> GetIdAsync(int id)
        {
            return await _usersRepositorio.GetIdAsync(id);
        }

        public async Task<Users> InsertAsync(Users entity)
        {
           return await _usersRepositorio.InsertAsync(entity);
        }

        public async Task UpdateAsync(Users entity)
        {
            await _usersRepositorio.UpdateAsync(entity);
        }

        public async Task<List<Users>> WhereAsync(Expression<Func<Users, bool>> expression)
        {
           return await _usersRepositorio.WhereAsync(expression);
        }
    }
}
