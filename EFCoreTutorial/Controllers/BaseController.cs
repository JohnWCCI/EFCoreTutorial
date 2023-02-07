using EFCoreTutorial.Models;
using EFCoreTutorial.Repositories;
using EFCoreTutorial.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.Controllers
{
   
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase
         where TEntity : class
    {
        private readonly IRepository<TEntity> repository;

        public BaseController(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> Get()
        {
            return repository.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<TEntity> Get(int id)
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
