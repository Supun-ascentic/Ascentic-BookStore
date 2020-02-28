using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Infrastructure.Interfaces;
using Ascentic.BookStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Domain
{
    public class BookDomain : BaseDomain<Book>,IBookDomain
    {
        private readonly IUnitOfWork unitOfWork;

        public BookDomain(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Book> Add(Book entity)
        {
            await this.unitOfWork.BookRepository.Add(entity);
            await this.unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async void Delete(int key)
        {
            await this.unitOfWork.BookRepository.Delete(key);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task<Book> Get(int key)
        {
            var entity =await this.unitOfWork.BookRepository.Get(key);
            return entity;
        }

        public async Task<List<Book>> GetAll()
        {
            var entity = await this.unitOfWork.BookRepository.GetAll();
            return entity;
        }

        public async void Update(int id, Book entity)
        {
            this.unitOfWork.BookRepository.Update(id, entity);
            this.unitOfWork.SaveChangesAsync();
        }


        public async Task<List<Book>> GetBooksWithAllDetails()
        {
            var entity = await this.unitOfWork.BookRepository.GetBooksWithAllDetails();
            return entity;
        }

        public async Task<List<Book>> GetBooksSortedByTitle()
        {
            var entity = await this.unitOfWork.BookRepository.GetBooksSortedByTitle();
            return entity;
        }

        public async Task<List<Book>> GetBooksSortedByAuthor()
        {
            var entity = await this.unitOfWork.BookRepository.GetBooksSortedByAuthor();
            return entity;
        }

        public async Task<Book> GetAllDetails(int key)
        {
            var entity = await this.unitOfWork.BookRepository.GetAllDetails(key);
            return entity;
        }


    }
}
