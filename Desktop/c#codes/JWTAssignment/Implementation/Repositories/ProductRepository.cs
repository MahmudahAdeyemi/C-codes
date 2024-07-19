using JWTAssignment.Context;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JWTAssignment.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextClass _context;

        public ProductRepository(ContextClass context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            await _context.Set<Product>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public Product Update(Product entity)
        {
            var user = _context.Set<Product>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<Product> GetProductByName(string name)
        {
            var entity =await _context.Set<Product>().FirstOrDefaultAsync(x => x.Name == name);
            return entity;
        }
        public async Task<Product> GetProductById(int Id)
        {
            var entity =await _context.Set<Product>().FirstAsync(x => x.Id == Id);
            return entity;
        }
        public async Task<Product> Delete(int id)
        {
            var entity =await _context.Set<Product>().FirstAsync(x => x.Id == id);
            var user = _context.Set<Product>().Remove(entity);
            return entity;
        }
    }
}