using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Infrastructure.Interfaces;
using Ascentic.BookStore.Model.Entity;
using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Domain
{
    public class AuthorDomain : BaseDomain<Author>, IAuthorDomain
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorDomain(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Author> Add(Author entity)
        {
            await this.unitOfWork.AuthorRepository.Add(entity);
            await this.unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async void Delete(int key)
        {
            await this.unitOfWork.AuthorRepository.Delete(key);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task<Author> Get(int key)
        {
            var entity = await this.unitOfWork.AuthorRepository.Get(key);
            return entity;
        }

        public async Task<List<Author>> GetAll()
        {
            var entity = await this.unitOfWork.AuthorRepository.GetAll();
            return entity;
        }

        public void Update(int id, Author entity)
        {
            this.unitOfWork.AuthorRepository.Update(id, entity);
            this.unitOfWork.SaveChangesAsync();
        }
    }
}
