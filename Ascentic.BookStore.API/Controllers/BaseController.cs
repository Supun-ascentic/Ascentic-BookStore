using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascentic.BookStore.Domain.DTO;
using Ascentic.BookStore.Domain.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ascentic.BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TDTO, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TDTO : class, IBaseDTO
        where TRepository : IRepository<TEntity>
        {
            private readonly TRepository repository;
            private readonly IMapper mapper;

            public BaseController(TRepository repository, IMapper mapper)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            // GET: api/[controller]
            [Authorize]
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TEntity>>> Get()
            {
                return await repository.GetAll();
            }

            // GET: api/[controller]/5
            [Authorize]
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
            [Authorize]
            [HttpPut("{id}")]
            public async Task<ActionResult<TEntity>> Put(int id, TDTO tDto)
            {
             var item = this.mapper.Map<TEntity>(tDto);
             if (id != item.ID)
            {
                return BadRequest();
            }
             await repository.Update(item);
             return item;
            }

            // POST: api/[controller]
          //  [Authorize]
            [HttpPost]
            public async Task<ActionResult<TEntity>> Post(TDTO tDto)
            {
                var item = this.mapper.Map<TEntity>(tDto);
                await repository.Add(item);
                return CreatedAtAction("Get", new { id = item.ID }, item);
            }

            // DELETE: api/[controller]/5
            [Authorize]
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