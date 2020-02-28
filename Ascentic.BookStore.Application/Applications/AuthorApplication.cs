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



        public async Task<IEnumerable<Author>> GetAuthorsWithBooks()
        {
            var obj = await this.authorDomain.GetAuthorsWithBooks();
            //return this.mapper.Map<BookViewDTO[]>(obj);
            return obj;
        }

        public async Task<Author> GetAuthorAllDetails(int key)
        {
            var obj = await this.authorDomain.GetAuthorAllDetails(key);
            //return this.mapper.Map<BookViewDTO[]>(obj);
            return obj;
            // return this.mapper.Map<BookViewDTO>(this.bookDomain.GetAllDetails(key));
        }

    }
}
