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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BookRatingController : BaseController<BookRating,RatingDTO, RatingRepository>
    {
        public BookRatingController(RatingRepository repository, IMapper mapper)
            : base(repository,mapper)
        {
        }
    }
}