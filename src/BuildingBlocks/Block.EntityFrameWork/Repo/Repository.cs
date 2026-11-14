using Blocks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.EntityFrameWork.Repo;

public  class Repository<TEntity,TContext> where TEntity : class, IEntity
where TContext : DbContext
{
    protected readonly TContext _context;
    protected readonly DbSet<TEntity> _Entity;
    public Repository(TContext context)
    {
        _context = context;
        _Entity = context.Set<TEntity>();
    }
    public TContext Context => _context;
    public virtual DbSet<TEntity>Entity => _Entity;
    protected virtual IQueryable<TEntity> Query => _Entity.AsQueryable();
    public string TableName => _context.Model.FindEntityType(typeof(TEntity)).GetTableName();

    public virtual async Task<TEntity> GetByIdAsync(int Id)=> await Query.SingleOrDefaultAsync(e=>e.Id.Equals(Id));
    public virtual async Task<TEntity?> FindByIdAsync(int Id) => await _Entity.FindAsync(Id);
    public virtual async Task<TEntity> AddAsync(TEntity entity) 
        => (await _Entity.AddAsync(entity)).Entity;
    public virtual TEntity UpdateAsync(TEntity entity)
    =>  Entity.Update(entity).Entity;

    public virtual void Remove(TEntity entity) => Entity.Remove(entity);
    public virtual async Task<bool> DeleteByIdAsync(int Id)
    {
        var RowsAffected = await _context.Database.ExecuteSqlRawAsync($"DELETE FROM {TableName} WHERE Id = {Id}");
        return RowsAffected > 0;
    }
    public async Task<int> SaveChangesAsync(CancellationToken ct=default) => await _context.SaveChangesAsync(ct);
    
}
