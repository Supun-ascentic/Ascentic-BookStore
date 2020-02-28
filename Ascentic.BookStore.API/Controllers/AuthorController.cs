namespace Ascentic.BookStore.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ascentic.BookStore.Model.DTO;
    using Ascentic.BookStore.Model.Entity;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Ascentic.BookStore.Application.Interfaces;
    using Ascentic.BookStore.Model.ViewDTO;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController<Author, AuthorDTO, IAuthorApplication>

    {
        private readonly IAuthorApplication authorApplication;

        public AuthorController(IAuthorApplication authorApplication)
            : base(authorApplication)
        {
            this.authorApplication = authorApplication;
   
        }

        
        // GET: api/[controller]
       //[Authorize]
        [HttpGet]
        [Route("get_authors_with_books")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthorsWithBooks()
        {
            try
            {
                var result = await this.authorApplication.GetAuthorsWithBooks();
                return this.Ok(result);
            }
            catch (Exception)
            {
                return this.BadRequest("Could not get data");
            }
        }


        // GET: api/[controller]/5
        //[Authorize]
        [HttpGet("get_full_author_details/{id}")]
        public async Task<ActionResult<Author>> GetAllDetails(int id)
        {
            try
            {
                var result = await authorApplication.GetAuthorAllDetails(id);
                return this.Ok(result);
            }
            catch (Exception)
            {
                return this.BadRequest("Could not get data");
            }
        }

    
    }
}