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
    public class BookController : BaseController<Book, BookDTO, BookRepository>
    {

        private readonly BookRepository repository;

        public BookController(BookRepository repository, IMapper mapper)
            : base(repository,mapper)
        {
            this.repository = repository;
        }

        // GET: api/[controller]
       // [Authorize]
        [HttpGet]
        [Route("get_books_with_all_Details")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksWithAllDetails()
        {
            return await this.repository.GetBooksWithAllDetails();
        }
    }
}