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
    public class BookRatingController : BaseController<BookRating,RatingDTO, RatingRepository>
    {
        private readonly RatingRepository repository;

        public BookRatingController(RatingRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            this.repository = repository;
        }

        // GET: api/[controller]/5
        [Authorize]
        [HttpGet("get_rating_by_bookid/{id}")]
        public async Task<ActionResult<IEnumerable<BookRating>>> GetRatingByBookId(int id)
        {
            var item = await this.repository.GetRatingByBookId(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
    }
}