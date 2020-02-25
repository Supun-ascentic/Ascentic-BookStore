namespace Ascentic.BookStore.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ascentic.BookStore.Model.DTO;
    using Ascentic.BookStore.Model.Entity;
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
            : base(repository, mapper)
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

        // GET: api/[controller]
        [Authorize]
        [HttpGet]
        [Route("get_books_sorted_by_title")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksSortedByTitle()
        {
            return await this.repository.GetBooksSortedByTitle();
        }

        // GET: api/[controller]
        [Authorize]
        [HttpGet]
        [Route("get_books_sorted_by_author")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksSortedByAuthor()
        {
            return await this.repository.GetBooksSortedByAuthor();
        }

        // GET: api/[controller]/5
        [Authorize]
        [HttpGet("get_full_book_details/{id}")]
        public async Task<ActionResult<Book>> GetAllDetails(int id)
        {
            var item = await repository.GetAllDetails(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}