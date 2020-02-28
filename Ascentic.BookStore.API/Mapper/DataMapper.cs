using Ascentic.BookStore.Model.DTO;
using Ascentic.BookStore.Model.Entity;
using Ascentic.BookStore.Model.Interfaces;
using Ascentic.BookStore.Model.ViewDTO;
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
            CreateMap<AuthorDTO, Author>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<BookAuthorDTO, BookAuthor>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<BookCategoryDTO, BookCategory>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<BookDTO, Book>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<CategoryDTO, Category>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<RatingDTO, Rating>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());


            CreateMap<AuthorViewDTO, Author>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<BookAuthorViewDTO, BookAuthor>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<BookCategoryViewDTO, BookCategory>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<BookViewDTO, Book>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<CategoryViewDTO, Category>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
            CreateMap<RatingViewDTO, Rating>().ReverseMap().ForMember(b => b.CreatedOn, opt => opt.Ignore());
        }
    }
}
