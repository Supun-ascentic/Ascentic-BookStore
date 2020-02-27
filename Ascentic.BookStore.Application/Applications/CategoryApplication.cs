using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Model.DTO;
using Ascentic.BookStore.Model.Entity;
using Ascentic.BookStore.Application.Interfaces;

namespace Ascentic.BookStore.Application.Applications
{
    public class CategoryApplication : BaseApplication<Category, CategoryDTO>,ICategoryApplication
    {
        private readonly IMapper mapper;
        private readonly ICategoryDomain categoryDomain;

        public CategoryApplication(ICategoryDomain categoryDomain, IMapper mapper)
            : base(categoryDomain, mapper)
        {
            this.categoryDomain = categoryDomain;
            this.mapper = mapper;
        }

    }
}
