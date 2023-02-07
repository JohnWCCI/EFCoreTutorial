using EFCoreTutorial.Context;
using EFCoreTutorial.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace EFCoreTutorial.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
      where TEntity : class
    {
        protected readonly MusicContext context;
        public Repository(MusicContext context)
        {
            this.context = context;
        }
        protected DbContext DataContext { get { return context; } }
        

        public TEntity Add(TEntity entity)
        {
            DataContext.Set<TEntity>().Add(entity);
            DataContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
           TEntity? entity = GetById(id);
            if (entity != null)
            {
                DataContext.Remove(entity);
                DataContext.SaveChanges();
            }
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DataContext.Set<TEntity>().Where(predicate).ToList();
        }

        public List<TEntity> GetAll()
        {
            return DataContext.Set<TEntity>().ToList();
        }

        public TEntity? GetById(int id)
        {
            TEntity? entity = DataContext.Set<TEntity>()
                .Where(w => EF.Property<int>(w, "Id") == id)
                     .FirstOrDefault();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
           DataContext.Set<TEntity>().Add(entity).State = EntityState.Modified;
           DataContext.SaveChanges();
            return entity;
        }
    }
}
