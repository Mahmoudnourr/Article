using Blocks.Domain.Entities;

namespace Blocks.EntityFrameWork.Repository.Repo;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task<TEntity> GetByIdAsync(int Id);
    Task <TEntity?>FindByIdAsync(int Id);
    //Task<List<TEntity>> GetAllAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool>DeleteByIdAsync(int Id);
    void Remove(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken ct = default);

}
