using System.Linq.Expressions;
using JWTAssignment.Context;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JWTAssignment.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextClass _context;


        public UserRepository(ContextClass context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }


        public async Task<bool> ExistAsync(string email)
        {
            return await _context.Set<User>().AnyAsync(x => x.Email == email);
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }

        public async Task<User> GetAsync(string email)
        {
            var user = await _context.Set<User>().Include(a => a.UserRoles)
                .ThenInclude(a => a.Role).FirstOrDefaultAsync(a => a.Email == email);
            return user;
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> exp)
        {
            var user = await _context.Set<User>().Include(a => a.UserRoles)
                .ThenInclude(a => a.Role).FirstOrDefaultAsync(exp);
            return user;
        }

        public void Update(User entity)
        {
            var user = _context.Set<User>().Update(entity);
            _context.SaveChanges();
        }
        public async Task<User> Delete(int id)
        {
            var entity =await GetAsync(x => x.Id == id);
            var user = _context.Set<User>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<User> DeleteByName(string userName)
        {
            var entity =await GetAsync(x => x.UserName == userName);
            var user = _context.Set<User>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }

    }
}