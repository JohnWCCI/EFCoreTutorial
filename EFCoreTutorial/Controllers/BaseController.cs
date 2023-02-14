using EFCoreTutorial.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTutorial.Controllers
{

    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase
         where TEntity : class
    {
        protected readonly IRepository<TEntity> repository;

        public BaseController(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("GetByPage")]
        public ActionResult<IEnumerable<TEntity>> GetByPage(int pageNumber, int pageSize)
        {
            if(pageNumber<= 1)
            {
                pageNumber= 1;
            }
            return repository.GetByPage(pageNumber, pageSize);
        }


        [HttpGet("GetById")]
        public ActionResult<TEntity> GetById(int id)
        {
            var entity = repository.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPut]
        public ActionResult<TEntity> Put(TEntity entity)
        {
            return repository.Update(entity);
        }

        [HttpPost]
        public ActionResult<TEntity> Post(TEntity entity)
        {
            return repository.Add(entity);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}
