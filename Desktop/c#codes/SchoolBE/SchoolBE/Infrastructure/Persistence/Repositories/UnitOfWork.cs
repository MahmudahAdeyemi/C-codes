using SchoolBE.Core.Application.Interfaces.Repositories;
using SchoolBE.Infrastructure.Persistence.Context;

namespace SchoolBE.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudContext _context;
        public UnitOfWork(StudContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
