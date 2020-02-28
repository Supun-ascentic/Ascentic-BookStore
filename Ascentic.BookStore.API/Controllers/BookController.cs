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
    using Ascentic.BookStore.Application.Interfaces;
    using Ascentic.BookStore.Model.ViewDTO;

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController<Book, BookDTO, IBookApplication>
    {

        private readonly IBookApplication bookApplication;

        public BookController(IBookApplication bookApplication)
            : base(bookApplication)
        {
            this.bookApplication = bookApplication;
        }

        
        
        // GET: api/[controller]
       // [Authorize]
        [HttpGet]
        [Route("get_books_with_all_Details")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksWithAllDetails()
        {
            try
            {
                var result = await this.bookApplication.GetBooksWithAllDetails();
                return this.Ok(result);
            }
            catch (Exception)
            {
                return this.BadRequest("Could not get data");
            }
        }

        // GET: api/[controller]
      //  [Authorize]
        [HttpGet]
        [Route("get_books_sorted_by_title")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksSortedByTitle()
        {
            try
            {
                var result = await this.bookApplication.GetBooksSortedByTitle();
                return this.Ok(result);
            }
            catch (Exception)
            {
                return this.BadRequest("Could not get data");
            }
        }

        // GET: api/[controller]
      //  [Authorize]
        [HttpGet]
        [Route("get_books_sorted_by_author")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksSortedByAuthor()
        {
            try
            {
                var result = await this.bookApplication.GetBooksSortedByAuthor();
                return this.Ok(result);
            }
            catch (Exception)
            {
                return this.BadRequest("Could not get data");
            }
        }

        // GET: api/[controller]/5
     //   [Authorize]
        [HttpGet("get_full_book_details/{id}")]
        public async Task<ActionResult<Book>> GetAllDetails(int id)
        {
            try
            {
                var result = await bookApplication.GetAllDetails(id);
                return this.Ok(result);
            }
            catch (Exception)
            {
                return this.BadRequest("Could not get data");
            }
        }

    
    }
}