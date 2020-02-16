using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascentic_BookStore.Data.EFCore;
using Ascentic_BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ascentic_BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController<Author, EfCoreAuthorRepository>
    {
        private readonly EfCoreAuthorRepository repository;
        public AuthorController(EfCoreAuthorRepository repository)
            : base(repository)
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
    }
}