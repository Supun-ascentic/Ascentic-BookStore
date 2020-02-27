using Ascentic.BookStore.Application.Interfaces;
using Ascentic.BookStore.Model.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Model.DTO;
using Ascentic.BookStore.Model.Entity;

namespace Ascentic.BookStore.Application.Applications
{
    public class AuthorApplication : BaseApplication<Author,AuthorDTO>,IAuthorApplication
    {
        private readonly IMapper mapper;
        private readonly IAuthorDomain authorDomain;

        public AuthorApplication(IAuthorDomain authorDomain, IMapper mapper)
            : base(authorDomain, mapper)
        {
            this.authorDomain = authorDomain;
            this.mapper = mapper;
        }

    }
}
