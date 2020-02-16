using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascentic_BookStore.Data.EFCore;
using Ascentic_BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ascentic_BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRatingController : BaseController<BookRating, EfCoreRatingRepository>
    {
        public BookRatingController(EfCoreRatingRepository repository)
            : base(repository)
        {
        }
    }
}