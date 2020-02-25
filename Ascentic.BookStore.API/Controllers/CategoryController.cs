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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category,CategoryDTO, CategoryRepository>
    {
      
        public CategoryController(CategoryRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            
        }


    }
}