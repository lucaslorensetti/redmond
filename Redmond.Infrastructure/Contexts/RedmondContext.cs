using Microsoft.EntityFrameworkCore;
using Redmond.Domain.Entities;
using Redmond.SharedKernel.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Redmond.Infrastructure.Contexts
{
    public class RedmondContext : DbContext, IDbContext
    {
        public RedmondContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public IQueryable<TEntity> GetQueryable<TEntity>()
             where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
        }

        public async Task InsertAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            await this.Set<TEntity>().AddAsync(entity);
        }

        public Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task BeginTransactionAsync()
        {
            await this.Database.BeginTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public Task CommitTransactionAsync()
        {
            this.Database.CommitTransaction();
            return Task.CompletedTask;
        }

        public Task RollbackTransactionAsync()
        {
            this.Database.RollbackTransaction();
            return Task.CompletedTask;
        }

        public Task<bool> HasChangesAsync()
        {
            return Task.FromResult(this.ChangeTracker.HasChanges());
        }
    }
}