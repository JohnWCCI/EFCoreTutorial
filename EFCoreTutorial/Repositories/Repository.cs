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
        

        public virtual TEntity Add(TEntity entity)
        {
            DataContext.Set<TEntity>().Add(entity);
            DataContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(int id)
        {
           TEntity? entity = GetById(id);
            if (entity != null)
            {
                DataContext.Remove(entity);
                DataContext.SaveChanges();
            }
        }

        public virtual List<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> query = DataContext.Set<TEntity>()
                .Where(predicate);
            return query.ToList(); 
        }

        public virtual List<TEntity> GetAll()
        {
            return DataContext.Set<TEntity>().ToList();
        }

        public virtual TEntity? GetById(int id)
        {
            TEntity? entity = DataContext.Set<TEntity>()
                .Where(w => EF.Property<int>(w, "Id") == id)
                     .FirstOrDefault();
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
           DataContext.Set<TEntity>().Add(entity)
                .State = EntityState.Modified;
           DataContext.SaveChanges();
            return entity;
        }
        public virtual List<TEntity> GetByPage(int pageNumber,int pageSize)
        {
            int startingRecordNumber = (pageNumber-1) * pageSize;

            return context.Set<TEntity>()
                 .Skip(startingRecordNumber)
                 .Take(pageSize)
                 .ToList();
        }

    }
}
