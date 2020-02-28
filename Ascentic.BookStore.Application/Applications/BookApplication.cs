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
using Ascentic.BookStore.Model.ViewDTO;

namespace Ascentic.BookStore.Application.Applications
{
    public class BookApplication : BaseApplication<Book, BookDTO>,IBookApplication
    {
        private readonly IMapper mapper;
        private readonly IBookDomain bookDomain;

        public BookApplication(IBookDomain bookDomain, IMapper mapper)
            :base(bookDomain,mapper)
        {
            this.bookDomain = bookDomain;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Book>> GetBooksWithAllDetails()
        {
            var obj = await this.bookDomain.GetBooksWithAllDetails();
           // var result= this.mapper.Map<BookViewDTO[]>(obj);
            return obj;
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByAuthor()
        {
            var obj = await this.bookDomain.GetBooksSortedByAuthor();
            //return this.mapper.Map<BookViewDTO[]>(obj);
            return obj;
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByTitle()
        {
            var obj = await this.bookDomain.GetBooksSortedByTitle();
            //return this.mapper.Map<BookViewDTO[]>(obj);
            return obj;
        }

        public async Task<Book> GetAllDetails(int key)
        {
            var obj = await this.bookDomain.GetAllDetails(key);
            //return this.mapper.Map<BookViewDTO[]>(obj);
            return obj;
           // return this.mapper.Map<BookViewDTO>(this.bookDomain.GetAllDetails(key));
        }

    }
}
