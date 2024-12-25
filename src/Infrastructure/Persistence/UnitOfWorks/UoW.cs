using Domain.Core.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.UnitOfWorks
{
    public class UoW : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UoW (DbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new Repository<T>(_context);
            }

            return (IRepository<T>)_repositories[typeof(T)];
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
