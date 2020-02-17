using Ascentic.BookStore.Domain.DTO;
using Ascentic.BookStore.Domain.Entity;
using Ascentic.BookStore.Domain.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Mapper
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<AuthorDTO, Author>();
            CreateMap<BookAuthorDTO, BookAuthor>();
            CreateMap<BookDTO, Book>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<RatingDTO, BookRating>();
        }
    }
}
