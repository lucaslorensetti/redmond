using System.Linq;
using System.Threading.Tasks;

namespace Redmond.SharedKernel.Interfaces
{
    public interface IDbContext
    {
        IQueryable<TEntity> GetQueryable<TEntity>()
            where TEntity : class, IEntity;

        Task CreateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<bool> HasChangesAsync();
    }
}
