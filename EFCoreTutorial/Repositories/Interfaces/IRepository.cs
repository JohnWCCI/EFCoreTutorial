using System.Linq.Expressions;

namespace EFCoreTutorial.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity? GetById(int id);
        List<TEntity> GetAll();
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);

        List<TEntity> GetByPage(int pageNumber, int pageSize);
    }
}
