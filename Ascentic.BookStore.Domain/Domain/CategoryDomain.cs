using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Infrastructure.Interfaces;
using Ascentic.BookStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Domain
{
    public class CategoryDomain : BaseDomain<Category>, ICategoryDomain
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryDomain(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Category> Add(Category entity)
        {
            await this.unitOfWork.CategoryRepository.Add(entity);
            await this.unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async void Delete(int key)
        {
            await this.unitOfWork.CategoryRepository.Delete(key);
            await this.unitOfWork.SaveChangesAsync();
        }

        public Task<Category> Get(int key)
        {
            var entity = this.unitOfWork.CategoryRepository.Get(key);
            return entity;
        }

        public Task<List<Category>> GetAll()
        {
            var entity = this.unitOfWork.CategoryRepository.GetAll();
            return entity;
        }

        public void Update(int id, Category entity)
        {
            this.unitOfWork.CategoryRepository.Update(id, entity);
            this.unitOfWork.SaveChangesAsync();
        }

    }
}
