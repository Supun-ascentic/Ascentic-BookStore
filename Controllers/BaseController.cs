using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascentic_BookStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ascentic_BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
        {
            private readonly TRepository repository;

            public BaseController(TRepository repository)
            {
                this.repository = repository;
            }


            // GET: api/[controller]
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TEntity>>> Get()
            {
                return await repository.GetAll();
            }

            // GET: api/[controller]/5
            [HttpGet("{id}")]
            public async Task<ActionResult<TEntity>> Get(int id)
            {
                var item = await repository.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }

            // PUT: api/[controller]/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, TEntity item)
            {
                if (id != item.ID)
                {
                    return BadRequest();
                }
                await repository.Update(item);
                return NoContent();
            }

            // POST: api/[controller]
            [HttpPost]
            public async Task<ActionResult<TEntity>> Post(TEntity item)
            {
                await repository.Add(item);
                return CreatedAtAction("Get", new { id = item.ID }, item);
            }

            // DELETE: api/[controller]/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TEntity>> Delete(int id)
            {
                var item = await repository.Delete(id);
                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }

        }
    }