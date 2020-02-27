using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascentic.BookStore.Application.Interfaces;
using Ascentic.BookStore.Model.DTO;
using Ascentic.BookStore.Model.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ascentic.BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TBaseDTO, TBaseApplication> : ControllerBase
        where TEntity : class, IEntity
        where TBaseDTO : class, IBaseDTO
        where TBaseApplication : IBaseApplication<TEntity,TBaseDTO>
    {
            private readonly TBaseApplication baseApplication;
            private readonly IMapper mapper;

            public BaseController(TBaseApplication baseApplication)
            {
                this.baseApplication = baseApplication;
            }

            // GET: api/[controller]
            //[Authorize]
            [HttpGet]
            public async  Task<ActionResult<IEnumerable<TBaseDTO>>> Get()
            {
                try
                {
                    var result = await this.baseApplication.GetAll();
                    return this.Ok(result);
                }
                catch (Exception)
                {
                    return this.BadRequest("Could not get data");
                }
            }

            // GET: api/[controller]/5
            //[Authorize]
            [HttpGet("{id}")]
            public async Task<ActionResult<TEntity>> Get(int id)
            {
                try
                {
                    var result = await this.baseApplication.Get(id);
                    return this.Ok(result);
                }
                catch (Exception)
                {
                    return this.BadRequest("Could not get data");
                }
            }

            // PUT: api/[controller]/5
            //[Authorize]
            [HttpPut("{id}")]
            public async Task<ActionResult<TEntity>> Put(int id, TBaseDTO TBaseDTO)
            {
                try
                {
                    if (id != TBaseDTO.ID)
                    {
                        return this.BadRequest("Incorrect data provided");
                    }
                    this.baseApplication.Update(id,TBaseDTO);
                    return this.Ok("UPDATE SUCCESSED");
                }
                catch (Exception)
                {
                    return this.BadRequest("Could not update data");
                }
            }

            // POST: api/[controller]
          //  [Authorize]
            [HttpPost]
            public async Task<ActionResult<TEntity>> Post(TBaseDTO TBaseDTO)
            {
                try
                {
                    return this.Ok(await this.baseApplication.Add(TBaseDTO));
                }
                catch (Exception)
                {
                    return this.BadRequest("Could not add data");
                }
            }

            // DELETE: api/[controller]/5
            //[Authorize]
            [HttpDelete("{id}")]
            public async Task<ActionResult<TEntity>> Delete(int id)
            {
                try
                {
                    this.baseApplication.Delete(id);
                    return this.Ok();
                }
                catch (Exception)
                {
                     return this.BadRequest("Could not add data");
            }
            }

        }
    }