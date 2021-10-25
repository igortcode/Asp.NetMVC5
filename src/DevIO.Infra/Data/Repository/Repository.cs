using DevIO.Business.Core.Data;
using DevIO.Business.Core.Models;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() 
    {
        protected readonly MeusProdutosDbContext context;
        protected readonly DbSet<TEntity> DBSet;

        public Repository()
        {
            context = new MeusProdutosDbContext();
            DBSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DBSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DBSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DBSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DBSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            context.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context?.Dispose();
        }

    }
}
