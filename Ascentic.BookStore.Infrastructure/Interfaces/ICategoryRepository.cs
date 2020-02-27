namespace Ascentic.BookStore.Infrastructure.Interfaces
{
    using Ascentic.BookStore.Model.Entity;
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> Get(int id);

        Task<Category> Add(Category entity);

        Task<Category> Update(int id, Category entity);

        Task<Category> Delete(int id);
    }
}
