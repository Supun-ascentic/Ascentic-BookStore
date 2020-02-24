namespace Ascentic.BookStore.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ascentic.BookStore.Domain.DTO;
    using Ascentic.BookStore.Domain.Entity;
    using Ascentic.BookStore.Infrastructure.Repository;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController<Author,AuthorDTO,AuthorRepository>
    {
        private readonly AuthorRepository repository;

        public AuthorController(AuthorRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
       [Authorize]
        [HttpGet]
        [Route("get_authors_with_books")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthorsWithBooks()
        {
            return await this.repository.GetAuthorsWithBooks();
        }


        // GET: api/[controller]/5
        [Authorize]
        [HttpGet("get_full_author_details/{id}")]
        public async Task<ActionResult<Author>> GetAllDetails(int id)
        {
            var item = await repository.GetAuthorAllDetails(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}