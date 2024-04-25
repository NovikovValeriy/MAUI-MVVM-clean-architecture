using _253504Novikov.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _253504Novikov.Persistense.Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }
        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            return query.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }
            return query.SingleAsync(t => t.Id == id, cancellationToken);
        }

        public Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            return query.ToListAsync(cancellationToken).ContinueWith(x => x.Result as IReadOnlyList<T>);
        }

        public async Task<IReadOnlyList<T>> ListAsync(
             Expression<Func<T, bool>>? filter,
             CancellationToken cancellationToken = default,
             params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
    }
}
